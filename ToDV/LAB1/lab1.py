from tkinter import *

def alpha(x,y):
    if x == 0:
        return False
    
    if y+(4000/x)>=0:
        return True
    else:
        return False

def betta(x,y):
    if x == 0:
        return False
    if y-(4000/x)<=0:
        return True
    else:
        return False

def zetta(x,y):
    if y**2+x**2-25000<=0:
        return True
    else:
        return False

root = Tk()

canv = Canvas(root, width=600, height=600, bg="white")
canv.create_line(300, 600, 300, 0, width=1, arrow=LAST) 
canv.create_line(0, 300, 600, 300, width=1, arrow=LAST) 
	 
for x in range(-300,300):
    for y in range(-300,300):
        if alpha(x,y) and betta(x,y) and (not zetta(x,y)):
            canv.create_rectangle((x+300,y+300)*2)

canv.pack()	
root.mainloop()
