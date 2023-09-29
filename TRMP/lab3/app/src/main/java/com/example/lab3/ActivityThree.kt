package com.example.lab3

import android.content.Intent
import android.os.Bundle
import android.view.View
import android.widget.EditText
import androidx.appcompat.app.AppCompatActivity


class ActivityThree: AppCompatActivity() {
    var mEditText: EditText? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_three)
    }

    fun back(view: View?) {
        mEditText = findViewById<View>(R.id.editText) as EditText
        val message = mEditText!!.getText().toString()
        val intent = Intent(this@ActivityThree, MainActivity::class.java)
        intent.putExtra("message", message)
        startActivity(intent)
    }
}