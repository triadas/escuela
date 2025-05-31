%% Задание 1
clc; clearvars; close all;

x_exp = [0.1, 1.0, 1.8, 2.5, 3.6, 4.5, 5.2, 6.5, 8.0];
y_exp = [-0.8, -0.6, -0.3, 0.0, 0.4, 0.7, 0.8, 0.5, -0.2];

x_nodal = [2.87, 3.39];

degree = 3;

dy1 = zeros(size(x_nodal));
dy2 = zeros(size(x_nodal));

p = polyfit(x_exp, y_exp, degree);
dp = polyder(p);
d2p = polyder(dp);

for i = 1:length(x_nodal)
    xi = x_nodal(i);
    dy1(i) = polyval(dp, xi);
    dy2(i) = polyval(d2p, xi);
end

xx = linspace(min(x_exp), max(x_exp), 300);
yy = polyval(p, xx);
figure;
plot(x_exp, y_exp, 'r.', 'MarkerSize', 8);
hold on;
plot(xx, yy, 'm-');
title('Аппроксимация функции');
xlabel('x'); ylabel('y');

h_avg = mean(diff(x_exp));
n = degree;
delta_4 = diff(y_exp, 4);
f5_est = delta_4(1) / h_avg^5;

error_est = f5_est / factorial(n+1) * h_avg^n;
disp('--- Задание 1 ---');
disp(['Первая производная в x = ', num2str(x_nodal(1)), ': ', num2str(dy1(1))]);
disp(['Вторая производная в x = ', num2str(x_nodal(1)), ': ', num2str(dy2(1))]);
disp(['Оценка погрешности 1-й производной: ', num2str(error_est)]);

%% Задание 2
clc; clearvars; close all;

x_exp = [0.1, 1.0, 1.8, 2.5, 3.6, 4.5, 5.2, 6.5, 8.0];
y_exp = [-0.8, -0.6, -0.3, 0.0, 0.4, 0.7, 0.8, 0.5, -0.2];

x0 = 3.6;
i0 = find(x_exp == x0);

poly_deg = length(x_exp) - 1;
p_interp = polyfit(x_exp, y_exp, poly_deg);
dp_interp = polyder(p_interp);
d2p_interp = polyder(dp_interp);

true_f1 = polyval(dp_interp, x0);
true_f2 = polyval(d2p_interp, x0);

h = x_exp(i0) - x_exp(i0-1);
f1_simple = (y_exp(i0+1) - y_exp(i0-1)) / (2*h);
f2_simple = (y_exp(i0+1) - 2*y_exp(i0) + y_exp(i0-1)) / h^2;

idx = i0-2:i0+2;
x_local = x_exp(idx);
y_local = y_exp(idx);
p_local = polyfit(x_local, y_local, 4);
dp_local = polyder(p_local);
d2p_local = polyder(dp_local);
f1_poly = polyval(dp_local, x0);
f2_poly = polyval(d2p_local, x0);

err_f1_simple = abs(f1_simple - true_f1);
err_f1_poly = abs(f1_poly - true_f1);
err_f2_simple = abs(f2_simple - true_f2);
err_f2_poly = abs(f2_poly - true_f2);

disp('--- Задание 2: производные в узле x = 3.6 ---');
fprintf('Точная (интерпол. полином) 1-я производная: %.6f\n', true_f1);
fprintf('Простая 1-я производная: %.6f (ошибка: %.6e)\n', f1_simple, err_f1_simple);
fprintf('Многоточечная 1-я производная: %.6f (ошибка: %.6e)\n', f1_poly, err_f1_poly);
fprintf('Точная (интерпол. полином) 2-я производная: %.6f\n', true_f2);
fprintf('Простая 2-я производная: %.6f (ошибка: %.6e)\n', f2_simple, err_f2_simple);
fprintf('Многоточечная 2-я производная: %.6f (ошибка: %.6e)\n', f2_poly, err_f2_poly);

figure;
bar([err_f1_simple, err_f1_poly]);
set(gca, 'XTickLabel', {'Простая', 'Многоточечная'});
ylabel('Ошибка');
title('Погрешности 1-й производной');

figure;
bar([err_f2_simple, err_f2_poly]);
set(gca, 'XTickLabel', {'Простая', 'Многоточечная'});
ylabel('Ошибка');
title('Погрешности 2-й производной');

%% Задание 3
x0 = 3.6;
h_values = 0.1:0.1:1.0;
errors_fd = zeros(size(h_values));

for i = 1:length(h_values)
    h = h_values(i);
    f1_fd = (polyval(p_interp, x0 + h) - polyval(p_interp, x0 - h)) / (2*h);
    f1_true = polyval(dp_interp, x0);
    errors_fd(i) = abs(f1_fd - f1_true);
end

figure;
plot(h_values, errors_fd, 'r-o', 'LineWidth', 1.5);
xlabel('Шаг h'); ylabel('Погрешность');
title('Влияние шага на точность 1-й производной (центральная разность)');
grid on;
