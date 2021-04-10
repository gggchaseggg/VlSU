import random as rand
y = [rand.randint(-50,50) for i in range(25)]
z = []
s = 0
for i in range(5):
    for j in range(5):
        s += y[i*5+j]
    z.append(s)
    s = 0
print (y)
print (z)