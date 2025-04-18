% opción 22
%% número 1 (gráficos)
clc, clearvars, close all;
% Система уравнений:
% 2x + y^3 = 3
% 2x^3 + y = 3
x = linspace(-10, 1.5, 10000);
y1 = ((3-2*x)).^((1/3));
y2 = 3 - 2*x.^3;

plot(x,y1)
title('Графики функций y = y(x)'), xlabel('x'), ylabel('y'), grid on;
hold on; 
plot(x,y2)
ylim([-5 15]);
xlim([-4 2]);

function f = fun(x)
    f(1) = 2*x(1) + x(2)^3 - 3;
    f(2) = 2*x(1)^3 + x(2) - 3;
end

x = [1 1];
[xr, fr, exitflag] = fsolve(@fun, x);

plot(xr(1), xr(2), 'k*')
legend('Y1', 'Y2', 'desicion'); 


%% número 2 (gráficos)

lambda = [-1/3; -1/2];

clc, clearvars, close all;

% Правильные уравнения для графиков
x = linspace(-2, 2, 1000);  % Изменил диапазон для лучшей визуализации
y1 = (3 - 2*x).^(1/3);      % y^3 = 3 - 2x
y2 = 3 - 2*x.^3;            % y = 3 - 2x^3

plot(x, y1, 'b')
hold on;
plot(x, y2, 'r')
title('Графики функций y = y(x)'), xlabel('x'), ylabel('y'), grid on;
ylim([-5 5]);
xlim([-2 2]);

% Функция для fsolve (должна соответствовать графикам)
function f = func(x)
    f = [2*x(1) + x(2)^3 - 3;   % 2x + y^3 = 3 (как в графике y1)
         2*x(1)^3 + x(2) - 3];   % 2x^3 + y = 3 (как в графике y2)
end

% Находим решение
initial_guess = [1; 1];
xr = fsolve(@func, initial_guess);

% Отображаем решение
plot(xr(1), xr(2), 'ko')
legend('y1 = (3-2x)^{1/3}', 'y2 = 3-2x^3', 'Решение');











