using UnityEngine;
using System.Collections;

//SCRIPT FOR XBOX 360 CONTROLLER INPUT MANAGER
public static class InputManager
{
    //Right trigger script
    public static float RTrigger()
    {
        float r = 0.0f;
        r += Input.GetAxis("R_Trigger");
        //return the amount of the trigger axis
        return Mathf.Clamp(r, 0.0f, 1.0f);
    }

    //Getting the axis from the joysticks
    //mainHorizontal because we're only able to pull 1 axis at a time, X or Y
    public static float MainHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainHorizontal");
        r += Input.GetAxis("K_MainHorizontal");

        //prevent the use of keyboard AND joypad at the same time
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float MainVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainVertical");
        r += Input.GetAxis("K_MainVertical");

        //prevent the use of keyboard AND joypad at the same time
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 MainJoystick()
    {
        return new Vector3(MainHorizontal(), 0, MainVertical());
    }


    //Script for getting booleans for A, B, X, Y, RB, LB, Select, Start Buttons
    public static bool AButton()
    {
        return Input.GetButtonDown("A_Button");
    }

    public static bool BButton()
    {
        return Input.GetButtonDown("B_Button");
    }

    public static bool XButton()
    {
        return Input.GetButtonDown("X_Button");
    }

    public static bool YButton()
    {
        return Input.GetButtonDown("Y_Button");
    }

    public static bool RBButton()
    {
        return Input.GetButtonDown("RBumper_Button");
    }

    public static bool LBButton()
    {
        return Input.GetButtonDown("LBumper_Button");
    }

    public static bool SelectButtion()
    {
        return Input.GetButtonDown("Select_Button");
    }

    public static bool StartButton()
    {
        return Input.GetButtonDown("Start_Button");
    }

}
