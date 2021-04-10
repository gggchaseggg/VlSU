import random

def n_sort(array):
    a = [0] * (max(array)+1)

    for i in range(len(array)-1):
        a[array[i]] += 1

    del(array)
    array = []

    for i in range(len(a)-1):
        if a[i] != 0:
            for j in range(a[i]):
                array.append(i)

    return array
                
arr = [random.randint(0,50) for i in range(23)]

print (arr)

arr = n_sort(arr)

print (arr)