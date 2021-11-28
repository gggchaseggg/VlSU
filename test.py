a = [1,1,1,1,0,0,0,1,1,0,0,0,1,1,0]
btmp = -1
kolvotmp = 0
kolvo = 10
for i in a:
    if btmp == -1:
        btmp = i
        kolvotmp = 1
        continue
    
    if btmp == i:
        kolvotmp += 1
    else:
        if kolvotmp < kolvo:
            kolvo = kolvotmp
            b = btmp
        btmp = i
        kolvotmp = 1
if kolvotmp < kolvo:
    kolvo = kolvotmp
    b = btmp
print (f"{b} - {kolvo}")