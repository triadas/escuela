#############
# UNIFAC + PR
#############
!pip install thermo
from thermo import *
from thermo.unifac import DOUFSG, DOUFIP2016
# Загрузка констант и свойств
constants, properties = ChemicalConstantsPackage.from_IDs(['acetone', 'chloroform'])
# Объекты инициализируются при заданных условиях
T = 298.15  # Температура в Кельвинах
P = 1e5      # Давление в Паскалях
zs = [.5, .5]  # Мольные доли компонентов

#print(constants)

# Использование уравнения Пенга-Робинсона для газовой фазы
k12 = 0.1231  # Бинарный параметр взаимодействия
kijs = [[0, k12],
        [k12, 0]]
print(k12)
eos_kwargs = dict(Tcs=constants.Tcs, Pcs=constants.Pcs, omegas=constants.omegas) #, kijs=kijs
gas = CEOSGas(PRMIX, HeatCapacityGases=properties.HeatCapacityGases, eos_kwargs=eos_kwargs)

# Настройка модели активности
GE = UNIFAC.from_subgroups(chemgroups=constants.UNIFAC_Dortmund_groups, version=1, T=T, xs=zs,
                           interaction_data=DOUFIP2016, subgroups=DOUFSG)
# Настройка модели жидкости с коэффициентами активности
liquid = GibbsExcessLiquid(
    VaporPressures=properties.VaporPressures,
    HeatCapacityGases=properties.HeatCapacityGases,
    VolumeLiquids=properties.VolumeLiquids,
    GibbsExcessModel=GE,
    equilibrium_basis='Psat', caloric_basis='Psat',
    T=T, P=P, zs=zs)

# Создание экземпляра флешера, предполагая только парожидкостное равновесие
flasher = FlashVL(constants, properties, liquid=liquid, gas=gas)

# Построение T-xy диаграммы при заданном давлении P (в барах)
_ = flasher.plot_Txy(P=P, pts=100)

# Построение P-xy диаграммы при заданной температуре T (в Кельвинах)
_ = flasher.plot_Pxy(T=T, pts=100)


# Построение xy диаграммы при заданной температуре T (в Кельвинах)
_ = flasher.plot_xy(T=T, pts=100)

# Расчёт парожидкостно-жидкостного равновесия (VLLE)
liquid2 = GibbsExcessLiquid(
    VaporPressures=properties.VaporPressures,
    HeatCapacityGases=properties.HeatCapacityGases,
    VolumeLiquids=properties.VolumeLiquids,
    GibbsExcessModel=GE,
    equilibrium_basis='Psat', caloric_basis='Psat',
    T=T, P=P, zs=zs)

flasher2 = FlashVLN(constants, properties, liquids=[liquid, liquid2], gas=gas)

# Экспериментальные данные
myT = [334.32, 332.22, 330.15, 328.10, 326.05, 324.00]  ## Температуры для расчётов
x1_exp = [0.000, 0.083, 0.200, 0.370, 0.583, 0.780]  # Экспериментальные мольные доли в жидкости
y1_exp = [0.000, 0.120, 0.270, 0.450, 0.650, 0.810]  # Экспериментальные мольные доли в паре

# Начальные мольные доли компонента 1 для расчёта
# Выбираются между x и y на диаграмме. На первый взгляд, между x1_exp и y1_exp
zs=[0.1, 0.2, 0.7, 0.8, 0.87]

errX = 0;
errY = 0;
x = [0.03, 0.8, 0.94, 1.0, 1.0, 1.0] # данные с сайта vle-calc.com
y = [0.017607, 0.878659, 0.971351, 1.0, 1.0, 1.0]

for i in range(5):
    res = flasher2.flash(T=myT[i], P=P, zs=[zs[i], 1-zs[i]])
    print('При %f K и %f bar присутствует %s фаз(ы)' %(myT[i], P/1e5, res.phase_count))
    if res.VF == 0:
        print("Только жидкость")
    if res.VF > 0:
        print("Состав пара: ")
        print(res.gas.zs)
    if res.VF == 1:  # Только пар
        print("Только пар")
    else:
        print("Состав жидкости 0: ")
        print(res.liquid0.zs)
        errX += abs(res.liquid0.zs[0]-x[i])
        errY += abs(-x[i])
        if res.liquid_count>1:
            print("РАЗДЕЛЕНИЕ ЖИДКИХ ФАЗ")
            print("Состав жидкости 1: ")
            print(res.liquid1.zs)

print(f"абсолютная ошибка х = {errX/5}\nабсолютная ошибка y = {errY/5}");
