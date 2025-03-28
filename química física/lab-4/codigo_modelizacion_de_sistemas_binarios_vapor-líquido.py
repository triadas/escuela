import numpy as np
import matplotlib.pyplot as plt
from scipy.optimize import minimize

#данные 25в
T = 298.15#K
x1_exp = np.array([0.100, 0.300, 0.500, 0.700, 0.900])
y1_exp = np.array([0.311, 0.519, 0.655, 0.705, 0.864])
P_exp = np.array([0.2214, 0.2759, 0.2999, 0.3098, 0.3048])#bar

A1, B1, C1 = 16.13, 2601.92, -56.15
A2, B2, C2 = 18.59, 3626.55, -34.29

#расчет давлений насыщенных паров по Антуана (в мм ртутного ст)
def P_sat(T, A, B, C):
    return np.exp(A - B/(T + C))#мм.рт.ст.

P1_sat_mmHg = P_sat(T, A1, B1, C1)
P2_sat_mmHg = P_sat(T, A2, B2, C2)

#переводим в бары [бар = 750,062 мм ртутного ст]
P1_sat = P1_sat_mmHg / 750.062
P2_sat = P2_sat_mmHg / 750.062

#расчет коэффициентов активности (экспериментальные)
gamma1_exp = y1_exp * P_exp / (P1_sat * x1_exp)
gamma2_exp = (1 - y1_exp) * P_exp / (P2_sat * (1 - x1_exp))

#расчет экспериментальной избыточной энергии Гиббса
R = 8.314  #J/(mol·K)
gE_exp = R * T * (x1_exp * np.log(gamma1_exp) + (1 - x1_exp) * np.log(gamma2_exp))

#модель Вильсона
def wilson_gE(x1, Lambda12, Lambda21):
    x2 = 1 - x1
    term1 = -x1 * np.log(x1 + Lambda12 * x2)
    term2 = -x2 * np.log(x2 + Lambda21 * x1)
    return R * T * (term1 + term2)

#функция для минимизации
def objective(params):
    Lambda12, Lambda21 = params
    gE_wilson = wilson_gE(x1_exp, Lambda12, Lambda21)
    return np.sum(np.abs(gE_wilson - gE_exp))

#оптимизация параметров Вильсона
initial_guess = [0.1, 0.1]
res = minimize(objective, initial_guess, method='Nelder-Mead')
Lambda12_opt, Lambda21_opt = res.x
print(f"Оптимальные параметры Вильсона: Λ12 = {Lambda12_opt:.4f}, Λ21 = {Lambda21_opt:.4f}")

#расчет коэффициентов активности по модели Вильсона
def wilson_gamma(x1, Lambda12, Lambda21):
    x2 = 1 - x1
    ln_gamma1 = (-np.log(x1 + Lambda12 * x2) + \
                x2 * (Lambda12/(x1 + Lambda12*x2) - Lambda21/(x2 + Lambda21*x1)))
    ln_gamma2 = (-np.log(x2 + Lambda21 * x1) - \
                x1 * (Lambda12/(x1 + Lambda12*x2) - Lambda21/(x2 + Lambda21*x1)))
    return np.exp(ln_gamma1), np.exp(ln_gamma2)

#построение P-xy диаграммы
x1_range = np.linspace(0, 1, 100)
gamma1_wilson, gamma2_wilson = wilson_gamma(x1_range, Lambda12_opt, Lambda21_opt)

P_wilson = x1_range * gamma1_wilson * P1_sat + (1 - x1_range) * gamma2_wilson * P2_sat
y1_wilson = x1_range * gamma1_wilson * P1_sat / P_wilson

#графики
plt.figure(figsize=(12, 6))

#P-xy диаграмма
plt.subplot(1, 2, 1)
plt.plot(x1_range, P_wilson, 'b-', label='P(x)')
plt.plot(y1_wilson, P_wilson, 'r-', label='P(y)')
plt.plot(x1_exp, P_exp, 'bo', label='Эксп. P(x)')
plt.plot(y1_exp, P_exp, 'ro', label='Эксп. P(y)')
plt.xlabel('Мольная доля метилацетата')
plt.ylabel('Давление (бар)')
plt.title('P-xy диаграмма при T = 298.15 K')
plt.legend()
plt.grid()

#y-x диаграмма
plt.subplot(1, 2, 2)
plt.plot(x1_range, y1_wilson, 'k-', label='Модель Вильсона')
plt.plot(x1_exp, y1_exp, 'ko', label='Эксперимент')
plt.plot([0, 1], [0, 1], 'g--', label='y = x')
plt.xlabel('Мольная доля метилацетата в жидкости')
plt.ylabel('Мольная доля метилацетата в паре')
plt.title('y-x диаграмма при T = 298.15 K')
plt.legend()
plt.grid()

plt.tight_layout()
plt.show()