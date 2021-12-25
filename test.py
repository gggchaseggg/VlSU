import math

func_glob =  lambda x: 2 * x ** 3 - 3 * x ** 2 - 12 * x - 5
func_first = lambda x: 6 * x ** 2 - 6 * x - 12

a1, b1 = 0.0, 10.0

e = 0.001

def half_divide_method(a, b, f):
    x = (a + b) / 2
    while math.fabs(f(x)) >= e:
        x = (a + b) / 2
        a, b = (a, x) if f(a) * f(x) < 0 else (x, b)
    return (a + b) / 2


def newtons_method(a, b, f, f1):
    x0 = (a + b) / 2
    x1 = x0 - (f(x0) / f1(x0))
    while True:
        if math.fabs(x1 - x0) < e: return x1
        x0 = x1
        x1 = x0 - (f(x0) / f1(x0))

import pylab
import numpy

X = numpy.arange(-2.0, 4.0, 0.1)
pylab.plot([x for x in X], [func_glob(x) for x in X])
pylab.grid(True)
pylab.show()

print ('root of the equation half_divide_method %s' % half_divide_method(a1, b1, func_glob))
print ('root of the equation newtons_method %s' % newtons_method(a1, b1, func_glob, func_first))