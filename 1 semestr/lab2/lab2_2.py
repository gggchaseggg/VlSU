a,b,c = map(int,input().split())                           #Ввод переменных a, b, c
if a + b > c and a + c > b and c + b > a:                  #Проверка условий
    if (a**2 + b**2 == c**2) or (a**2 + c**2 == b**2) or (b**2 + c**2 == a**2): #Проверка условий
        u = 1                                              #Присваивание переменной u значения 1
    else:                                                  #Несоответствие условиям
        u = 0                                              #Присваивание переменной u значения 0
else:                                                      #Несоответствие условиям
    u = -1                                                 #Присваивание переменной u значения -1
print (a, b, c, u)                                         #Вывод перемнных a, b, c, u