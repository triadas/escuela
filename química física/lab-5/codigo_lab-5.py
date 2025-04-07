!pip install thermo

# -*- coding: utf-8 -*-
import numpy as np
import matplotlib.pyplot as plt
from thermo import ChemicalConstantsPackage, CEOSGas, CEOSLiquid, PRMIX, FlashVL, FlashVLN
from thermo.unifac import DOUFSG, DOUFIP2016, UNIFAC
from scipy.optimize import minimize

# =============================================
# Часть I: Модель UNIFAC + Peng-Robinson
# =============================================

# Загрузка параметров компонентов
components = ['107-21-1', '67-56-1']  # CAS-номера этиленгликоля и метанола
constants, properties = ChemicalConstantsPackage.from_IDs(components)

# Параметры модели
T = 298.15  # K (для P-xy и y-x диаграмм)
P = 1e5     # 1 bar (для T-xy диаграммы)
zs = [0.5, 0.5]  # Начальный состав смеси

# Настройка модели Peng-Robinson
k12 = 0.0  # Начальное значение параметра взаимодействия
kijs = [[0, k12], [k12, 0]]
eos_kwargs = dict(Tcs=constants.Tcs, Pcs=constants.Pcs, omegas=constants.omegas, kijs=kijs)

# Фазовая модель
gas = CEOSGas(PRMIX, eos_kwargs=eos_kwargs, HeatCapacityGases=properties.HeatCapacityGases)
GE = UNIFAC.from_subgroups(chemgroups=constants.UNIFAC_Dortmund_groups, version=1, T=T, xs=zs, interaction_data=DOUFIP2016, subgroups=DOUFSG)
liquid = GibbsExcessLiquid(\
    VaporPressures=properties.VaporPressures,\
    HeatCapacityGases=properties.HeatCapacityGases,\
    VolumeLiquids=properties.VolumeLiquids,\
    GibbsExcessModel=GE,\
    equilibrium_basis='Psat', caloric_basis='Psat'\
)

flasher = FlashVL(constants, properties, liquid=liquid, gas=gas)

# =============================================
# Построение диаграмм
# =============================================

plt.figure(figsize=(15, 5))

# 1. P-xy диаграмма при T = 298.15 K
plt.subplot(1, 3, 1)
flasher.plot_Pxy(T=298.15, pts=100)
plt.title("P-xy диаграмма при 298.15 K")
plt.grid()

# 2. y-x диаграмма при T = 298.15 K
plt.subplot(1, 3, 2)
flasher.plot_xy(T=298.15, pts=100)
plt.plot([0, 1], [0, 1], 'k--')
plt.title("y-x диаграмма при 298.15 K")
plt.grid()

# 3. T-xy диаграмма при P = 1 bar
plt.subplot(1, 3, 3)
flasher.plot_Txy(P=1e5, pts=100)
plt.title("T-xy диаграмма при 1 bar")
plt.grid()

plt.tight_layout()
plt.show()

# =============================================
# Анализ фигуративной точки D
# =============================================

# Точка D в двухфазной области
T_D = 350  # K
z_D = [0.5, 0.5]  # Эквимолярная смесь

res_D = flasher.flash(T=T_D, P=1e5, zs=z_D)

print("\nАнализ точки D:")
print(f"Фаз: {res_D.phase_count}")
if res_D.phase_count > 1:
    x_D = res_D.liquid0.zs[0]
    y_D = res_D.gas.zs[0]
    print(f"Состав жидкости: x = {x_D:.4f}")
    print(f"Состав пара: y = {y_D:.4f}")
    
    # Правило рычага
    L = (y_D - z_D[0]) / (y_D - x_D)  # Доля жидкости
    V = 1 - L                          # Доля пара
    print(f"Доля жидкости: {L:.2%}, Доля пара: {V:.2%}")

# =============================================
# Расчет ошибок (сравнение с vle-calc.com)
# =============================================

# Примерные экспериментальные данные (замените реальными с vle-calc.com)
T_exp = [330, 340, 350, 360, 370]  # K
x_exp = [0.1, 0.2, 0.3, 0.4, 0.5]   # Составы жидкости
y_exp = [0.3, 0.4, 0.5, 0.6, 0.7]   # Составы пара

mae_x, mae_y = 0, 0

print("\nРасчет ошибок:")
for i in range(5):
    z_i = (x_exp[i] + y_exp[i]) / 2  # Средний состав
    res = flasher.flash(T=T_exp[i], P=1e5, zs=[z_i, 1-z_i])
    
    if res.phase_count > 1:
        x_pred = res.liquid0.zs[0]
        y_pred = res.gas.zs[0]
    else:
        x_pred, y_pred = 0, 0
    
    mae_x += abs(x_pred - x_exp[i])
    mae_y += abs(y_pred - y_exp[i])
    
    print(f"T = {T_exp[i]} K: x_pred = {x_pred:.4f}, y_pred = {y_pred:.4f}")

mae_x /= 5
mae_y /= 5

print(f"\nСредняя абсолютная ошибка:")
print(f"По x: {mae_x:.4f}")
print(f"По y: {mae_y:.4f}")

# =============================================
# Часть II: Оптимизация параметра k12
# =============================================

# Функция для минимизации ошибки
def objective(k12):
    kijs = [[0, k12], [k12, 0]]
    eos_kwargs['kijs'] = kijs
    gas = CEOSGas(PRMIX, eos_kwargs=eos_kwargs, HeatCapacityGases=properties.HeatCapacityGases)
    flasher = FlashVL(constants, properties, liquid=liquid, gas=gas)
    
    error = 0
    for i in range(5):
        res = flasher.flash(T=T_exp[i], P=1e5, zs=[zs[i], 1-zs[i]])
        if res.phase_count > 1:
            error += (res.gas.zs[0] - y_exp[i])**2
    return error

# Оптимизация
result = minimize(objective, x0=0.0, bounds=[(-1, 1)])
k12_opt = result.x[0]
print(f"\nОптимальное значение k12: {k12_opt:.4f}")