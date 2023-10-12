package com.example.lab5;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.view.ViewGroup.LayoutParams;
import android.widget.TextView;

import java.util.Date;

public class MainActivity extends AppCompatActivity {

    final String LOG_TAG = "myLogs";
    Button mBtnAdd, mBtnRead, mBtnClear;
    EditText mEdtName, mEdtEmail;
    DBHelper mDbHelper;
    TableLayout mTableLayout;

    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        mBtnAdd = (Button) findViewById(R.id.buttonAdd);
        mBtnAdd.setOnClickListener(this::onClick);
        mBtnRead = (Button) findViewById(R.id.buttonRead);
        mBtnRead.setOnClickListener(this::onClick);
        mBtnClear = (Button) findViewById(R.id.buttonClear);
        mBtnClear.setOnClickListener(this::onClick);
        mEdtName = (EditText) findViewById(R.id.editTextName);
        mEdtEmail = (EditText) findViewById(R.id.editTextEmail);
        mTableLayout = (TableLayout) findViewById(R.id.tableLayout);
        mDbHelper = new DBHelper(this);
    }

    @SuppressLint("NonConstantResourceId")
    public void onClick(View v) {
        // создаем объект для данных
        ContentValues cv = new ContentValues();
        // получаем данные из полей ввода
        String name = mEdtName.getText().toString();
        String email = mEdtEmail.getText().toString();
        // подключаемся к БД
        SQLiteDatabase db = mDbHelper.getWritableDatabase();
        if (v.getId() == R.id.buttonAdd) {
            Log.d(LOG_TAG, "--- Insert in mytable: ---");
            // подготовим данные для вставки в виде пар: наименование столбца -
            // значение
            cv.put("name", name);
            cv.put("email", email);
            cv.put("date", new Date().toString());
            // вставляем запись и получаем ее ID
            long rowID = db.insert("mytable", null, cv);
            Log.d(LOG_TAG, "row inserted, ID = " + rowID);
        }
        if (v.getId() == R.id.buttonRead) {
            Log.d(LOG_TAG, "--- Rows in mytable: ---");
            // делаем запрос всех данных из таблицы mytable, получаем Cursor
            Cursor c = db.query("mytable", null, null, null, null, null, null);
            // ставим позицию курсора на первую строку выборки
            // если в выборке нет строк, вернется false
            if (c.moveToFirst()) {
                // определяем номера столбцов по имени в выборке
                int idColIndex = c.getColumnIndex("id");
                int nameColIndex = c.getColumnIndex("name");
                int emailColIndex = c.getColumnIndex("email");
                int dateColIndex = c.getColumnIndex("date");
                do {
                    // получаем значения по номерам столбцов и пишем все в лог
                    Log.d(LOG_TAG,
                            "ID = " + c.getInt(idColIndex) + ", name = "
                                    + c.getString(nameColIndex) + ", email = "
                                    + c.getString(emailColIndex) + ", date = "
                                    + c.getString(dateColIndex));
                    // переход на следующую строку
                    // а если следующей нет (текущая - последняя), то false -
                    // выходим из цикла

                    TableRow tableRow = new TableRow(this);
                    tableRow.setLayoutParams(new LayoutParams(LayoutParams.MATCH_PARENT,
                            LayoutParams.WRAP_CONTENT));
                    TextView textView1 = new TextView(this);
                    textView1.setText(String.valueOf(c.getInt(idColIndex)));
                    tableRow.addView(textView1);
                    TextView textView2 = new TextView(this);
                    textView2.setText(c.getString(nameColIndex));
                    tableRow.addView(textView2);
                    TextView textView3 = new TextView(this);
                    textView3.setText(c.getString(emailColIndex));
                    tableRow.addView(textView3);
                    TextView textView4 = new TextView(this);
                    textView4.setText(c.getString(dateColIndex));
                    tableRow.addView(textView4);
                    mTableLayout.addView(tableRow);
                } while (c.moveToNext());
            } else
                Log.d(LOG_TAG, "0 rows");
            c.close();
        }
        if (v.getId() == R.id.buttonClear) {
            Log.d(LOG_TAG, "--- Clear mytable: ---");
            // удаляем все записи
            int clearCount = db.delete("mytable", null, null);
            Log.d(LOG_TAG, "deleted rows count = " + clearCount);
        }
        // закрываем подключение к БД
        mDbHelper.close();
    }

    class DBHelper extends SQLiteOpenHelper {
        public DBHelper(Context context) {
            // конструктор суперкласса
            super(context, "myDB", null, 1);
        }

        public void onCreate(SQLiteDatabase db) {
            Log.d(LOG_TAG, "--- onCreate database ---");
            // создаем таблицу с полями
//            db.execSQL("drop table mytable");
            db.execSQL("create table mytable (id integer primary key autoincrement, name text, email text, date text);");
        }

        public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        }
    }
}