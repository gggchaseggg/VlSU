from PIL import Image, ImageDraw, ImageFont
from random import randint

videoDimensions = (1280, 1280) 
img = Image.new("RGB", videoDimensions, color = '#FFE4C4')
imgDrawer = ImageDraw.Draw(img)
font = ImageFont.truetype('C:\Windows\Fonts\Arial.ttf', 30)

file = open('2 semestr/practice/Zadanie7/data.txt', 'r')
N = int(file.readline())
A = {}
for i in range(N): A[i] = []

while True:
    tmp = file.readline().rsplit()
    if tmp == []:
        break
    tmp[0], tmp[1] = int(tmp[0]) - 1, int(tmp[1]) - 1
    A[tmp[0]].append(tmp[1])        
    A[tmp[1]].append(tmp[0])

def new_coord():
    Y[0] = 10
    for i in range(N):
        X[i] = randint(80, videoDimensions[0] - 100)
        Y[i] = Y[i - 1] + videoDimensions[1] // N - 10

def draw_graph(x, y):
    for i in range(N):
        for j in A[i]:
            imgDrawer.line([(x[i], y[i]), (x[j], y[j])], 'black', 2)
    for i in range(N):
        imgDrawer.ellipse([(x[i] - 25, y[i] - 25), (x[i] + 25, y[i] + 25)], 'white', 'black', 2)
        imgDrawer.text((x[i] - 9, y[i] - 12), str(i + 1), (0, 0, 0), font)
    
def dfs(graph, start, end):
    fringe = [(start, [])]
    while fringe:
        state, path = fringe.pop()
        if path and state == end:
            yield path
            continue
        for next_state in graph[state]:
            if next_state in path:
                continue
            fringe.append((next_state, path+[next_state]))

X = [0]*N
Y = [0]*N

new_coord()
draw_graph(X, Y)
cycle = []

for node in A:
    for path in dfs(A, node, node):
        point = False
        t = sorted(path)
        for i in cycle:
            if sorted(i) == t or len(t) < 3: point = True
        if not point:
            cycle.append(t)

for i in range(len(cycle)):
    for j in range(len(cycle[i])):
        imgDrawer.text((20 + 30 * j, 20 + 30 * i), str(cycle[i][j] + 1), (0, 0, 0), font)        

print(cycle)
img.show()
