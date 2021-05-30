start_mas = [10,17,-6,13,-8,-3,18,-7,14]
derevo = [None] * 100

# derevo[index*2] is None and derevo[index*2 + 1] is None

def AddElem(elem):
    if derevo[1] is None:
        derevo[1] = elem
        return
    index  = 1
    while derevo[index]:
        if elem > derevo[index] and derevo[index * 2 + 1]:
            index = index * 2 + 1
        elif elem <= derevo[index] and derevo[index * 2]:
            index = index * 2
        else:
            break
    
    if elem > derevo[index]:
        derevo[index * 2 + 1] = elem
    else:
        derevo[index * 2] = elem

def DerIzMass(mass):
    for i in mass:
        AddElem(i)
    print (derevo)

DerIzMass(start_mas)