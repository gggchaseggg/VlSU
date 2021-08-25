import numpy as np
from PIL import Image, ImageDraw
import cv2

videoDimensions = (1280,720)
videoFps = 75
videoCodec = "avc1"
videoFilename = "output.mp4"
videoLength = 3
videoFourcc = cv2.VideoWriter_fourcc(*videoCodec)
video = cv2.VideoWriter(videoFilename, videoFourcc, videoFps, videoDimensions)

img = Image.new("RGB", videoDimensions, color = "#FFBD9B")
imgDrawer = ImageDraw.Draw(img)
imgDrawer.line([(0,360), (1280,360)], fill = "#0A1D37", width = 1)

totalPercent = 0

for frameNumber in range(0, videoFps*videoLength):
    frame = img.copy()
    frameDrawer = ImageDraw.Draw(frame)
    shift = (frameNumber / videoFps) * (1330 / videoLength)
    frameDrawer.ellipse([(-50 + shift, 310), (shift, 360)], fill = "#0A1D37")
    
    video.write(cv2.cvtColor(np.array(frame), cv2.COLOR_RGB2BGR))
    
    currentPercent = round(frameNumber / (videoFps*videoLength)*100)
    if currentPercent > totalPercent:
        totalPercent = currentPercent
        print(f"{currentPercent}% выполнено ")

video.release()
print(f"\nВидео с названием {videoFilename} готово!")
