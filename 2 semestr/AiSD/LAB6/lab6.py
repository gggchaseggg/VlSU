def naxua(arr,k):
    kk = 0
    for i in arr:
        if i == k:
            kk += 1
    return kk

spisok = [39,71, 26, 27, 95, 27, 85, 75, 18, 23]
key = 27
print (naxua(spisok,key))