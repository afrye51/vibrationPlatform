/*
Vibration_platform_serial class
Defines 4 methods to communicate with the vibration platform over serial

(1) Stop - Sets all motors to motor power 0
    Inputs - N/A
    Outputs - Boolean (if inputs are valid)
(2) Individual - Pass in motor (0 to 3), motor power (0 to 255)
    Inputs - Motor number (Integer 0 to 3)
        Motor power (integer 0 to 255)
    Outputs - Boolean (if inputs are valid)
(3) All - Pass in motor power (0 to 255)
    Inputs -  Motor power (integer 0 to 255)
    Outputs - Boolean (if inputs are valid)
(4) Direction - Pass in angle (in degrees) and motor power (0 to 255)
    Inputs - Angle (Integer -360 to 360)
        Motor power (integer 0 to 255)
    Outputs - Boolean (if inputs are valid)
*/

using UnityEngine;
using System.Collections;

public class Vibration_platform_serial : MonoBehaviour
{
    public SerialController serialController;

    // Initialization
    void Start()
    {
        serialController = GameObject.Find("GameObject").GetComponent<SerialController>();

        Debug.Log("Press 1-5 to execute some actions");
    }

    public bool Stop()
    {
        Debug.Log("Sending stop message");
        serialController.SendSerialMessage("1Q");
        return true;
    }

    // Run an individual motor (0 - 3) at a power (0 - 255)
    public bool Individual(int motor, int power)
    {
        if(motor < 0 || motor > 3)
        {
            return false;
        }
        if(power < 0 || power > 255)
        {
            return false;
        }
        string msg = "2," + motor.ToString() + "," + power.ToString() + "Q";
        Debug.Log("Sending " + msg);
        serialController.SendSerialMessage(msg);
        return true;
    }

    // Run an individual motor (0 - 3) at a power (0 - 255)
    public bool All(int power)
    {
        // If power is outside the range of (0-255), return failure
        if(power < 0 || power > 255)
        {
            return false;
        }
        string msg = "3," + power.ToString() + "Q";
        Debug.Log("Sending " + msg);
        serialController.SendSerialMessage(msg);
        return true;
    }

    // Run an individual motor (0 - 3) at a power (0 - 255)
    public bool Direction(int angle, int power)
    {
        angle = angle % 360;
        if(power < 0 || power > 255)
        {
            return false;
        }
        string msg = "4," + angle.ToString() + "," + power.ToString() + "Q";
        Debug.Log("Sending " + msg);
        serialController.SendSerialMessage(msg);
        return true;
    }

    // Executed each frame
    void Update()
    {

    }

    void OnMessageArrived(string msg)
    {
        Debug.Log("Message arrived: " + msg);
    }
}
