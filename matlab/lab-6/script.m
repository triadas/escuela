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
x0 = [-0.3 -0.3];
x = x0;
R = 1;

phi = @(x) [(3 - x(2)^3)/2, 3 - 2*x(1)^3];

syms x1 x2
phi_sym = [(3 - x2^3)/2;
           3 - 2*x1^3];
J = jacobian(phi_sym, [x1 x2]);

maxIter = 20;
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
        % x - xOld;
        disp(x);
        break;
    end

    i = i + 1;
end
if (i == maxIter)
    fprintf('После iterMax = %d точность эпсилон не была достигнута, x:', i+1);
    disp(x);
end
