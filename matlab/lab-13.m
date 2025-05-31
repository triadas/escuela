%% Задание 1
clc; clearvars; close all;

% Исходные условия
h = 0.1;
x = 0:h:1;
n = length(x);
y1_euler = zeros(1, n); y2_euler = zeros(1, n);
y1_mod_euler = zeros(1, n); y2_mod_euler = zeros(1, n);
y1_rk4 = zeros(1, n); y2_rk4 = zeros(1, n);

% Начальные условия
y1_euler(1) = 1; y2_euler(1) = 1;
y1_mod_euler(1) = 1; y2_mod_euler(1) = 1;
y1_rk4(1) = 1; y2_rk4(1) = 1;

% Функции
f1 = @(x, y1, y2) y1 * exp(-x^2) + x * y2;
f2 = @(x, y1, y2) 3 * x - y1 + 2 * y2;

% Решение методами
for i = 1:n-1
    % Эйлер
    k1_1 = f1(x(i), y1_euler(i), y2_euler(i));
    k1_2 = f2(x(i), y1_euler(i), y2_euler(i));
    y1_euler(i+1) = y1_euler(i) + h * k1_1;
    y2_euler(i+1) = y2_euler(i) + h * k1_2;

    % Модифицированный Эйлер (предиктор-корректор)
    yp1 = y1_mod_euler(i) + h * f1(x(i), y1_mod_euler(i), y2_mod_euler(i));
    yp2 = y2_mod_euler(i) + h * f2(x(i), y1_mod_euler(i), y2_mod_euler(i));
    f1_pred = f1(x(i+1), yp1, yp2);
    f2_pred = f2(x(i+1), yp1, yp2);
    y1_mod_euler(i+1) = y1_mod_euler(i) + h/2 * (f1(x(i), y1_mod_euler(i), y2_mod_euler(i)) + f1_pred);
    y2_mod_euler(i+1) = y2_mod_euler(i) + h/2 * (f2(x(i), y1_mod_euler(i), y2_mod_euler(i)) + f2_pred);

    % Рунге-Кутта 4 порядка
    k1 = f1(x(i), y1_rk4(i), y2_rk4(i));
    l1 = f2(x(i), y1_rk4(i), y2_rk4(i));

    k2 = f1(x(i)+h/2, y1_rk4(i)+h/2*k1, y2_rk4(i)+h/2*l1);
    l2 = f2(x(i)+h/2, y1_rk4(i)+h/2*k1, y2_rk4(i)+h/2*l1);

    k3 = f1(x(i)+h/2, y1_rk4(i)+h/2*k2, y2_rk4(i)+h/2*l2);
    l3 = f2(x(i)+h/2, y1_rk4(i)+h/2*k2, y2_rk4(i)+h/2*l2);

    k4 = f1(x(i)+h, y1_rk4(i)+h*k3, y2_rk4(i)+h*l3);
    l4 = f2(x(i)+h, y1_rk4(i)+h*k3, y2_rk4(i)+h*l3);

    y1_rk4(i+1) = y1_rk4(i) + h/6*(k1 + 2*k2 + 2*k3 + k4);
    y2_rk4(i+1) = y2_rk4(i) + h/6*(l1 + 2*l2 + 2*l3 + l4);
end

% Решение стандартной функцией ode45
f_ode = @(x, y) [y(1)*exp(-x^2) + x*y(2); 3*x - y(1) + 2*y(2)];
[x_ode, y_ode] = ode45(f_ode, x, [1 1]);

% График решений
figure;
plot(x, y1_euler, 'r-o', 'DisplayName', 'Эйлер y1'); hold on;
plot(x, y1_mod_euler, 'g-o', 'DisplayName', 'Мод. Эйлер y1');
plot(x, y1_rk4, 'b-o', 'DisplayName', 'РК4 y1');
plot(x_ode, y_ode(:,1), 'k--', 'DisplayName', 'ode45 y1');
legend('Location','best');
title('Сравнение решений y1'); grid on;
xlabel('x'); ylabel('y1');

%% Задание 2
clc; clearvars -except x y1_euler y1_mod_euler y1_rk4 x_ode y_ode;

h = 0.1;
x = 0:h:3;
n = length(x);
y1_exp = zeros(1, n); y2_exp = zeros(1, n);
y1_imp = zeros(1, n); y2_imp = zeros(1, n);

% Начальные условия
y1_exp(1) = 1; y2_exp(1) = 1;
y1_imp(1) = 1; y2_imp(1) = 1;

f1 = @(x, y1, y2) y1 * exp(x^2) + x * y2;
f2 = @(x, y1, y2) 3 * x - y1 + 2 * y2;

for i = 1:n-1
    % Явный Эйлер
    y1_exp(i+1) = y1_exp(i) + h * f1(x(i), y1_exp(i), y2_exp(i));
    y2_exp(i+1) = y2_exp(i) + h * f2(x(i), y1_exp(i), y2_exp(i));

    % Неявный Эйлер (один шаг Ньютона)
    % Предсказка
    yp1 = y1_imp(i);
    yp2 = y2_imp(i);
    for iter = 1:3
        F1 = y1_imp(i) + h*f1(x(i+1), yp1, yp2) - yp1;
        F2 = y2_imp(i) + h*f2(x(i+1), yp1, yp2) - yp2;
        J = [1 - h*exp(x(i+1)^2), -h*x(i+1); h, 1 - 2*h];
        delta = -J \ [F1; F2];
        yp1 = yp1 + delta(1);
        yp2 = yp2 + delta(2);
    end
    y1_imp(i+1) = yp1;
    y2_imp(i+1) = yp2;
end

% Решение стандартной функцией ode45
f_ode = @(x, y) [y(1)*exp(x^2) + x*y(2); 3*x - y(1) + 2*y(2)];
[x_ode, y_ode] = ode45(f_ode, x, [1 1]);

% График решений
figure;
plot(x, y1_exp, 'r-o', 'DisplayName', 'Явный Эйлер y1'); hold on;
plot(x, y1_imp, 'b-o', 'DisplayName', 'Неявный Эйлер y1');
plot(x_ode, y_ode(:,1), 'k--', 'DisplayName', 'ode45 y1');
legend('Location','best');
title('Сравнение решений задачи Коши (Задание 2)');
xlabel('x'); ylabel('y1'); grid on;
