from PIL import Image,ImageDraw

img = Image.new("RGB",(500,500),"white")

draw = ImageDraw.Draw(img)
draw.line([(0,0),(100,100),(200,100)],"red",5)
draw.arc([(200,100),(300,200)],0,90,"blue",2)
draw.chord([(250,150),(350,250)],0,90,None,"blue",2)
draw.ellipse([(50,150),(200,200)],"green",None,0)
draw.point([(250,250)],"magenta")
draw.rectangle([(50,300),(100,350)],"magenta","green",2)
draw.polygon([(400,400),(400,500),(500,500)],"magenta",None)

img.show()