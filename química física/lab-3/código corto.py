import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from keras.models import load_model

# Функции нормализации и денормализации
def normalize_data(X, minsX, maxsX):
    return (X - minsX) / (maxsX - minsX) * 0.9 + 0.1

def denormalize_data(X, minsX, maxsX):
    return ((X - 0.1) / 0.9) * (maxsX - minsX) + minsX

# Загрузка данных
data = pd.read_csv("datos_de_amoniaco.csv")
data = data[(data["GL"] == 0)]

# Выбираем нужные столбцы
X = data[["Temperature", "Pressure"]].to_numpy()
y = data[["Thermal_conductivity"]].to_numpy()

# Запоминаем минимумы и максимумы для денормализации
minsX, maxsX = X.min(axis=0), X.max(axis=0)
minsy, maxsy = y.min(axis=0), y.max(axis=0)

# Нормализация данных
X = normalize_data(X, minsX, maxsX)
y = normalize_data(y, minsy, maxsy)

# Загрузка модели
model = load_model('Lab2_AA_Amoniaco.keras')
print("Модель загружена!")

# Предсказание на всех входных данных
predicted_y = model.predict(X)

# Денормализация данных
dnX = denormalize_data(X, minsX, maxsX)
dny = denormalize_data(y, minsy, maxsy)
predicted_y = denormalize_data(predicted_y, minsy, maxsy)

# Функция для вычисления MAE
def mae(y_exp, y_pred):
    return np.mean(np.abs(y_exp - y_pred))

# Вычисление ошибки
print('Conductividad térmica MAE:', mae(dny[:, 0], predicted_y[:, 0]))

# Построение графика
plt.figure(figsize=(6, 6))
plt.axline((0, 0), slope=1, color='r', linestyle='--')  # Линия y = x
plt.scatter(dny, predicted_y, marker='.', color='blue', alpha=0.5)  # Точки предсказания
plt.xlabel("Истинные значения теплопроводности")
plt.ylabel("Предсказанные значения теплопроводности")
plt.title("Сравнение предсказанных и реальных значений")
plt.grid(True)
plt.show()

for p in 1,5,10,5000,10000:
  try:
    data = pd.read_csv("datos_de_amoniaco.csv")
    data = data[(data["GL"] == 0) & (data["Pressure"] == p)]
    X = data[["Temperature", "Pressure"]].to_numpy()
    y = data[["Thermal_conductivity"]].to_numpy()
    x_arr = X.tolist()
    y_arr = y.tolist()
    a, temp = zip(*x_arr) 
    a = list(a)
    b = y_arr

    print(*x_arr, " + ", *y_arr, " + ",  *a, " + ",  *b)

    zipped = list(zip(a, b))
    zipped.sort(key=lambda pair: pair[0])
    a, b = zip(*zipped)
    c = []
    for i in a:
      c.append(int(normalize_data(model.predict(np.array([[i,p]]))[0][0], minsy, maxsy)))
    print("Массив С:")
    print(*c)
    

    plt.plot(a, b, color = "#493434", linestyle = "--", label = "exp data", marker = "o")
    plt.plot(a, c, color = "black", linestyle = "-", label = "model data", marker = "x")

    plt.title(f"Зависимость Теплопроводности от температуры при давлении в {p} бар")
    plt.xlabel("K")
    plt.ylabel("Вт/(Вт*K)")
    plt.legend()
    plt.show()

  except Exception as e:
    print(f"Произошла ошибка: {e}")
    continue

test_point = np.array([[350.0, 1.0]])  # Задайте точку для давления 1 бар
predicted_single = model.predict(test_point)
predicted_single = denormalize_data(predicted_single[0][0], minsy, maxsy)
print("Предсказание для одной точки:", predicted_single)


