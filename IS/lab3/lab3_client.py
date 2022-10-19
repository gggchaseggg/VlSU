import socket
from typing import List

def connect(ip:str,site:str) -> str:
    s = socket.socket()
    s.connect((ip, 5500))
    s.sendall(site.encode('utf-8'))
    data = s.recv(1024).decode('utf-8')
    s.close()
    return data
    
try:
    site = input("Введите название сайта: ")
    dns:List[str] = []
    with open("C:\git\VlSU\IS\lab3\dns.txt", "r") as f:
        for line in f:
            dns.append(line.rstrip())
    for ip in dns:
        response:str = connect(ip,site)
        if (response != ""):
            print(response)
            break
        else:
            print("Нет данных")
            continue
except:
    print("Error")