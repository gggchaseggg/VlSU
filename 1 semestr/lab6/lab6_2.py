from random import randint
def suma(n):
    a = []; b = []; c= [];suma = 0
    for i in range(n):
        a.append(randint(-50,50))
        b.append(randint(-50,50))
        c.append(a[i]+b[i])
        if c[i] >= 0:
            suma += c[i]
    return c,suma
s = 0
n = int(input("Введите длину массивов: "))
c,s = suma(n)
print ("Вектор С: {}\nСумма неотрицательных чисел: {}".format(c,s))