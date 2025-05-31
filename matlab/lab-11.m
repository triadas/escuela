%% Задание 1. Оптимизация соотношения диаметра и высоты цилиндра
clc; clearvars; close all;

V = 1600;
k1 = 0.41;
k2 = 1;
f = @(d) k1 * (pi*d.^2)/4 + k2 * (pi*d.^2)/4 + pi*d.*(4*V./(pi*d.^2));
fplot(f, [5, 25]); hold on;
xlabel('Диаметр d');
ylabel('Теплопотери Q(d)');
title('Функция теплопотерь');

% Метод золотого сечения
a = 5; b = 25; eps = 1e-4;
phi = (1 + sqrt(5)) / 2;
iter = 0;
while abs(b - a) > eps
    iter = iter + 1;
    x1 = b - (b - a)/phi;
    x2 = a + (b - a)/phi;
    if f(x1) < f(x2)
        b = x2;
    else
        a = x1;
    end
end
d_golden = (a + b)/2;
plot(d_golden, f(d_golden), 'ro', 'DisplayName', 'Golden Section');

% Метод парабол
x0 = 10; x1 = 15; x2 = 20;
eps = 1e-4;
while true
    f0 = f(x0); f1 = f(x1); f2 = f(x2);
    numerator = (x1 - x0)^2 * (f1 - f2) - (x1 - x2)^2 * (f1 - f0);
    denominator = 2*((x1 - x0)*(f1 - f2) - (x1 - x2)*(f1 - f0));
    x_min = x1 - numerator / denominator;
    if abs(x_min - x1) < eps
        break;
    end
    x0 = x1; x1 = x2; x2 = x_min;
end
d_parabola = x_min;
plot(d_parabola, f(d_parabola), 'go', 'DisplayName', 'Parabolic');

% Метод Ньютона
syms d
Q = k1*pi*d^2/4 + k2*pi*d^2/4 + pi*d*(4*V/(pi*d^2));
Q1 = diff(Q, d);
Q2 = diff(Q1, d);
d_val = 10;
for i = 1:20
    d_new = double(d_val - subs(Q1, d, d_val)/subs(Q2, d, d_val));
    if abs(d_new - d_val) < eps
        break;
    end
    d_val = d_new;
end
d_newton = d_val;
plot(d_newton, f(d_newton), 'bo', 'DisplayName', 'Newton');
legend;

fprintf('Золотое сечение: d = %.5f, Q = %.5f\n', d_golden, f(d_golden));
fprintf('Метод парабол: d = %.5f, Q = %.5f\n', d_parabola, f(d_parabola));
fprintf('Метод Ньютона: d = %.5f, Q = %.5f\n', d_newton, f(d_newton));

% Использование стандартной функции
fun = @(d) f(d);
opts = optimset('Display','off');
[d_fmin, Q_fmin, exitflag, output] = fminbnd(fun, 5, 25, opts);
fprintf('fminbnd: d = %.5f, Q = %.5f, exitflag = %d\n', d_fmin, Q_fmin, exitflag);

%% Задание 2. Метод градиентного спуска
clc;

Q = @(x1,x2) 4*(x1 - x2).^2 + (x1 + x2).^2;
gradQ = @(x1,x2) [8*(x1 - x2) + 2*(x1 + x2);
                  -8*(x1 - x2) + 2*(x1 + x2)];

x = [-5; 5];
alpha = 0.05;
eps = 1e-4;
trajectory = x;
while true
    g = gradQ(x(1), x(2));
    x_new = x - alpha * g;
    if norm(x_new - x) < eps
        break;
    end
    x = x_new;
    trajectory(:,end+1) = x;
end

[X1, X2] = meshgrid(-10:0.5:10, -10:0.5:10);
Z = Q(X1, X2);
figure;
contour(X1, X2, Z, 50); hold on;
plot(trajectory(1,:), trajectory(2,:), 'r-o', 'LineWidth', 1.5);
xlabel('x_1'); ylabel('x_2'); title('Градиентный спуск');

fprintf('Градиентный спуск минимум в: x1 = %.5f, x2 = %.5f\n', x(1), x(2));

% Стандартная функция
fun = @(x) Q(x(1), x(2));
[x_opt, fval, exitflag, output] = fminsearch(fun, [-5,5]);
fprintf('fminsearch: x = [%.5f, %.5f], Q = %.5f, exitflag = %d\n', x_opt(1), x_opt(2), fval, exitflag);
