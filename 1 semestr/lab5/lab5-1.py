from random import randint
M = 4
N = 3
matrix = [0] * M
mm = 0
for i in range(M):
    matrix[i] = [0] * N
    for j in range(N):
        matrix[i][j] = randint(-50,50)
        if abs(matrix[i][j]) > abs(mm):
            mm = matrix[i][j]
    print (matrix[i])
print ("Наибольший по модулю элемент: ", mm)
for i in range(M):
    for j in range(N):
        matrix[i][j] = round(matrix[i][j] / mm, 3)

for i in range(M):
    print (matrix[i])