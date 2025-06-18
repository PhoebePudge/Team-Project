using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//find all xbox 360 controllers connected to the computer and reasighn them if nessisary
public class ControllerDetection : MonoBehaviour
{
    public int validControllers = 0;
    // Start is called before the first frame update
    void Awake()
    {
        string[] names = Input.GetJoystickNames();
        string Output = "";
        for (int x = 0; x < names.Length; x++)
        {
            switch (names[x].Length)
            {
                case 19: //PS4 controller detection
                    print("PS4 CONTROLLER IS CONNECTED AT " + x.ToString());
                    if (x > 4) {
                        Output = Output + "INVALID PS4 CONTROLLER IS CONNECTED AT " + x.ToString() + "\n";
                    }else {
                        Output = Output + "VALID PS4 CONTROLLER IS CONNECTED AT " + x.ToString() + "\n";
                        validControllers++;
                    }
                    break;
                case 33: //XBOX Controller detection
                    print("XBOX 360 CONTROLLER IS CONNECTED AT " + x.ToString());
                    if (x > 4) {
                        Output = Output + "INVALID XBOX 360 CONTROLLER IS CONNECTED AT " + x.ToString() + "\n";
                    } else {
                        Output = Output + "VALID XBOX 360 CONTROLLER IS CONNECTED AT " + x.ToString() + "\n";
                        validControllers++;
                    }
                    break;
                case 27: //Inno Gamepad detection
                    print("INNO GAMEPAD CONTROLLER IS CONNECTED AT " + x.ToString());
                    if (x > 4) {
                        Output = Output + "INVALID INNO GAMEPAD CONTROLLER IS CONNECTED AT " + x.ToString() + "\n";
                    } else {
                        Output = Output + "VALID INNO GAMEPAD CONTROLLER IS CONNECTED AT " + x.ToString() + "\n";
                        validControllers++;
                    }
                    break;
                default:
                    if (names[x].Length != 0) {
                        print("Unknown CONTROLLER IS CONNECTED AT " + x.ToString());
                        if (x > 4) {
                            Output = Output + "INVALID Unknown CONTROLLER IS CONNECTED AT \n" + x.ToString();
                        } else {
                            Output = Output + "VALID Unknown CONTROLLER IS CONNECTED AT \n" + x.ToString();
                            validControllers++;
                        }
                    }
                    break;
            }
        }
        //Create a new popup to display the information found
        new Popup(validControllers + " Controllers Connected", Output, 5);
    }

    // Update is called once per frame
    void Update()
    {
    }

}
