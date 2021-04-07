def quick_sort(array):
    if len(array) < 2:
        return array
    else:
        pivot = array[0]
        less = [i for i in array[1:] if i <= pivot]
        greater = [i for i in array[1:] if i > pivot]
        return quick_sort(less) + [pivot] + quick_sort(greater)

arr = [4,3,8,5,4,2,7,3,2]
quick_sort(arr)
print (arr)

# matrix = [[1,2,3],[4,5,6],[7,8,9]]
# print (matrix)
# matrix = list(zip(*matrix))
# for i in range(len(matrix)): matrix[i] = list(matrix[i])
# print (matrix)