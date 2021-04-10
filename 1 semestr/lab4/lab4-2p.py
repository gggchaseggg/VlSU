import random as rand
n = 10; a = []; b = []; c = []; s = 0 #Объявление массивов
for i in range(n): #Условие цикла
    a.append(rand.randint(-50,50)) #Заполнение массива
    b.append(rand.randint(-50,50)) #Заполнение массива
    c.append(a[i]+b[i]) #Заполнение массива
    if c[i] >= 0: #Проверка условия
        s += c[i] #Вычисления
print ("Вектор С: {}\nСумма неотрицательных чисел: {}".format(c,s)) #Вывод
