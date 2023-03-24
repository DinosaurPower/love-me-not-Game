using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class SerialFlower : MonoBehaviour
{

    public String portName = "COM15";  // 1. use the port name for your Arduino, such as /dev/tty.usbmodem1411 for Mac or COM3 for PC, make sure to update it in the inspector
    private SerialPort serialPort = null; 
    private int baudRate = 115200;  // 2. match your rate from your serial in Arduino
    private int readTimeOut = 100;

    private string serialInput;

    bool programActive = true;
    Thread thread;

    bool close = false;

    void Start()
    {
        try
        {
            serialPort = new SerialPort();
            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
            serialPort.RtsEnable = true;
            serialPort.ReadTimeout = readTimeOut;
            serialPort.Open();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        thread = new Thread(new ThreadStart(ProcessData));  // serial events are now handled in a separate thread
        thread.Start();
        
        //stop the animation from playing setting the speed = 0; 
       
    }

    void ProcessData()
    {
        Debug.Log("Thread: Start");
        while (programActive)
        {
            try
            {
                serialInput = serialPort.ReadLine();
            }
            catch (TimeoutException)
            {

            }
        }
        Debug.Log("Thread: Stop");
    }

    void Update()
    {
        if (serialInput != null)
        {
            string[] strEul = serialInput.Split(';');  // 3. splite the data into an arrey using semicolon ' ; '
            if (strEul.Length == 6) // 4. only move forward if every input expected has been received. In this case, was have 2 inputs - a button (0 or 1) and an analog values between 0 and 1023
            {

                for (int i = 0; i<strEul.Length; i++){
                    float readout = float.Parse(strEul[i]);
                    
                }
                //5. insert your game logic here
                float readout = float.Parse(strEul[0]);
                readout = Mathf.Clamp(readout, 200f, 824f);
                readout = map(readout, 200f, 824f, -0f, 1f);
               
                
              
                if (readout > 0.65f && !close)
                {
                   
                    close = true;
                }
                if (readout < 0.65f)
                {

                    close = false;
                }

                //Debug.Log(dist);
            }
        }
    }

    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }

    public void OnDisable()  // attempts to closes serial port when the gameobject script is on goes away
    {
        programActive = false;
        if (serialPort != null && serialPort.IsOpen)
            serialPort.Close();
    }
}