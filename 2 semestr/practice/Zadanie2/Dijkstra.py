def Dijkstra(W,N,start):
    F = [100000]*N
    F[start] = 0
    V = [True]*N
    P = [0]*n
    
    while True:
        min_R = 100000
        min_v = None
        
        for i in range(N):
            if V[i] and F[i] < min_R:
                min_R  = F[i]
                min_v = i
        
        if min_v is None:
            break
        
        for j in range(N):
            if V[j] and W[min_v][j] != 0 and F[j] > F[min_v]+W[min_v][j]:
                F[j] = F[min_v]+W[min_v][j]
                P[j] = min_v
        
        V[min_v] = False

    puti = [[i] for i in range(n)]
    for i in range(n):
        min_v = i
        while min_v != start:
            min_v = P[min_v]
            puti[i].insert(0,min_v)
    
    return F,puti

def vivod(matrix):
    print("Путь:")
    for i in range(len(matrix)):
        print("Путь до вершины ", i)
        for j in range(len(matrix[i])):
            print ( "{:4d}".format(matrix[i][j]), end = "" )
        print ()

f = open('2 semestr/practice/Zadanie2/vesa.txt', 'r')
line = [line.strip() for line in f]
n = int(line[0])
A = [[0]*n for i in range(n)]

for i in range(1, len(line)):
    k = int(line[i][4])*10 + int(line[i][5])
    A[int(line[i][0])][int(line[i][2])] = k

A[0][2] = 6
A[0][3] = 99
A[0][4] = 25
A[1][0] = 34
A[1][4] = 37
A[2][0] = 7
A[2][1] = 23
A[3][1] = 29
A[4][2] = 11

start = int(input('Введите начальное значение: '))
F,path = Dijkstra(A,n,start)
print(*F)
vivod(path)