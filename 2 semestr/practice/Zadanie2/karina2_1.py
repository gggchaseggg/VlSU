def Dkstr(W,n,start):
    F = [10000]*n
    P = [0]*n
    visited = [True]*n
    F[start] = 0
    while True:
        min = 10000
        for i in range(n):
            if visited[i]  and F[i] < min:
                x = i
                min = F[i]
        
        if min == 10000:
            break
        
        visited[x] = False
        
        for i in range(n):
            if visited[i] and W[x][i] != 0 and F[i] > F[x] + W[x][i]:
                F[i] = F[x] + A[x][i]
                P[i] = x
    
    
    path = [[i] for i in range(n)]
    for i in range(n):
        x = i
        while x != start:
            x = P[x]
            path[i].insert(0,x)
    
    return F, path
    
def printmatrix ( matrix ): 
    print('Восстановление пути')
    for i in range ( len(matrix) ): 
        print('Путь до вершины с номером ', i)
        for j in range ( len(matrix[i]) ): 
            print ( "{:4d}".format(matrix[i][j]), end = "" ) 
        print ()

f = open('2 semestr/practice/Zadanie2/tabl_graph.txt', 'r')
l = [line.strip() for line in f]
n = int(l[0])
A = [[0]*n for i in range(n)]
for i in range(1, len(l)):
    k = int(l[i][4])*10 + int(l[i][5])
    A[ int(l[i][0]) ][ int(l[i][2]) ] = k
A[0][1] = 2
A[0][2] = 4
A[0][4] = 8
A[0][5] = 10
A[1][2] = 6
A[1][4] = 2
A[2][3] = 9
A[2][6] = 3
A[3][5] = 11
A[4][7] = 4
A[5][7] = 14
A[6][7] = 5
start = int(input('Введите начальное значение: '))
F,path = Dkstr(A,n,start)
print(*F)
printmatrix(path)
