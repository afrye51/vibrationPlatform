/*
Example 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vibration_test : MonoBehaviour
{
	private Vibration_platform_serial cereal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            bool ret = cereal.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            cereal.Individual(1, 60);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            cereal.All(60);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            cereal.Direction(75, 60);
        }
    }
}
