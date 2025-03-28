from scipy.optimize import minimize
import numpy as np
import math

def saturated_pressure(subst, T):
    """Расчёт P₀ при температуре системы T"""
    if subst == "methyl_acetate":
        A, B, C = 16.13, 2601.92, -56.15
    elif subst == "methanol":
        A, B, C = 18.59, 3626.55, -34.29
    return math.exp(A - B/(T + C))  # Используем T системы!

# Правильный вызов:
P1_0 = saturated_pressure("methyl_acetate", T=333.15)  # T системы!
P2_0 = saturated_pressure("methanol", T=333.15)
T = 333.15
R=8.314
x1=[0.7, 0.6, 0.5, 0.4, 0.3]
y1=[0.8, 0.5, 0.43, 0.32, 0.22]
P=[1,2,3,4,5]
gam1 = [0.0 for x in range(5)]
gam2 = [0.0 for x in range(5)]
arr1=[]
for i in range(0,5):
  gam1[i]=y1[i]*P[i]/(P1_0*x1[i])
  gam2[i]=(1-y1[i])*P[i]/(P2_0*(1-x1[i]))
  arr1.append(R * T * (math.log(gam1[i])*x1[i] + math.log(gam2[i])*(1-x1[i])))
print("γ₁:", gam1)  # Должны быть близки к 1 для идеальных систем
print("γ₂:", gam2)
def func(x,x1=x1,ge_exp=arr1):
  A12, A21 = x
  sum=0.0
  for i in range(0,5):
    sum+=abs((-R*T*(x1[i]*math.log(x1[i]+A12*(1-x1[i]))+(1-x1[i])*math.log((1-x1[i])+A21*x1[i])))-arr1[i])
  return sum

res = minimize(func, x0 = [1.0,1.0], method='Nelder-Mead', tol=1e-2)
print(res.message)
print(f"{res.x}\n")
x = res.x
for i in range(0,5):
  print(f"Экспериметальная энергия Гиббса {arr1[i]}")
  print(f"рассчитанная энергия Гиббса {((-R*T*(x1[i]*math.log(x1[i]+x[0]*(1-x1[i]))+(1-x1[i])*math.log((1-x1[i])+x[1]*x1[i])))-arr1[i])}\n")
