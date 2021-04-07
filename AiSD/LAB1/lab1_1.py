from tkinter import *

def fractal(A,B,C,D,deep=10,alpha=0.1):
    '''
    Построение фрактала квадрата по 4 точкам\n
    deep - глубина\n
    alpha - коэффициент погружения(>1 - расширяется, <1 - уменьшается) 
    '''
    if deep < 1:
        return
    for M, N in (A,B),(B,C),(C,D),(D,A):
        canv.create_line([*M],[*N])

    A1 = (A[0]*(1-alpha)+B[0]*alpha, A[1]*(1-alpha)+B[1]*alpha)
    B1 = (B[0]*(1-alpha)+C[0]*alpha, B[1]*(1-alpha)+C[1]*alpha)
    C1 = (C[0]*(1-alpha)+D[0]*alpha, C[1]*(1-alpha)+D[1]*alpha)
    D1 = (D[0]*(1-alpha)+A[0]*alpha, D[1]*(1-alpha)+A[1]*alpha)
    fractal(A1,B1,C1,D1,deep-1,alpha)

root = Tk()

canv = Canvas(root, width=700, height=700, bg="white")

fractal((5,5),(695,5),(695,695),(5,695),deep=994,alpha=0.01)

canv.pack()
root.mainloop()
