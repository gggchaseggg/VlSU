from random import randint
L = 4
N = 3
pr = 0
matrix = [0] * L
for i in range(L):
    matrix[i] = [0] * N
    mpr = 1
    for j in range(N):
        matrix[i][j] = randint(-50,50)
        if matrix[i][j] < 0:
            mpr *= matrix[i][j]
    if mpr != 1:
        if abs(mpr) > abs(pr):
            ind = i
            pr = mpr
    print (matrix[i])
print ("Индекс:", ind)