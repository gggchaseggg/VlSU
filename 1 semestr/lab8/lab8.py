#Ввод информации о ячейки
def info_cell():
    cell_info = input("Введите номер и дату сдачи ячейки: ")
    info_array = cell_info.replace('.', ' ').split()
    cell_index = int(info_array[0])
    day_of_baggage_drop = int(info_array[1])
    mount_of_baggage_drop = int(info_array[2])
    return cell_index,day_of_baggage_drop,mount_of_baggage_drop

#Выявление является ли ячейка просроченной
def date_comparison(today_day,today_mount,day_of_baggage_drop,mount_of_baggage_drop):
    
    if today_mount == mount_of_baggage_drop:
        if today_day - day_of_baggage_drop > 3:
            return 1
    else:
        if (mount_of_baggage_drop < 8 and mount_of_baggage_drop % 2 != 0) or (mount_of_baggage_drop > 7 and mount_of_baggage_drop % 2 == 0):
            today_date = 31 + today_day
        elif mount_of_baggage_drop == 2:
            today_date = 28 + today_day
        else:
            today_date = 30 + today_day
            
        if (mount_of_baggage_drop < 8 and mount_of_baggage_drop % 2 != 0) or (mount_of_baggage_drop > 7 and mount_of_baggage_drop % 2 == 0):
            date_of_baggage = day_of_baggage_drop
        elif mount_of_baggage_drop == 2:
            date_of_baggage = day_of_baggage_drop
        else:
            date_of_baggage = day_of_baggage_drop
        
        if today_date - date_of_baggage > 3:
            return 1
    return 0

#Объявление/ввод переменных
expired_baggage = []
today_day,today_mount = map(int, input("Введите сегодняшнюю дату: ").split('.'))
number_of_occupied_cells = int(input("Введите кол-во занятых ячеек: "))

#Ввод и обработка информации о ячейках
for _ in range(number_of_occupied_cells):
    cell_index,day_of_baggage_drop,mount_of_baggage_drop = info_cell()
    if date_comparison(today_day,today_mount,day_of_baggage_drop,mount_of_baggage_drop) == 1:
        expired_baggage.append(cell_index)

#Вывод номеров просроченных ячеек
expired_baggage.reverse()
print (*expired_baggage, sep = '\n')