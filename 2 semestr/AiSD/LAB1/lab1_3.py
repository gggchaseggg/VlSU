import random

def sravnenie(a,b):
    k = 0
    for i in range(len(a)):
        if not (a[i] in b):
            k += 1
            if k > 2:
                break
    k1 = 0
    for i in range(len(b)):
        if not (b[i] in a):
            k1 += 1
            if k > 2:
                break
    
    if k > 2 or k1 > 2:
        return False

    return True

def finder_par():
    if len(slovar) == 1:
        return slovar[0]
    if len(cepochka) == 0:
        ind = random.randint(0,(len(slovar))-1)
        cepochka.append(slovar[ind])
        slovar.pop(ind)

    for i in range(len(slovar)):
        if sravnenie(cepochka[len(cepochka)-1],slovar[i]):
            cepochka.append(slovar[i])
    
cepochka = []
slovar = ['барак', 'баран', 'банан', 'дурак', 'бутон', 'бутан', 'питон', 'барин']

finder_par()
print(cepochka)