start_kucha = [100, 19, 36, 17, 3, 25, 1, 2, 7]
start_kucha_add = [16, 11, 9, 10, 5, 6, 8, 1, 2]

# def vivod_kuchi(kucha):
#     for i in range()

def AddElem(kucha,flag=True,element=3456384):
    '''Добавляет элемент в кучу'''
    if flag:
        print (kucha)
        elem = int(input("Введите новый элемент: "))
    else:
        elem = element
    kucha.append(elem)  
    index = len(kucha) - 1
    while kucha[index] > kucha[index//2]:
        kucha[index],kucha[index//2] = kucha[index//2],kucha[index]
        index //= 2

    if flag:
        print (kucha)

def DelElem(kucha):
    '''Удаляет больший элемент'''
    print (kucha)
    kucha[0] = kucha[-1]
    kucha.pop(-1)
    
    ind = 1
    n_ind = ind * 2

    while (n_ind <= len(kucha)):
        if (n_ind + 1 <= len(kucha)):
            if kucha[n_ind-1]>kucha[n_ind+1-1]:
                kucha[ind-1],kucha[n_ind-1] = kucha[n_ind-1],kucha[ind-1]
                ind = n_ind
                n_ind *= 2
            else:
                kucha[ind-1],kucha[n_ind] = kucha[n_ind],kucha[ind-1]
                ind = n_ind + 1
                n_ind = (n_ind + 1) * 2
        else:
            kucha[ind-1],kucha[n_ind-1] = kucha[n_ind-1],kucha[ind-1]

    print (kucha)

def BuildKuch(flag=True,kucha=[]):
    if flag:
        dlina = int(input("Введите количество элементов: "))
        tmp_kucha = []
        for i in range(dlina):
            vvod = int(input("Введите {}-й элемент: ".format(i+1)))
            tmp_kucha.append(vvod)
    tmp_kucha = kucha
    new_kucha = []
    new_kucha.append(tmp_kucha[0])
    tmp_kucha.pop(0)
    for elem in tmp_kucha:
        AddElem(new_kucha,False,elem)
    print (new_kucha)

def MergeKuch(kucha1,kucha2):
    tmp_kucha = kucha1 + kucha2
    BuildKuch(False,tmp_kucha)

def menu():
    print ("Что вы хотите сделать?\n1 - Добавить элемент\n2 - Удалить больший эелемент\n3 - Построить кучу\n4 - Объединить кучи")
    key_input = int(input("Выберите номер пункта: "))
    if key_input == 1:
        AddElem(start_kucha)
    elif key_input == 2:
        DelElem(start_kucha)
    elif key_input == 3:
        BuildKuch()
    elif key_input == 4:
        MergeKuch(start_kucha,start_kucha_add)

menu()