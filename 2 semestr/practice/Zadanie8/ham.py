from PIL import Image, ImageDraw, ImageFont
from random import randint
videoDimensions = (1280, 1280)
img = Image.new('RGB', videoDimensions, color = '#FFE4C4')
imgDrawer = ImageDraw.Draw(img)
font = ImageFont.truetype('C:\Windows\Fonts\Arial.ttf', 30)

file = open('2 semestr/practice/Zadanie8/data.txt', 'r')
N = int(file.readline())
A = [0] * N
for i in range(N):
    A[i] = [0] * N
while True:
    tmp = file.readline().rsplit()
    if tmp == []:
        break
    tmp[0], tmp[1] = int(tmp[0]) - 1, int(tmp[1]) - 1
    A[tmp[0]][tmp[1]] = 1
    A[tmp[1]][tmp[0]] = 1

def new_coord():
    Y[0] = 10
    for i in range(N):
        X[i] = randint(80, videoDimensions[0] - 100)
        Y[i] = Y[i - 1] + videoDimensions[1] // N - 10

def draw_graph(x, y):
    for i in range(N):
        for j in range(i + 1, N):
            if A[i][j] == 1:
                imgDrawer.line([(x[i], y[i]), (x[j], y[j])], 'black', 2)

    for i in range(1, N):
        imgDrawer.ellipse([(x[i] - 25, y[i] - 25), (x[i] + 25, y[i] + 25)], 'white', 'black', 2)
        imgDrawer.text((x[i] - 9, y[i] - 12), str(i), (0, 0, 0), font)

def draw_hamilton():
    for i in range(len(path) - 1):
        imgDrawer.line([(X[path[i]], Y[path[i]]), (X[path[i + 1]], Y[path[i + 1]])], 'red', 4)
    for i in path:        
        imgDrawer.ellipse([(X[i] - 25, Y[i] - 25), (X[i] + 25, Y[i] + 25)], 'white', 'black', 2)
        imgDrawer.text((X[i] - 9, Y[i] - 12), str(i), (0, 0, 0), font)

def GamCycle(gg):
    path.append(gg)
    if len(path) == N:
        if A[path[0]][path[-1]] == 1:
            return True
        else:
            path.pop()
            return False
    visited[gg] = True
    for next in range(N):
        if A[gg][next] == 1 and not visited[next]:
            if GamCycle(next):
                return True
    visited[gg] = False
    path.pop()
    return False

X = [0]*N
Y = [0]*N
visited = [False] * N
path = []

new_coord()
draw_graph(X, Y)

GamCycle(0)
draw_hamilton()

imgDrawer.text((100, 1200), 'Путь: ', (0,0,0), font)
imgDrawer.text((200, 1200), str(path), (0,0,0), font)
img.show()