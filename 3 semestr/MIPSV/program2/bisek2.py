from math import *

def f(x):
    return (cos(x))**2 + (cos(x)/2) + 1/18

eps = 10**-10
an = 0
bn = 2
k = 0

while bn-an > 2*eps:
    xn = (an+bn)/2
    fa = f(an)
    fb = f(bn)
    fxn = f(xn)
    if fa*fxn <= 0:
        bn=xn
    else:
        an = xn
    k = k+1

xn = (an+bn)/2
res = (xn,k)
print (f"Первый корень - {res[0]}")
print (f"Второй корень - {res[1]}")