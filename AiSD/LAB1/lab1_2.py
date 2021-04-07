def f(x):
    return x**2-4

def c(a,b,e=0.001):
    if abs(b-a) <= 2*e:
        return (a+b)/2
    else:
        m = (a+b)/2

        if f(a)*f(m) <= 0:
            b = m
        else:
            a = m
        
        return c(a,b,e)

a,b = map(int,input().split())

if f(a)*f(b) < 0:
    print(c(a,b))
else:
    print ("Не подходит по условиям!")