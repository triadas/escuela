% вариант 22

%% номер 1 (Построение канонического полинома, используя определитель Вандермонда)

clc, clearvars, close all;

x_exp = [1  2  3  4  5  6  7  8]; 
y_exp = [-32.47  14.82  49.33  -7.26  -45.89  28.64  3.71  -19.58];
x_nodal = [2.87 3.39]; 

W = vander(x_exp);
d = det(W); % 1.25e+11
a = inv(W)*y_exp';

x = linspace(1,8, 1e4);

figure(1);
plot(x, Pn(a, x), 'b'), hold on;
plot(x_exp, y_exp, 'k*');
plot(x_nodal, Pn(a, x_nodal), 'r*'), hold on;
title('y = P_n(x) (канонический полином)'), xlabel('x'), ylabel('y'), yline(0), grid on, xticks(0:0.5:9), yticks(-100:10:50), legend('y = P_n(x)', 'exp', 'nodal'), xlim([0 9]), ylim([-100 60])

%% номер 2 (Построение канонического полинома, interp1)
%  номер 3 (Построие графика)
clc, clearvars, close all;

x_exp = [1  2  3  4  5  6  7  8]; 
y_exp = [-32.47  14.82  49.33  -7.26  -45.89  28.64  3.71  -19.58];
x_nodal = [2.87 3.39]; 

x  = linspace(1,8, 1e5);
y = interp1(x_exp, y_exp, x, "spline");
   
figure(1);
plot(x, y, 'b'), hold on;
plot(x_exp, y_exp, 'k*');
plot(x_nodal, interp1(x_exp, y_exp, x_nodal, "spline"), 'r*'), hold on;
title('y = P_n(x) (interp1)'), xlabel('x'), ylabel('y'), yline(0), grid on, xticks(0:0.5:9), yticks(-100:10:50), legend('y = P_n(x)', 'exp', 'nodal'), xlim([0 9]), ylim([-100 60])

%% номер 2 (Построение канонического полинома, polyfit и polyval)
%  номер 3 (Построие графика)
clc, clearvars, close all;

x_exp = [1  2  3  4  5  6  7  8]; 
y_exp = [-32.47  14.82  49.33  -7.26  -45.89  28.64  3.71  -19.58];
x_nodal = [2.87 3.39]; 

x  = linspace(1,8, 1e5);
koefs = polyfit(x_exp, y_exp, length(x_exp)-1);
y = polyval(koefs, x);
    
figure(1);
plot(x, y, 'b'), hold on;
plot(x_exp, y_exp, 'k*');
plot(x_nodal, polyval(koefs, x_nodal), 'r*'), hold on;
title('y = P_n(x) (канонический полином ч/з polyfit)'), xlabel('x'), ylabel('y'), yline(0), grid on, xticks(0:0.5:9), yticks(-100:10:50), legend('y = P_n(x)', 'exp', 'nodal'), xlim([0 9]), ylim([-100 60])

% figure(2);
% fplot(@Rn, [min(x_exp) max(x_exp)])
% title('y = P_n(x) (канонический полином ч/з polyfit)'), xlabel('x'), ylabel('y'), yline(0), grid on, xticks(0:0.5:9), yticks(-100:10:50), legend('y = P_n(x)', 'exp', 'nodal'), xlim([0 9]), ylim([-100 60])

%% номер n-1 (определение оптимальной степенип полинома)
clc, clearvars, close all;
y_exp = [-32.47  14.82  49.33  -7.26  -45.89  28.64  3.71  -19.58];

fl = 1;
dMin = abs(max(y_exp) - min(y_exp));
for i = 1:(length(y_exp) - 2)
    y = diff(y_exp, i);
    if (dMin > abs(min(max(y) - min(y))))
        dMin = abs(min(max(y) - min(y)));
        fl = i;
    end
end

fprintf('Оптимальна разность %d порядка, с отличием max и min в %f\n', fl, dMin);
disp(diff(y_exp, fl));
fprintf('Оптимальная степень полинома: %d\n', fl);



%% а тут все функции
function y = Pn(a, x)
    n = length(a);

    y = 0;
    for i = 1:8
        y = y + a(i) * x.^(n - i);
    end
end

function L = Lagr(x_exp, y_exp, x)
  n = length(x_exp) - 1;

  L = 0; 
  for j = 0:n
    Bj = 1; 
    for i = 0:n
      if i ~= j
        Bj = Bj * ( (x - x_exp(i+1)) / (x_exp(j+1) - x_exp(i+1)) );
      end
    end
    L = L + Bj * y_exp(j+1);
  end
end

function R  = Rn(x)
    x_exp = [1  2  3  4  5  6  7  8]; 
    y_exp = [-32.47  14.82  49.33  -7.26  -45.89  28.64  3.71  -19.58];
    n = length(x_exp)-1;
    koefs = polyfit(x_exp, y_exp, n);
    syms x1;
    y_sym = poly2sym(koefs, x1);
    dirMax = 0;
    for xi = 1:0.1:8
        dirMax = max(abs(double(subs(diff(y_sym, x1, n), x1, 1))), dirMax);
    end
    A = 1; 
    for i = 1:(n)
        A = A *  (x - x_exp(i));
    end
    fact = factorial(n-1);

    R = dirMax * A / fact;
end
