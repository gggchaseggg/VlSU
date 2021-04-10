def create_file(nazvanie):
    file_name = str('C:\\Users\\gggchaseggg\\Desktop\\1_семестр\\ОАП\\лаб7\\' + nazvanie + '.txt')
    file = open(file_name,'x')
    file.write('Фамилия        Год рождения  Марка автомобиля  Год выпуска автомобиля  Госномер' + '\n')
    file.close()

def write_file(nazvanie):
    file_name = str('C:\\Users\\gggchaseggg\\Desktop\\1_семестр\\ОАП\\лаб7\\' + nazvanie + '.txt')
    file = open(file_name, 'a')
    string = input('Введите строку: ')
    string = string.split()
    file.write('{:<15}'.format(string[0]))
    file.write('{:<14}'.format(string[1]))
    file.write('{:<18}'.format(string[2]))
    file.write('{:<24}'.format(string[3]))
    file.write(string[4] + '\n')
    file.close()

def open_file(nazvanie):
    file_name = str('C:\\Users\\gggchaseggg\\Desktop\\1_семестр\\ОАП\\лаб7\\' + nazvanie + '.txt')
    file = open(file_name, 'r')
    print(file.read())
    file.close()

def find_file(nazvanie):
    print ('Поиск по: ')
    print ('1) По фамилии ')
    print ('2) По марке и году выпуска')
    print ('3) По марке, кол-во, самый молодой и старший владелец')
    find_menu = int(input('Выберите критерий поиска: '))
    file_name = str('C:\\Users\\gggchaseggg\\Desktop\\1_семестр\\ОАП\\лаб7\\' + nazvanie + '.txt')
    file = open(file_name, 'r')
    
    if find_menu == 1:
        surname = input('Фамилия: ')
        while True:
            line = file.readline()
            if line == 'Фамилия        Год рождения  Марка автомобиля  Год выпуска автомобиля  Госномер':
                continue
            line_new = line.split()
            if len(line_new) == 0:
                print ('Не найдено')
                break
            if line_new[0] == surname:
                print(line)
                break

    elif find_menu == 2:
        marka,god = input('Марка и год выпуска: ').split()
        god = int(god)
        while True:
            line = file.readline()
            if line == 'Фамилия        Год рождения  Марка автомобиля  Год выпуска автомобиля  Госномер':
                continue
            line_new = line.split()
            if len(line_new) == 0:
                print ('Не найдено')
                break
            if line_new[2] == marka and int(line_new[3]) >= god:
                print(line)
    
    elif find_menu == 3:
        count_m = 0
        younger = 0
        older = 10000
        marka = input('Марка: ')
        while True:
            line = file.readline()
            line_new = line.split()
            if len(line_new) == 0:
                break
            if line_new[0] == 'Фамилия':
                continue
            if line_new[2] == marka:
                count_m += 1
            if int(line_new[1]) > younger:
                younger = int(line_new[1])
                younger_str = line
            else:
                older = int(line_new[1])
                older_str = line
        print ('Кол-во автомобилей этой марки: ', count_m)
        print ('Самый молодой владелец автомобиля этой марки:\n', younger_str)
        print ('Самый старший владлец автомобиля этой марки:\n', older_str)
    file.close()

while True:
    print ('МЕНЮ:')
    print('1 : создание нового файла')
    print('2 : дополнение файла')
    print('3 : вывод содержимого файла')
    print('4 : поиск по файлу')
    print('5 : завершение работы с файлом')
    main_menu = int(input('Выберите действие: '))
    if main_menu == 5:
        break
    nazvanie = input('Введите название файла: ')
    if main_menu == 1:
        create_file(nazvanie)
    elif main_menu == 2:
        write_file(nazvanie)
    elif main_menu == 3:
        open_file(nazvanie)
    elif main_menu == 4:
        find_file(nazvanie)
    print ('\n')