import random

def menu():
    print ('''
    1 - На каком месте стоит элемент
    2 - К-статистика
    ''')

    x = int(input("Выберите пункт: "))
    
    if x == 1:
        a.sort()
        print (a)
        key = int(input("Введите ключ: "))
        bin_poisk(key)
    elif x == 2:
        print (a)
        ks(a)

def ks(array):
    key = int(input("Введите значение: "))
    for i in range(len(array)):
        if array[i] == key:
            print ("Элемент стоит на {} месте в неотсортированном множетсве".format(i))
            return
    else:
        print ("Такого элемента нет")

def bin_poisk(key,left=0,right=15):

    if (right-left) <= 1:
        if a[left] == key:
            print ("Присутствует!")
        else:
            print ("Не присутствует!\nВставить его нужно на {} место".format(right))
            a.insert(right,key)
            print(a)

        return
    
    if key < a[(right-left)//2+left]:
        bin_poisk(key,left,((right-left)//2)+left)
    else:
        bin_poisk(key,((right-left)//2)+left,right)

a = [random.randint(-50,50) for i in range(15)]
menu()
