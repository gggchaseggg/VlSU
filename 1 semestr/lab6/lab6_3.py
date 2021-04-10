from random import randint
def zapolnenie(strings_array,columns_array):
    matrix = [0] * strings_array
    for i in range(strings_array):
        matrix[i] = [0] * columns_array
        for j in range(columns_array):
            matrix[i][j] = randint(-50,50)
            print (matrix[i][j], end = '\t')
        print ('\n', end = '')
    return matrix

def max_stroka(array):
    max_v_str = 0
    for i in range(len(array)):
        proizvedenie = 1
        for j in range(len(array[0])):
            if array[i][j] < 0:
                proizvedenie *= array[i][j]
        if abs(proizvedenie) > max_v_str:
            max_v_str = abs(proizvedenie)
            index_max_string = i
    return index_max_string

strings_array = int(input("Введите кол-во строк матрицы: "))
columns_array = int(input("Введите кол-во столбцов матрицы: "))

array = zapolnenie(strings_array,columns_array)
index = max_stroka(array)

print ("Индекс строки с маскимальным по модулю произведением элементов: ", index)