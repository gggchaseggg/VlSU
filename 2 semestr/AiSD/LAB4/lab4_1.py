
def frequent_char(string):
    '''Находит самый частовстречающийся символ'''
    string = sorted(string)

    maxcount = 0
    for char in string:
        charcount = string.count(char)
        
        if charcount > maxcount:
            maxcount = charcount
            maxchar = char
    
    return maxchar, maxcount

def numb_char(string):
    '''Количество букв и цифр'''
    numbers = ['1','2','3','4','5','6','7','8','9','0']
    numbs = 0
    for char in string:
        if char in numbers:
            numbs += 1

    chars = len(string) - numbs

    return chars,numbs

def hex_number(string):
    '''Переводит числа строки в Hex'''
    numbers = ['1','2','3','4','5','6','7','8','9','0']
    stringtmp = string
    string = ''
    for char in stringtmp:
        if char in numbers:
            string += char

    string = hex(int(string))
    return string


def xaching(string):
    '''Хэширует строку'''
    string = str(string)

    #Частый символ и количество
    maxchar_char,maxchar_count = frequent_char(string)
    #Первый и последний символ
    first_char,last_char = string[0],string[-1]
    #Количество символов
    lenght = len(string)
    #Количество букв и цифр
    qut_let,qut_numb = numb_char(string)
    #Код цифр пароля в 16-ричной системе
    hex_numb = hex_number(string)

    xach = (str(maxchar_char) 
            + str(maxchar_count)
            + str(first_char)
            + str(last_char)
            + str(lenght)
            + str(qut_let)
            + str(qut_numb)
            + str(hex_numb))
    
    return xach



def menu():
    print ("Что вы хотите сделать?\n1 - Добавить пароль\n2 - Проверить наличие пароля")
    key_input = int(input("Выберите номер пункта: "))
    if key_input == 1:
        password = input("Введите пароль: ")
        password_xach = xaching(password)

        passwords[password_xach] = password
    elif key_input == 2:
        password = input("Введите пароль: ")
        password_xach = xaching(password)
        if password_xach in passwords:
            print("Такой пароль присутствует!")
        else:
            print("Такого пароля нет!")

passwords = {"32k011560x39044": 'kiril233540'}
menu()
print (passwords)