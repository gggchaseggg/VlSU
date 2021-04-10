import math
def tabul():
    b = 1.5
    x = .1
    while .1<=x<=1:
        if b * x < 1:
            y = round((b*x - math.log10(b*x)),3)
        elif b * x > 1:
            y = round((b*x + math.log10(b*x)),3)
        else:
            y = 1
        print ('x = {}  y = {}'.format(x,y))
        x = round((x+.1),1)
tabul()