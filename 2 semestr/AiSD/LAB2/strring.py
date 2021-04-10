string = 'aaewbtvrliuzseliuvbzslitr'

for i in range (len(string)-1):
    min_let = 'zz'
    for j in range(i+1,len(string)-1):
        if string[j] < min_let:
            min_let = string[j]
            ind = j

    string = string[:i+1] + string[ind] + string[i+1:ind] + string[ind+1:]

print (string)
