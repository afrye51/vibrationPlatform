/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;

/**
 * Sample for reading using polling by yourself, and writing too.
 */
public class serial_back_forth : MonoBehaviour
{
    public SerialController serialController;

    // Initialization
    void Start()
    {
        serialController = GameObject.Find("GameObject").GetComponent<SerialController>();

        serialController.SetTearDownFunction(lightsShutdown);

        Debug.Log("Press 1-5 to execute some actions");
    }

    // Executed each frame
    void Update()
    {
        //---------------------------------------------------------------------
        // Send data
        //---------------------------------------------------------------------

        // If you press one of these keys send it to the serial device. A
        // sample serial device that accepts this input is given in the README.
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            Debug.Log("Sending 1");
            serialController.SendSerialMessage("1Q");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            Debug.Log("Sending 2,1,80");
            serialController.SendSerialMessage("2,1,60Q");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            Debug.Log("Sending 3,80");
            serialController.SendSerialMessage("3,60Q");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            Debug.Log("Sending 4,0,100");
            serialController.SendSerialMessage("4,0,60Q");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            Debug.Log("Sending 5,0,100");
            serialController.SendSerialMessage("5,0,60Q");
        }


        //---------------------------------------------------------------------
        // Receive data
        //---------------------------------------------------------------------

        /*string message = serialController.ReadSerialMessage();

        if (message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else
            Debug.Log("Message arrived: " + message);*/
    }

    // Tear-down function for the hardware at the other side of the COM port
    public void lightsShutdown()
    {
        Debug.Log("Executing teardown");
        serialController.SendSerialMessage("X");
    }

    void OnMessageArrived(string msg)
    {
        Debug.Log("Message arrived: " + msg);
    }
}
