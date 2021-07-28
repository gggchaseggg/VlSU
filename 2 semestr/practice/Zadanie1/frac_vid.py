from PIL import Image, ImageDraw
import numpy as np
import cv2

videoDimensions = (1280,720)
videoFps = 75
videoCodec = "avc1"
videoFilename = "frac.mp4"
videoFourcc = cv2.VideoWriter_fourcc(*videoCodec)
video = cv2.VideoWriter(videoFilename, videoFourcc, videoFps, videoDimensions)

img = Image.new("RGB", videoDimensions, color = "#FFBD9B")
imgDrawer = ImageDraw.Draw(img)
frame = img.copy()
frameDrawer = ImageDraw.Draw(frame)

def sq_fr(A,B,C,D,deep=10,alpha=0.1,k=0,totalPercent=0):
    '''
    Построение фрактала квадрата по 4 точкам\n
    deep - глубина\n
    alpha - коэффициент погружения(>1 - расширяется, <1 - уменьшается) 
    '''
    if deep < 1:
        return
    draw.polygon([A,B,C,D], None, 3)

    A1 = (A[0]*(1-alpha)+B[0]*alpha, A[1]*(1-alpha)+B[1]*alpha)
    B1 = (B[0]*(1-alpha)+C[0]*alpha, B[1]*(1-alpha)+C[1]*alpha)
    C1 = (C[0]*(1-alpha)+D[0]*alpha, C[1]*(1-alpha)+D[1]*alpha)
    D1 = (D[0]*(1-alpha)+A[0]*alpha, D[1]*(1-alpha)+A[1]*alpha)
    
    frameDrawer.polygon([A,B,C,D], None, 3)
    video.write(cv2.cvtColor(np.array(frame), cv2.COLOR_RGB2BGR))

    currentPercent = round(k / 900 * 100)
    if currentPercent > totalPercent:
        totalPercent = currentPercent
        print(f"{currentPercent}% выполнено ")

    sq_fr(A1,B1,C1,D1,deep-1,alpha,k+1,totalPercent)

img = Image.new("RGB", (700,700), "white")
draw = ImageDraw.Draw(img)

A = (5,5)
B = (695,5)
C = (695,695)
D = (5,695)
sq_fr(A,B,C,D,deep=900,alpha=0.005)
video.release()
print(f"\nВидео с названием {videoFilename} готово!")