% opción 22
%% número 1 (графики и решение fsolve)
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


%% número 3 (решение МПИ)

clc, clearvars, close all;
 
lambda = [-1/3; -1/2];
function f = func(x)
    f(1) = x(1) - 1/3*(2*x(1) + x(2)^3 - 3);   % 2x + y^3 = 3 (как в графике y1)
    f(2) = x(2) - 1/2 * (2*x(1)^3 + x(2) - 3);   % 2x^3 + y = 3 (как в графике y2)
end

x = [1 1 1];
maxIter = 2;
for i = 1:maxIter
    R = subs(subs(jacobian(f, x),x1,x(1)), x2, x(2));
end
      
%%
clc, clearvars, close all;
 
phi = @(x) [
    (3 - x(2)^3)/2;
    (3 - 2*x(1)^3)/1
];
x0 = [0.5; 0.5];
e = 1e-3;
x = x0;
maxIter = 100; 
iter = 0;
R = 1; 
   
f = [x1^2 + x2;
     x2*exp(x3);
     x1 + x3^2];

while R == 1 && iter < maxIter
    x_old = x;
    x = phi(x_old); 

    delta = x - x_old;
    if max(delta) < e;
        fprintf('Достигнута точнсть на %d итерации, x:', iter);
        disp(x);
        break
    end

    J = jacobian(phi, x); 
    J_numeric = subs(J, {x1, x2}, {x(1), x(2), x(3)});
    J_numeric = double(J_numeric);
    if sum(J_numeric(1,:)) > 1 || sum(J_numeric(2,:)) > 1 || sum(J_numeric(3,:)) > 1
        fprintf('Условие сходиммости не выполняется на %d итерации, x:', iter);
        disp(x);
        break
    end
    iter = iter + 1;
end

    if R == 1
        warning('Достигнуто максимальное число итераций без достижения точности!');
    end

fprintf('\nРешение найдено за %d итераций:\n', iter);
fprintf('x1 = %.8f\nx2 = %.8f\n', x(1), x(2));












