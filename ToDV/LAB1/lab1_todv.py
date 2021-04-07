import math
from tkinter import *
import time 

def alpha(canv):
    '''Рисует график функции y-4/x<=0'''
    for i in range(-300,300):
        x = i
        if x==0 or x==-1:
            continue
        y = 4000/x
        y2 = 4000/(x+1)

        canv.create_line(x+300,300-y,x+300,600,fill='orange')

    for i in range(-300,300):
        x = i
        if x==0 or x==-1:
            continue
        y = 4000/x
        y2 = 4000/(x+1)

        canv.create_line(x+300,300-y,(x+1)+301,300-y2+1,width=2)
        

def betta(canv):
    '''Рисует график функции y+4/x>=0'''
    for i in range(-300,300):
        x = i
        if x==0 or x==-1:
            continue
        y = -(4000/x)
        y2 = -(4000/(x+1))

        canv.create_line(x+300,300-y,x+300,0,fill='orange')

    for i in range(-300,300):
        x = i
        if x==0 or x==-1:
            continue
        y = -(4000/x)
        y2 = -(4000/(x+1))

        canv.create_line(x+300,300-y,(x+1)+301,300-y2+1,width=2)
        

def zetta(canv):
    '''Рисует график функции y2+x2-25<=0'''
    for i in range(-300,300):
        x = i
        if not(x in range(-158,158)):
            continue
        y = math.sqrt(math.fabs(x**2-25000))
        y2 = math.sqrt(math.fabs((x+1)**2-25000))

        canv.create_line(x+300,300+y,x+300,300-y2,fill='green')
        canv.create_line(x+300,300-y,(x+1)+301,300-y2+1,width=2)
        canv.create_line(x+300,y+300,(x+1)+301,y2+300+1,width=2)

        
    
    y = math.sqrt(math.fabs((-158)**2-25000))
    canv.create_line(-158+300,y+300,-158+300,-y+300,width=2)
    y = math.sqrt(math.fabs((158)**2-25000))
    canv.create_line(159+300,y+300,159+300,-y+300,width=2)


def alpha1(x,y):
    if x == 0:
        return False
    
    if y+(4000/x)>=0:
        return True
    else:
        return False

def betta1(x,y):
    if x == 0:
        return False
    if y-(4000/x)<=0:
        return True
    else:
        return False

def zetta1(x,y):
    if y**2+x**2-25000<=0:
        return True
    else:
        return False

start_time = time.time()

root = Tk()

canv = Canvas(root, width=600, height=600, bg="white")
canv.create_line(300, 600, 300, 0, width=1, arrow=LAST) 
canv.create_line(0, 300, 600, 300, width=1, arrow=LAST) 
	 
# alpha(canv)
# betta(canv)
# zetta(canv)

for x in range(-300,300):
    for y in range(-300,300):
        if alpha1(x,y) and betta1(x,y) and (not zetta1(x,y)):
            canv.create_rectangle((x+300,y+300)*2)

canv.pack()	
print("--- %s seconds ---" % (time.time() - start_time))
root.mainloop()
