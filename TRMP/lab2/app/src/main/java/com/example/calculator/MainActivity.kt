package com.example.calculator

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.EditText
import java.io.Console
import kotlin.math.sqrt

class MainActivity : AppCompatActivity() {
    var mButton0: Button? = null
    var mButton1: Button? = null
    var mButton2: Button? = null
    var mButton3: Button? = null
    var mButton4: Button? = null
    var mButton5: Button? = null
    var mButton6: Button? = null
    var mButton7: Button? = null
    var mButton8: Button? = null
    var mButton9: Button? = null
    var mButtonPoint: Button? = null
    var mButtonAdd: Button? = null
    var mButtonSub: Button? = null
    var mButtonDiv: Button? = null
    var mButtonMul: Button? = null
    var mButtonEq: Button? = null
    var mEditText: EditText? = null
    var mButtonDel: Button? = null
    var mButtonSqrt: Button? = null
    var mButtonPow: Button? = null
    var mValueOne = 0f
    var mValueTwo = 0f
    var mAddition = false
    var mSubtract = false
    var mMultiplication = false
    var mDivision = false

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        mButton0 = findViewById<View>(R.id.button0) as Button
        mButton1 = findViewById<View>(R.id.button1) as Button
        mButton2 = findViewById<View>(R.id.button2) as Button
        mButton3 = findViewById<View>(R.id.button3) as Button
        mButton4 = findViewById<View>(R.id.button4) as Button
        mButton5 = findViewById<View>(R.id.button5) as Button
        mButton6 = findViewById<View>(R.id.button6) as Button
        mButton7 = findViewById<View>(R.id.button7) as Button
        mButton8 = findViewById<View>(R.id.button8) as Button
        mButton9 = findViewById<View>(R.id.button9) as Button
        mButtonPoint = findViewById<View>(R.id.buttonPoint) as Button
        mButtonAdd = findViewById<View>(R.id.buttonAdd) as Button
        mButtonSub = findViewById<View>(R.id.buttonSub) as Button
        mButtonMul = findViewById<View>(R.id.buttonMul) as Button
        mButtonDiv = findViewById<View>(R.id.buttonDiv) as Button
        mButtonEq = findViewById<View>(R.id.buttonEq) as Button
        mButtonDel = findViewById<View>(R.id.buttonDel) as Button
        mButtonSqrt = findViewById<View>(R.id.buttonSqrt) as Button
        mButtonPow = findViewById<View>(R.id.buttonPow) as Button
        mEditText = findViewById<View>(R.id.editText) as EditText
        mButton1!!.setOnClickListener { mEditText!!.setText(mEditText!!.text.toString() + "1") }
        mButton2!!.setOnClickListener { mEditText!!.setText(mEditText!!.text.toString() + "2") }
        mButton3!!.setOnClickListener { mEditText!!.setText(mEditText!!.text.toString() + "3") }
        mButton4!!.setOnClickListener { mEditText!!.setText(mEditText!!.text.toString() + "4") }
        mButton5!!.setOnClickListener { mEditText!!.setText(mEditText!!.text.toString() + "5") }
        mButton6!!.setOnClickListener { mEditText!!.setText(mEditText!!.text.toString() + "6") }
        mButton7!!.setOnClickListener { mEditText!!.setText(mEditText!!.text.toString() + "7") }
        mButton8!!.setOnClickListener { mEditText!!.setText(mEditText!!.text.toString() + "8") }
        mButton9!!.setOnClickListener { mEditText!!.setText(mEditText!!.text.toString() + "9") }
        mButton0!!.setOnClickListener { mEditText!!.setText(mEditText!!.text.toString() + "0") }
        mButtonAdd!!.setOnClickListener {
            if (mEditText == null) {
                mEditText!!.setText("")
            } else if (!mAddition){
                mValueOne = (mEditText!!.text.toString() + "").toFloat()
                mAddition = true
                mEditText!!.setText(null)
            }
        }
        mButtonDel!!.setOnClickListener {
            if (mEditText == null) {
                mEditText!!.setText("")
            } else {
                mEditText!!.setText(mEditText!!.text.dropLast(1))
            }
        }
        mButtonSqrt!!.setOnClickListener {
            if (mEditText == null) {
                mEditText!!.setText("")
            } else {
                mEditText!!.setText(sqrt(mEditText!!.text.toString().toDouble()).toString())
            }
        }
        mButtonPow!!.setOnClickListener {
            if (mEditText == null) {
                mEditText!!.setText("")
            } else {
                mEditText!!.setText(Math.pow(mEditText!!.text.toString().toDouble(), 2.0).toString())
            }
        }
        mButtonSub!!.setOnClickListener {
            if (mEditText == null) {
                mEditText!!.setText("")
            } else if (!mSubtract) {
                mValueOne = (mEditText!!.text.toString() + "").toFloat()
                mSubtract = true
                mEditText!!.setText(null)
            }
        }
        mButtonMul!!.setOnClickListener {
            if (mEditText == null) {
                mEditText!!.setText("")
            } else if (!mMultiplication) {
                mValueOne = (mEditText!!.text.toString() + "").toFloat()
                mMultiplication = true
                mEditText!!.setText(null)
            }
        }
        mButtonDiv!!.setOnClickListener {
            if (mEditText == null) {
                mEditText!!.setText("")
            } else if (!mDivision){
                mValueOne = (mEditText!!.text.toString() + "").toFloat()
                mDivision = true
                mEditText!!.setText(null)
            }
        }
        mButtonEq!!.setOnClickListener {
            mValueTwo = (mEditText!!.text.toString() + "").toFloat()
            if (mAddition == true) {
                mEditText!!.setText((mValueOne + mValueTwo).toString() + "")
                mAddition = false
            }
            if (mSubtract == true) {
                mEditText!!.setText((mValueOne - mValueTwo).toString() + "")
                mSubtract = false
            }
            if (mMultiplication == true) {
                mEditText!!.setText((mValueOne * mValueTwo).toString() + "")
                mMultiplication = false
            }
            if (mDivision == true) {
                mEditText!!.setText((mValueOne / mValueTwo).toString() + "")
                mDivision = false
            }
        }
        mButtonPoint!!.setOnClickListener { mEditText!!.setText(mEditText!!.text.toString() + ".") }
    }
}