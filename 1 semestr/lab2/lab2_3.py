import math
x, y = map(int,input().split())                #Ввод переменных x, y
if (y >= math.fabs(0.5*x)) or y >= 0.5:   #Проверка условий
    print ("Да, принадлежит!")                 #Вывод положительного ответа
else:                                          #Несоответствие условиям
    print ("Нет, не принадлежит!")             #Вывод отрицательного ответа