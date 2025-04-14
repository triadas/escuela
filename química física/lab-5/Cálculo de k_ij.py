import numpy as np
from scipy.optimize import minimize

# Данные (пример)
myT = np.array([334.322, 336.664, 337.255, 337.115, 335.794, 333.611, 331.904, 330.681, 329.99, 329.65, 329.314])
x1_exp = np.array([0.001, 0.2, 0.3, 0.45, 0.6, 0.75, 0.85, 0.92, 0.96, 0.98, 1.0])
y1_exp = np.array([0.000549, 0.163989, 0.282233, 0.482205, 0.676384, 0.835673, 0.916131, 0.860361, 0.881539, 0.891095, 1.0])

def calculate_y1(kij, T, x1):
    y1_calc = x1 * np.exp(kij * (1 - x1))  
    return y1_calc

def error(kij):
    y1_calc = calculate_y1(kij, myT, x1_exp)
    return np.sum((y1_exp - y1_calc)**2)

# Оптимизация
result = minimize(error, x0=0.0, bounds=[(-1, 1)], method='L-BFGS-B')
optimal_kij = result.x[0]
print(f"Оптимальное kij = {optimal_kij:.4f}")