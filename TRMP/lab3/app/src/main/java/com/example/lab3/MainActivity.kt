package com.example.lab3

import android.content.Intent
import android.os.Bundle
import android.view.View
import android.widget.EditText
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity


class MainActivity : AppCompatActivity(), View.OnClickListener {
    var mEditText: EditText? = null
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        val mButton1 = findViewById<View>(R.id.button)
        val mButton2 = findViewById<View>(R.id.button1)
        val mTextView = findViewById<View>(R.id.textView) as TextView
        mTextView.text = intent.getSerializableExtra("message") as String?
        mButton1.setOnClickListener(this)
        mButton2.setOnClickListener(this)
    }

    override fun onClick(view: View) {
        if (view.getId() == R.id.button) {
            mEditText = findViewById<View>(R.id.editText) as EditText
            val message = mEditText!!.getText().toString()
            val intent = Intent(applicationContext, ActivityTwo::class.java)
            intent.putExtra("message", message)
            startActivityForResult(intent, 2)
        }
        if (view.getId() == R.id.button1) {
            val intent = Intent(applicationContext, ActivityThree::class.java)
            startActivityForResult(intent, 3)
        }
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)
        val e = data?.getStringExtra("message")
        if (requestCode == 2 || requestCode == 3) {
            val mTextView = findViewById<View>(R.id.textView) as TextView
            if (e != null) mTextView.setText(e.toString())
        }

    }
}