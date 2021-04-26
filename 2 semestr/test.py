import random
def summa(array,sym=0,k=0):
    if len(array) == 0:
        return sym,k
    else:
        sym += a[0]
        k += 1
    
    sym,k = summa(array[2:],sym,k)
    return sym,k


a = [random.randint(-50,50) for i in range(15)]
print (a)
print (sum(a))
sym,k = summa(a)

print (sym,k)