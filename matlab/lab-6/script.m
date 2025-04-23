% вариант 22

%% номер 1 (Построение графиков и решение fsolve)
clc, clearvars, close all;

f = @(x) [2*x(1) + x(2)^3 - 3; 2*x(1)^3 + x(2) - 3];

y1 = linspace(-10,10, 100000);
x1 = linspace(-10,10, 100000);
x = (3 - y1.^3)/2;
y = 3 - 2*x1.^3; 

figure(1);
plot(x,y1); hold on;
plot(x1,y); title("Зависимости  y = y(x)"), xlabel('x'), ylabel('y'), grid on, xline(0,'k'), yline(0,'k'), xticks(-10:1:10), yticks(-10:1:10),
xlim([-10 10]), ylim([-10 10]);

x = fsolve(f,[1 1]);
plot(x(1), x(2), '*k');


%% номер 2 (решение методом ПИ)
clc, clearvars, close all;


e = 1e-3;
x0 = [0.1 0.1];
x = x0;
R = 1;

phi = @(x) [((3 - x(2))/2)^(1/3), (3 - 2*x(1))^(1/3)];

syms x1 x2;
phi_sym = [((3 - x2)/2)^(1/3), (3 - 2*x1)^(1/3)];
J = jacobian(phi_sym, [x1 x2]);

maxIter = 10;
i = 0;
while(i ~= maxIter)
    xOld = x;
    x = phi(x);

    Jr = double(subs(J, [x1, x2], x));
    R = sum(abs(Jr(1,:)))<1 || sum(abs(Jr(2,:)))<1;
    if R == 0
        fprintf('Условия сх не вып-ся на %d итерации, x:', i+1);
        disp(x);
        break;
    end

    if max(abs(x - xOld))<e
        fprintf('Достигнута точность эпсилон на %d итерации, x:', i+1);
        % x - xOld
        disp(x);
        break;
    end

    i = i + 1;
end
if (i == maxIter)
    fprintf('После iterMax = %d точность эпсилон не была достигнута, x:', i+1);
    disp(x);
end

%% номер 3 (решение методом ПИ зейдаля)
clc, clearvars, close all;


e = 1e-3;
x0 = [0.1 0.1];
x = x0;
R = 1;

phi_1 = @(x) ((3 - x)/2)^(1/3);
phi_2 = @(x) (3 - 2*x)^(1/3);

syms x1 x2;
phi_sym = [((3 - x2)/2)^(1/3), (3 - 2*x1)^(1/3)];
J = jacobian(phi_sym, [x1 x2]);

maxIter = 10;
i = 0;
while(i ~= maxIter)
    xOld = x;
    x(1) = phi_1(x(2));
    x(2) = phi_2(x(1));

    Jr = double(subs(J, [x1, x2], x));
    R = sum(abs(Jr(1,:)))<1 || sum(abs(Jr(2,:)))<1;
    if R == 0
        fprintf('Условия сх не вып-ся на %d итерации, x:', i+1);
        disp(x);
        break;
    end

    if max(abs(x - xOld))<e
        fprintf('Достигнута точность эпсилон на %d итерации, x:', i+1);
        % x - xOld
        disp(x);
        break;
    end

    i = i + 1;
end
if (i == maxIter)
    fprintf('После iterMax = %d точность эпсилон не была достигнута, x:', i+1);
    disp(x);
end

%% номер 4 (решение методом ньютона)
clc, clearvars, close all;

f = @(x) [2*x(1) + x(2)^3 - 3;
          2*x(1)^3 + x(2) - 3];
J = @(x) [2, 3*x(2)^2;
          6*x(1)^2, 1];

x = [0.1; 0.1];
eps = 1e-6;

maxIter = 20;
for k = 1:maxIter
    % J * h = -f 
    h = -J(x) \ f(x);
    x = x + h;
    fprintf("%4d     | %10.6f  %10.6f |  %e\n", k, x(1), x(2), norm(h));

    x1_plot(k) = x(1,1);
    x2_plot(k) = x(2,1);
    h_pot(k) = norm(h);

    if norm(h, inf) < eps
        break;
    end
end
fprintf("\nРешение: x1 = %.6f, x2 = %.6f\n", x(1), x(2));

plot(1:k, x1_plot, 'b'), hold on;
plot(1:k, x2_plot, 'm')
title('xi = xi(k)'), xlabel('k'), ylabel('x'), xline(0), yline(0), xticks(1:8), yticks(-5:(5+5)/60:5), legend('x1', 'x2'), grid on;



