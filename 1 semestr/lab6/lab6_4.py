def element(x):
    a = [0,1]
    for i in range(2,x+1):
        a.append(a[i-2]+a[i-1])
    return a[x]
k = int(input("Введите k-тое число: "))
n = int(input("Введите n-тое число: "))
s = element(k)/element(n)
print ("Отношение k/n:", round(s,3))