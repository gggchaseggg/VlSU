import random as rand
b = rand.randint(-50,50)
n = 10
a = []
mn = 51
for i in range(n):
    a.append(rand.randint(-50,50))
    if a[i] >= 0 and a[i] < mn:
        mn = a[i]
        ind = i 
print("Изначальный массив:",a)
a.append(0); a.append(0)
for i in range(n-ind+1):
    if n-i == ind:
        a[n-i+1] = a[n-i]
    else:
        a[(n+1)-i] = a[n-i-1]
a[ind],a[ind+2] = b,b
print ("Заданное число: {}\nИзмененный массив: {}".format(b,a))