import random

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
a.sort()
print (a)

key = int(input("Введите ключ: "))

bin_poisk(key)