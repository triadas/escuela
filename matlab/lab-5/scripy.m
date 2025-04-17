% Вариант 22:

%% номер 1 (Построение графика функции)
clc, clear vars, close all

x = linspace(-50,5,1000);
y = ((exp(x) + 10*sin(x))) - 15;

figure(1)
plot(x,y,"r-")
title('y = y(x)'), xlabel('x'), ylabel('y'), grid on
hold on
plot([-50,5],[0,0], "k-")
xlim([-50 5])

%% номер 2 (Локализация кореня методом
% половинного деления с
% невысокой точностью)
clc, clear vars, close all

y = @(x) exp(x) + 10*sin(x) - 15;

a = -5; b = 5; e = 0.001;

while(abs(a-b) >= e)
    c = (a + b)/2;
    if y(c) == 0
        fprintf('Решение: x = %.2f', c);
        break;
    end
    if y(c)*y(a) < 0
        b = c;
    else 
        a = c;
    end
end
fprintf('Решение: x = %.2f', c);

%% номер 3 (Решение с использованием ф-ий fzero)
clc, clear vars, close all

y = @(x) exp(x) + 10*sin(x) - 15;
fzero(y,1) % =1.6111

%% номер 4.1 (Уточние кореня методом ПИ)

clc, clearvars, close all;

f = @(x) exp(x) + 10*sin(x) - 15;
f1 = @(x) exp(x) + 10*cos(x);

tau = -0.05;  
phi = @(x) x + tau*f(x);
x0 = 1.5;
xStart = x0;
e = 0.001; 
maxIter = 100;  

phi_prime = @(x) 1 + tau*f1(x);
if abs(phi_prime(x0)) >= 1
    warning('Условие сходимости не выполняется! phi''(x0)=%f', phi_prime(x0));
end

for iter = 1:maxIter
    x = phi(x0);
    
    if abs(x - x0) < e
        fprintf('Решение: x = %.6f, f(x) = %.6f\nИтераций: %d\n', x, f(x), iter);
        break;
    end
    
    x0 = x;
    
    if iter == maxIter
        warning('Достигнут максимум итераций!');
    end
end

fplot(f, [1 2.5]), grid on, hold on;
plot(x, f(x), 'r*');
plot(xStart, f(x), 'b*');
title(sprintf('Метод простых итераций (t=%.2f)', tau));

%% номер 4.2 (Уточние кореня методом хорд)
clc, clear vars, close all

f = @(x) exp(x) + 10*sin(x) - 15;
f2 = @(x) exp(x) - 10*sin(x); 

a = -5; b = 5; e = 0.001;

if f(a)*f2(a) < 0
    x = b;
    z = a;
else
    x = a;
    z = b;
end
fz = f(z);
xStart = x;

if fz * f2(z)>0
    fprintf('Обеспечивается условия бысторой сходимости\n')
else 
    fprintf('Не обеспечивается условия бысторой сходимости\n')
end

i = 0;
while(1)
    h = (x - z)*f(x)/(f(x) - fz);
    x = x - h;
    if abs(h) <= e
        fprintf('Решение: x = %.6f, f(x) = %.6f\nИтераций: %d\n', x, f(x), i);
        break
    end
    i = i+ 1;
end

fplot(f, [-6 2.5]), grid on, hold on;
plot(x, f(x), 'r*');
plot(xStart, f(x), 'b*');
title(sprintf('Метод хорд (t=%.2f)', tau));

%% номер 4.3 (Уточние кореня методом касательных)
clc, clear vars, close all

f = @(x) exp(x) + 10*sin(x) - 15;
f1 = @(x) exp(x) + 10*cos(x);
f2 = @(x) exp(x) - 10*sin(x); 

a = -5; b = 5; e = 0.001;

if f(a)*f2(a) < 0
    x = a;
else
    x = b;
end
fz = f(z);
xStart = x;

if fz * f2(z)>0
    fprintf('Обеспечивается условия бысторой сходимости\n')
else 
    fprintf('Не обеспечивается условия бысторой сходимости\n')
end

i = 0;
while(1)
    h = f(x)/f1(x);
    x = x - h;
    if abs(h) <= e
        fprintf('Решение: x = %.6f, f(x) = %.6f\nИтераций: %d\n', x, f(x), i);
        break
    end
    i = i + 1;
end

fplot(f, [-1 6]), grid on, hold on;
plot(x, f(x), 'r*');
plot(xStart, f(x), 'b*');
title(sprintf('Метод касательных (t=%.2f)', tau));

%% номер 4.4 (Уточние кореня методом секущих)

clc, clearvars, close all;

f = @(x) exp(x) + 10*sin(x) - 15;
f1 = @(x) exp(x) + 10*cos(x); 
f2 = @(x) exp(x) - 10*sin(x);
e = 0.001;                         
max_iter = 100;                     


x0 = 1.0;
x1 = 2.0;
xStart = x0;

if f(x1) * f2(x1)>0
    fprintf('Обеспечивается условия бысторой сходимости\n')
else 
    fprintf('Не обеспечивается условия бысторой сходимости\n')
end


for i = 1:max_iter
    if i == 1
        f_prime = f1(1);
    else
        f_prime = (f(x1) - f(x0))/(x1 - x0);
    end
    
    x_new = x1 - f(x1)/f_prime;
   
    if abs(x_new - x1) < e
        fprintf('Решение: x = %f, f(x) = %.6f\nИтераций: %d\n', x_new, f(x_new), i);
        break;
    end
    
    x0 = x1;
    x1 = x_new;
    
    if i == max_iter
        warning('Достигнуто максимальное число итераций!');
    end
end

fplot(f, [0 3]), hold on;
plot(x_new, f(x_new), 'r*');
plot(xStart, f(x_new), 'b*');
title('Метод секущих'),xlabel('x'),ylabel('f(x)'),grid on;