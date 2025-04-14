# -*- coding: utf-8 -*-
#Lab 5. Peng-Robinson.ipynb

# Автоматически сгенерировано Colaboratory.

# Оригинальный файл находится по адресу
#    https://colab.research.google.com/drive/1NJy0Kah6lAUbd9sxgIJ2Fz61VvGe_S-E
#

!pip install thermo

from thermo import ChemicalConstantsPackage, CEOSGas, CEOSLiquid, PRMIX, FlashVL, FlashVLN, FlashPureVLS
from thermo.interaction_parameters import IPDB

# Загрузка констант и свойств
constants, properties = ChemicalConstantsPackage.from_IDs(['acetone', 'chloroform'])

# Объекты инициализируются при заданных условиях
T = 333.15 # K
P = 1e5 # 1 бар
zs = [.5, .5]

# Использование уравнения Пенга-Робинсона как для паровой, так и для жидкой фаз
k12 = -0.2477
kijs = [[0, k12],
        [k12, 0]]
print(k12)
eos_kwargs = dict(Tcs=constants.Tcs, Pcs=constants.Pcs, omegas=constants.omegas, kijs=kijs)
gas = CEOSGas(PRMIX, eos_kwargs, HeatCapacityGases=properties.HeatCapacityGases, T=T, P=P, zs=zs)
liquid = CEOSLiquid(PRMIX, eos_kwargs, HeatCapacityGases=properties.HeatCapacityGases, T=T, P=P, zs=zs)
#gas = CEOSGas(PRMIX, eos_kwargs=eos_kwargs)
#liquid = CEOSLiquid(PRMIX, eos_kwargs=eos_kwargs)

# Создание экземпляра флешера, предполагая только парожидкостное равновесие
flasher = FlashVL(constants, properties, liquid=liquid, gas=gas)

# Построение T-xy диаграммы при заданном давлении (в барах)
_ = flasher.plot_Txy(P=P, pts=100)

# Построение P-xy диаграммы при заданной температуре (в Кельвинах)
_ = flasher.plot_Pxy(T=T, pts=100)

# Построение xy диаграммы при заданной температуре (в Кельвинах)
_ = flasher.plot_xy(T=T, pts=100)

# Расчёт парожидкостно-жидкостного равновесия (VLLE)
liquid2 = CEOSLiquid(PRMIX, eos_kwargs, HeatCapacityGases=properties.HeatCapacityGases, T=T, P=P, zs=zs)
flasher2 = FlashVLN(constants, properties, liquids=[liquid, liquid2], gas=gas)

# Экспериментальные данные
myT = [334.322, 336.664, 337.255, 337.115, 335.794, 333.611, 331.904, 330.681, 329.99, 329.65, 329.314]  # Температуры (K)  
x1_exp = [0.001, 0.2, 0.3, 0.45, 0.6, 0.75, 0.85, 0.92, 0.96, 0.98, 1.0]  # Мольные доли в жидкости  
y1_exp = [0.000549, 0.163989, 0.282233, 0.482205, 0.676384, 0.835673, 0.916131, 0.860361, 0.881539, 0.891095, 1.0]  # Мольные доли в паре  

# Начальные мольные доли компонента 1 для расчёта
# Выбираются между x и y на диаграмме. На первый взгляд, между x1_exp и y1_exp
zs = [0.1, 0.2, 0.7, 0.9, 0.97]

for i in range(5):
	res = flasher2.flash(T=myT[i], P=P, zs=[zs[i], 1-zs[i]])
	print('Присутствует %s фаз(ы) при %f K и %f бар' %(res.phase_count, myT[i], P/1e5))
	if res.VF == 0:
		print("Только жидкость")
	if res.VF > 0:
		print("x: ")
		print(res.gas.zs)
	if res.VF == 1:  # Есть только пар
		print("Только пар")
	else:
		print("Жидкость 0: ")
		print(res.liquid0.zs)
		if res.liquid_count > 1:
			print("РАЗДЕЛЕНИЕ ЖИДКИХ ФАЗ")
			print("Жидкость 1: ")
			print(res.liquid1.zs)
