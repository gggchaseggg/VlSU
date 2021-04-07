import random

def quick_sort(array):
    if len(array) < 2:
        return array
    else:
        pivot = array[0]
        less = [i for i in array[1:] if i <= pivot]
        greater = [i for i in array[1:] if i > pivot]
        return quick_sort(less) + [pivot] + quick_sort(greater)

matrix = [[random.randint(0,10) for j in range(5)] for i in range(5)]

for i in range(5):
    print (matrix[i])
    matrix[i] = quick_sort(matrix[i])

matrix = list(zip(*matrix))
for i in range(len(matrix)): matrix[i] = list(matrix[i])
print ('\n')
for i in range(5):
    matrix[i] = quick_sort(matrix[i])
    print (matrix[i])