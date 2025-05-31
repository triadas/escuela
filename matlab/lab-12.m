%% Задание 1: Проверка, является ли функция решением ОДУ
clc; clearvars; close all;

syms x y(x)

% Заданное уравнение
ode = x^3*(diff(y, x) - x) == y^2;

% Функция y = x^2 / ln(x) * (1 - ln(x))
y1 = (x^2 / log(x)) * (1 - log(x));
lhs1 = simplify(subs(x^3*(diff(y,x)-x), y, y1));
rhs1 = simplify(subs(y^2, y, y1));
is_solution1 = simplify(lhs1 - rhs1) == 0;

% Функция y = x^2
y2 = x^2;
lhs2 = simplify(subs(x^3*(diff(y,x)-x), y, y2));
rhs2 = simplify(subs(y^2, y, y2));
is_solution2 = simplify(lhs2 - rhs2) == 0;

fprintf('Является ли y = x^2 / ln(x) * (1 - ln(x)) решением: %d\n', is_solution1);
fprintf('Является ли y = x^2 решением: %d\n', is_solution2);

%% Задание 2А: Метод Эйлера
f = @(t, y) cos(t) - y;
y0 = 0.5;
t0 = 0;
t_end = 0.1;

% Метод Эйлера
function [t, y] = euler_method(f, t0, t_end, y0, h)
    t = t0:h:t_end;
    y = zeros(size(t));
    y(1) = y0;
    for i = 1:length(t)-1
        y(i+1) = y(i) + h * f(t(i), y(i));
    end
end

[t1, y1] = euler_method(f, t0, t_end, y0, 0.1);
[t2, y2] = euler_method(f, t0, t_end, y0, 0.02);

%% Задание 2Б: Метод Рунге-Кутта 4 порядка
function [t, y] = rk4_method(f, t0, t_end, y0, h)
    t = t0:h:t_end;
    y = zeros(size(t));
    y(1) = y0;
    for i = 1:length(t)-1
        k1 = f(t(i), y(i));
        k2 = f(t(i)+h/2, y(i)+h/2*k1);
        k3 = f(t(i)+h/2, y(i)+h/2*k2);
        k4 = f(t(i)+h, y(i)+h*k3);
        y(i+1) = y(i) + h/6 * (k1 + 2*k2 + 2*k3 + k4);
    end
end

[t3, y3] = rk4_method(f, t0, t_end, y0, 0.1);
[t4, y4] = rk4_method(f, t0, t_end, y0, 0.02);

% Стандартный MATLAB-метод
[t5, y5] = ode45(f, [t0 t_end], y0);

% Интерполяция для сравнения на t = 0.1
Ytrue = interp1(t5, y5, t_end);
abs_err_euler_h1 = abs(y1(end) - Ytrue);
abs_err_euler_h2 = abs(y2(end) - Ytrue);
abs_err_rk4_h1 = abs(y3(end) - Ytrue);
abs_err_rk4_h2 = abs(y4(end) - Ytrue);

% Runge-погрешности
Runge_euler = abs(y1(end) - y2(end)) / (2^1 - 1);     % порядок 1
Runge_rk4 = abs(y3(end) - y4(end)) / (2^4 - 1);       % порядок 4

%% График решений
figure;
plot(t1, y1, 'ro-', 'DisplayName', 'Эйлер h=0.1');
hold on;
plot(t2, y2, 'r--', 'DisplayName', 'Эйлер h=0.02');
plot(t3, y3, 'bo-', 'DisplayName', 'РК4 h=0.1');
plot(t4, y4, 'b--', 'DisplayName', 'РК4 h=0.02');
plot(t5, y5, 'k-', 'LineWidth', 1.5, 'DisplayName', 'ode45');
legend;
xlabel('t'); ylabel('y');
title('Сравнение методов решения задачи Коши');

%% График абсолютных погрешностей
err_t = linspace(t0, t_end, 100);
[~, y_ode] = ode45(f, [t0 t_end], y0);
y_ref = interp1(t5, y_ode, err_t);

[~, y1_fine] = euler_method(f, t0, t_end, y0, 0.1);
[~, y2_fine] = euler_method(f, t0, t_end, y0, 0.02);
[~, y3_fine] = rk4_method(f, t0, t_end, y0, 0.1);
[~, y4_fine] = rk4_method(f, t0, t_end, y0, 0.02);

y1_interp = interp1(t1, y1_fine, err_t);
y2_interp = interp1(t2, y2_fine, err_t);
y3_interp = interp1(t3, y3_fine, err_t);
y4_interp = interp1(t4, y4_fine, err_t);

err_euler_01 = abs(y1_interp - y_ref);
err_euler_002 = abs(y2_interp - y_ref);
err_rk4_01 = abs(y3_interp - y_ref);
err_rk4_002 = abs(y4_interp - y_ref);

figure;
plot(err_t, err_euler_01, 'r-', 'DisplayName', 'Эйлер h=0.1');
hold on;
plot(err_t, err_euler_002, 'r--', 'DisplayName', 'Эйлер h=0.02');
plot(err_t, err_rk4_01, 'b-', 'DisplayName', 'РК4 h=0.1');
plot(err_t, err_rk4_002, 'b--', 'DisplayName', 'РК4 h=0.02');
legend;
xlabel('t');
ylabel('Абсолютная погрешность');
title('Погрешности методов Эйлера и Рунге-Кутта');
grid on;

%% Вывод результатов
fprintf('\n=== Сравнение точности (t = %.2f) ===\n', t_end);
fprintf('Эйлер h=0.1:  abs err = %.6e, Runge = %.6e\n', abs_err_euler_h1, Runge_euler);
fprintf('Эйлер h=0.02: abs err = %.6e\n', abs_err_euler_h2);
fprintf('РК4 h=0.1:    abs err = %.6e, Runge = %.6e\n', abs_err_rk4_h1, Runge_rk4);
fprintf('РК4 h=0.02:   abs err = %.6e\n', abs_err_rk4_h2);
