%% номер 1 метод трапеций (и метод трапеций с процедурой Рунге)
clc, clearvars, close all;

x_exp = [1 2 3 4 5 6 7 8];
y_exp = [-32.47 14.82 49.33 -7.26 -45.89 28.64 3.71 -19.58];

x = linspace(1, 8, 1e4);
f = @(x) interp1(x_exp, y_exp, x, 'spline'); 

a = min(x_exp); b = max(x_exp);
e = 1e-3;
M2 = max(gradient(gradient(interp1(x_exp, y_exp, x, 'spline'), x), x));
h = sqrt(12*e/((b-a)*M2)); 

x_h = a:h:b;
x_h2 = a:h/2:b;

I_h2 = trapz(x_h2, interp1(x_exp, y_exp, x_h2, 'spline'));
I_h = trapz(x_h, interp1(x_exp, y_exp, x_h, 'spline'));

p = 2;
I_Runge = I_h2 + (I_h2 - I_h)/(2^p - 1);

fprintf('Интеграл с шагом h: %.5f\n', I_h);
fprintf('Интеграл с шагом h/2: %.5f\n', I_h2);
fprintf('Интеграл с процедурой Рунге: %.5f\n', I_Runge);


F_h = cumtrapz(x_h, interp1(x_exp, y_exp, x_h, 'spline'));
F_h2 = cumtrapz(x_h2, interp1(x_exp, y_exp, x_h2, 'spline'));

figure(1)
hold on;
fplot(f, [min(x_exp) max(x_exp)], 'r');
plot(x_h, F_h, 'm');
plot(x_h2, F_h2, 'b--');
title("Функции y = f(x) и интегралы с разными шагами");xlabel('x'); ylabel('y'); grid on; yline(0, 'k--'); xline(0, 'k--'); xlim([min(x_exp)-1 max(x_exp)+1]); ylim([min(y_exp)-10 max(y_exp)+10]); legend('y = f(x)', 'y = F(x) с шагом h', 'y = F(x) с шагом h/2'); xticks(min(x_exp) - 1:0.5:max(x_exp) + 1);

%% номер k
clc; clearvars; close all;

x_exp = [1 2 3 4 5 6 7 8];
y_exp = [-32.47 14.82 49.33 -7.26 -45.89 28.64 3.71 -19.58];

f = @(x) interp1(x_exp, y_exp, x, 'spline');

a = min(x_exp); b = max(x_exp);
h = linspace(1e-4, 1, 100); 
I = zeros(size(h));

for i = 1:length(h)
    x_h = a:h(i):b;
    y_h = f(x_h);
    I(i) = trapz(x_h, y_h);
end

figure(1);
plot(h, I, 'k');hold on; 
plot([0 1], [14.57479 14.57479], 'k--');
title('Функция I = I(h)'); xlabel('h'); ylabel('Интеграл I'); grid on; legend('I = I(h)', 'I истинное');

% номер k+1
clc; clearvars; close all;

x_exp = [1 2 3 4 5 6 7 8];
y_exp = [-32.47 14.82 49.33 -7.26 -45.89 28.64 3.71 -19.58];

f = @(x) interp1(x_exp, y_exp, x, 'spline');

a = min(x_exp); b = max(x_exp);
h = linspace(1e-4, 1, 100); 
I = zeros(size(h));

for k = 1:length(h)
    x_h = a:h(k):b;
    y_h = f(x_h);
    I(k) = trapz(x_h, y_h);
end

figure(1);
plot(h, I, 'k');hold on; 
plot([0 1], [14.57479 14.57479], 'k--');
title('Функция I = I(h)'); xlabel('h'); ylabel('Интеграл I'); grid on; legend('I = I(h)', 'I истинное');

%% номер k+2
clc, clearvars, close all;

x_exp = [1 2 3 4 5 6 7 8];
y_exp = [-32.47 14.82 49.33 -7.26 -45.89 28.64 3.71 -19.58];

f = @(x) interp1(x_exp, y_exp, x, 'spline'); 

a = min(x_exp); b = max(x_exp);
e = 1e-3;
x_for_grad = linspace(1,8,1e6);
y_spline = interp1(x_exp, y_exp, x_for_grad, 'spline');
d4f = gradient(gradient(gradient(gradient(y_spline, x_for_grad), x_for_grad), x_for_grad), x_for_grad);
M4 = max(abs(d4f));
hMax = (180*e/((b-a)*M4))^0.25; %   = 0.1041

q = @(x) quad(f, a, x);

figure(1)
fplot(q, [a b], 'm');
title("Функции y = F(x) методом Симпсона"); xlabel('x'); ylabel('y'); grid on; yline(0, 'k--'); xline(0, 'k--'); xlim([min(x_exp)-1 max(x_exp)+1]); ylim([min(y_exp)-10 max(y_exp)+10]); xticks(min(x_exp) - 1:0.5:max(x_exp) + 1);

%% номер k+3
clc, clearvars, close all;

x_exp = [1 2 3 4 5 6 7 8];
y_exp = [-32.47 14.82 49.33 -7.26 -45.89 28.64 3.71 -19.58];

f = @(x) interp1(x_exp, y_exp, x, 'spline'); 
F = @(x) integral(f, min(x_exp), x);

figure(1)
hold on;
fplot(F, [min(x_exp) max(x_exp)], 'r');
title("Функции y = F(x) встроенными функциями матлаб");xlabel('x'); ylabel('y'); grid on; yline(0, 'k--'); xline(0, 'k--'); xlim([min(x_exp)-1 max(x_exp)+1]); ylim([min(y_exp)-10 max(y_exp)+10]); legend('y = F(x) с шагом h'); xticks(min(x_exp) - 1:0.5:max(x_exp) + 1);

%% номер k+4 (пример с сайта)
clc, clearvars, close all;

% a = 7;

syms x  a;
f = a^x*exp(-x);
df = int(f, x)

%% номер k+5 (пример с сайта)
clc, clearvars, close all;

% a = 7;

syms x  a p;
f = (1 + x)/(x+a)^(p+1);
df = int(f, x)




