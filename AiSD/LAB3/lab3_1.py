import random

def bin_poisk(arr,key):
    if len(arr) == 1:
        if arr[0] == key:
            print ("Присутствует!")
        else:
            print ("Не присутствует!")
        return
    
    if key < arr[len(arr)//2]:
        bin_poisk(arr[:(len(arr)//2)],key)
    else:
        bin_poisk(arr[(len(arr)//2):],key)

a = [random.randint(-50,50) for i in range(15)]
a.sort()
print (a)

key = int(input("Введите ключ:"))

bin_poisk(a,key)