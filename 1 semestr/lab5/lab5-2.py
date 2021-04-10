from random import randint
N = 3
M = 4
sr = [61] * N
matrix = [[randint(-50,50) for j in range(N)] for i in range(M)]
for i in range(M):
    print(matrix[i])
    
for i in range(N):
    for j in range(M):
        if sr[i] != 61:
            sr[i] += matrix[j][i]
        else:
            sr[i] = matrix[j][i]
    sr[i] /= M

print ('Новый массив:', sr)