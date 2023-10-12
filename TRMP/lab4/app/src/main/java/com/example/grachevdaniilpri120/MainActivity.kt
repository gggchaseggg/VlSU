package com.example.grachevdaniilpri120

import android.hardware.Sensor
import android.hardware.SensorEvent
import android.hardware.SensorEventListener
import android.hardware.SensorManager
import android.os.Bundle
import android.util.DisplayMetrics
import android.widget.Button
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity


class MainActivity : AppCompatActivity(), SensorEventListener {

    var mAccelerometerX: TextView? = null
    var mAccelerometerY: TextView? = null
    var mAccelerometerZ: TextView? = null
    var mMagneticX: TextView? = null
    var mMagneticY: TextView? = null
    var mMagneticZ: TextView? = null
    var mProximity: TextView? = null
    var mLight: TextView? = null
    var sensorManager: SensorManager? = null
    var mAccelerometerSensor: Sensor? = null
    var mProximitySensor: Sensor? = null
    var mMagneticSensor: Sensor? = null
    var mLightSensor: Sensor? = null
    var mMaxValue = 0f
    var mValue = 0f

    var button: Button? = null

    var displaymetrics = DisplayMetrics()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        mAccelerometerX = findViewById<TextView>(R.id.AccelerometerX);
        mAccelerometerY = findViewById<TextView>(R.id.AccelerometerY);
        mAccelerometerZ = findViewById<TextView>(R.id.AccelerometerZ);
        mMagneticX = findViewById<TextView>(R.id.magneticX);
        mMagneticY = findViewById<TextView>(R.id.magneticY);
        mMagneticZ = findViewById<TextView>(R.id.magneticZ);
        mProximity = findViewById<TextView>(R.id.proximity);
        mLight = findViewById<TextView>(R.id.light);

        button = findViewById<Button>(R.id.button)

        sensorManager = getSystemService(SENSOR_SERVICE) as SensorManager?;
        mAccelerometerSensor = sensorManager?.getDefaultSensor(Sensor.TYPE_ACCELEROMETER);
        mMagneticSensor = sensorManager?.getDefaultSensor(Sensor.TYPE_MAGNETIC_FIELD);
        mProximitySensor = sensorManager?.getDefaultSensor(Sensor.TYPE_PROXIMITY);
        mLightSensor = sensorManager?.getDefaultSensor(Sensor.TYPE_LIGHT);
        mMaxValue = mLightSensor!!.maximumRange;
    }

    override fun onSensorChanged(event: SensorEvent?) {
        if (event?.sensor?.type === Sensor.TYPE_ACCELEROMETER) {
            try {
                windowManager.defaultDisplay.getMetrics(displaymetrics);
                val screenWidth = displaymetrics.widthPixels
                val screenHeight = displaymetrics.heightPixels
                if (button?.x!! > screenWidth - 120) {
                    button?.x = 0F
                } else {
                    button?.x = button?.x?.plus(-event.values[0].toInt())!!
                }

                if (button?.y!! > screenHeight - 120) {
                    button?.y = 0F
                } else {
                    button?.y = button?.y?.plus(event.values[1].toInt())!!
                }
            } catch (e: Exception) {

            }

            mAccelerometerX!!.text = event.values[0].toString()
            mAccelerometerY!!.text = event.values[1].toString()
            mAccelerometerZ!!.text = event.values[2].toString()
        }
        if (event?.sensor?.type === Sensor.TYPE_MAGNETIC_FIELD) {
            mMagneticX!!.text = event.values[0].toString()
            mMagneticY!!.text = event.values[1].toString()
            mMagneticZ!!.text = event.values[2].toString()
        }
        if (event?.sensor?.type === Sensor.TYPE_PROXIMITY) {
            mProximity!!.text = event.values[0].toString()
        }
        if (event?.sensor?.type === Sensor.TYPE_LIGHT) {
            mLight!!.text = event.values[0].toString()
            mValue = event.values[0]
            val layout = window.attributes
            layout.screenBrightness = (255f * mValue / mMaxValue).toInt().toFloat()
            window.attributes = layout
        }
    }

    override fun onStart() {
        super.onStart()
        sensorManager?.registerListener(this, mAccelerometerSensor, SensorManager.SENSOR_DELAY_NORMAL);
        sensorManager?.registerListener(this, mMagneticSensor, SensorManager.SENSOR_DELAY_NORMAL);
        sensorManager?.registerListener(this, mProximitySensor, SensorManager.SENSOR_DELAY_NORMAL);
        sensorManager?.registerListener(this, mLightSensor, SensorManager.SENSOR_DELAY_NORMAL);
    }

    override fun onStop() {
        super.onStop()
        sensorManager?.unregisterListener(this, mAccelerometerSensor);
        sensorManager?.unregisterListener(this, mMagneticSensor);
        sensorManager?.unregisterListener(this, mProximitySensor);
        sensorManager?.unregisterListener(this, mLightSensor);
    }

    override fun onAccuracyChanged(p0: Sensor?, p1: Int) {
//        TODO("Not yet implemented")
    }
}