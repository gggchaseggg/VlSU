package com.example.lab6;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.Path;
import android.graphics.Rect;
import android.graphics.RectF;
import android.os.Bundle;
import android.view.MotionEvent;
import android.view.SurfaceHolder;
import android.view.SurfaceView;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        DrawView drawView = new DrawView(this);
        drawView.setOnTouchListener(drawView);
        setContentView(drawView);
    }

    class DrawView extends View implements View.OnTouchListener {

        Paint p;
        Rect rect;
        RectF rectF;
        float[] points;
        float[] points1;
        StringBuilder sb;
        Path path;
        Path[] paths;


        int upPI = 0;
        int downPI = 0;
        boolean inTouch = false;
        public DrawView(Context context) {
            super(context);
            p = new Paint();
//            rect = new Rect();
//            rectF = new RectF(700,100,800,150);
//            points = new float[]{100,50,150,100,150,200,50,200,50,100};
//            points1 = new float[]{300,200,600,200, 300,300,600,300,400,100,400,400,500,100,500,400};
//            rect = new Rect(100,200,200,300);
//            sb = new StringBuilder();
            path = new Path();
            paths = new Path[]{new Path(),new Path(),new Path(),new Path(),new Path(),new Path(),new Path(),new Path(),new Path(),new Path()};
        }



        @Override
        protected void onDraw(Canvas canvas) {
            canvas.drawARGB(80, 102, 204, 255);
            p.setColor(Color.MAGENTA);
            p.setStrokeWidth(10);
            p.setTextSize(30);
            p.setStyle(Pax`int.Style.STROKE);

            // Первый пример с примитивами
//            canvas.drawPoint(50,50, p);
//            canvas.drawLine(100,100,500,50,p);
//            canvas.drawCircle(100,200,50,p);
//            canvas.drawRect(200, 150, 400, 200, p);
//            rect.set(250, 300,350,500);
//            canvas.drawRect(rect,p);

            // Второй пример
//            canvas.drawPoints(points, p);
//            canvas.drawLines(points1, p);
//            canvas.drawRoundRect(rectF, 20, 20, p);
//            rectF.offset(0, 150);
//            canvas.drawOval(rectF,p);
//            rectF.offsetTo(900,100);
//            rectF.inset(0,-25);
//            canvas.drawArc(rectF, 90, 270, false, p);
//            canvas.drawText("левый текст", 150,500,p);
//            p.setTextAlign(Paint.Align.CENTER);
//            canvas.drawText("центральный текст", 150,525,p);
//            p.setTextAlign(Paint.Align.RIGHT);
//            canvas.drawText("правый текст", 150,550,p);

            // Третий пример
//            sb.setLength(0);
//            sb.append("Ширина = ")
//                    .append(canvas.getWidth())
//                    .append(", Высота = ")
//                    .append(canvas.getHeight());
//            canvas.drawText(sb.toString(), 100, 100, p);
//            p.setStyle(Paint.Style.FILL);
//            canvas.drawRect(rect, p);
//            p.setStyle(Paint.Style.STROKE);
//            rect.offset(150,0);
//            canvas.drawRect(rect, p);
//            p.setStyle(Paint.Style.FILL_AND_STROKE);
//            rect.offset(150,0);
//            canvas.drawRect(rect, p);

            // Задание 6 лабораторная
//            path.moveTo(0, 54*2);
//            path.lineTo(62*2, 54*2);
//            path.lineTo(80*2, 0);
//            path.lineTo(98*2, 54*2);
//            path.lineTo(160*2, 54*2);
//            path.lineTo(110*2, 90*2);
//            path.lineTo(130*2, 148*2);
//            path.lineTo(80*2, 112*2);
//            path.lineTo(30*2, 148*2);
//            path.lineTo(50*2, 90*2);
//            path.close();
//
//            path.moveTo(300*2, 0);
//            path.lineTo(395.10565F*2, 69.0983F*2);
//            path.lineTo(358.778F*2, 180.9017F*2);
//            path.lineTo(241.222F*2, 180.9017F*2);
//            path.lineTo(204.89435F*2, 69.0983F*2);
//            path.close();
            for (int i = 0; i < 10; i++) {
                if (!paths[i].isEmpty()) {
                    canvas.drawPath(paths[i], p);
                }
            }

        }

        @Override
        public boolean onTouch(View v, MotionEvent event) {
            int actionMask = event.getActionMasked();
            int pointerIndex = event.getActionIndex();
            int pointerId = event.getPointerId(pointerIndex);
            int pointerCount = event.getPointerCount();

            switch (actionMask) {
                case MotionEvent.ACTION_DOWN:
                case MotionEvent.ACTION_POINTER_DOWN:
                    paths[pointerId].moveTo(event.getX(), event.getY());
                    break;
                case MotionEvent.ACTION_MOVE:
                    for (int i = 0; i < 10; i++) {
                        if (i < pointerCount) {
                            paths[i].lineTo(event.getX(i), event.getY(i));
                        }
                    }
                    break;
                case MotionEvent.ACTION_UP:
                case MotionEvent.ACTION_POINTER_UP:
//                    paths[pointerIndex] = new Path();
                    break;
            }
            invalidate();

            return true;
        }
    }

}