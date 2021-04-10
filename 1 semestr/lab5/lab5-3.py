from random import randint
N = 3
matrix = [0] * N
mm = 0
for i in range(N):
    matrix[i] = [0] * N
    for j in range(N):
        matrix[i][j] = randint(-50,50)
        if abs(matrix[i][j]) > abs(mm):
            mm = matrix[i][j]
            strk = i
            stlb = j
    print (matrix[i])

k = randint(1,N-1)
print ("Коэффициент k:",k)

if strk != k:
    matrix[k],matrix[strk] = matrix[strk],matrix[k]

for i in range(N):
    if stlb != k:
        matrix[i][k],matrix[i][stlb] = matrix[i][stlb],matrix[i][k]
    print (matrix[i])
