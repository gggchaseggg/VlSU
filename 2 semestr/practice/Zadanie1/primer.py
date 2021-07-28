from PIL import Image, ImageDraw
import numpy as np
import cv2

videoDimensions = (1280,720)
videoFps = 75
videoCodec = "avc1"
videoFilename = "frac.mp4"
videoLength = 10
videoFourcc = cv2.VideoWriter_fourcc(*videoCodec)
video = cv2.VideoWriter(videoFilename, videoFourcc, videoFps, videoDimensions)

img = Image.new("RGB", videoDimensions, color = "white")
imgDrawer = ImageDraw.Draw(img)
frame = img.copy()
frameDrawer = ImageDraw.Draw(frame)

def draw_one_rect(A,B,C,D):
    frameDrawer.polygon([A,B,C,D], None, 3)
    video.write(cv2.cvtColor(np.array(frame), cv2.COLOR_RGB2BGR))

def square_1(A,B,C,D,k,n,totalPercent):
    if k != n:
        draw_one_rect(A,B,C,D)
        A1 = ( round( (-A[0] + B[0])*9/10 + A[0] ), round( (-A[1] + B[1])*9/10 + A[1] ) )
        B1 = ( round( (-B[0] + C[0])*9/10 + B[0] ), round( (-B[1] + C[1])*9/10 + B[1] ) )
        C1 = ( round( (-C[0] + D[0])*9/10 + C[0] ), round( (-C[1] + D[1])*9/10 + C[1] ) )
        D1 = ( round( (-D[0] + A[0])*9/10 + D[0] ), round( (-D[1] + A[1])*9/10 + D[1] ) )
        currentPercent = round(k / n * 100)
        if currentPercent > totalPercent:
            totalPercent = currentPercent
            print(f"{currentPercent}% выполнено ")
        square_1(A1,B1,C1,D1,k+1,n,totalPercent)

totalPercent = 0
A = (0,0)
B = (1000,0)
C = (1000,1000)
D = (0,1000)
square_1(A,B,C,D,0,500,totalPercent)
video.release()
print("Video with name output1.mp4 has been done")
