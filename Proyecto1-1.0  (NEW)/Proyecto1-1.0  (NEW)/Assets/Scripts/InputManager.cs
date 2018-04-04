using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    // -- MoveAxis

    public static float MainHorizontal()                         // (Mando: Joystick Izquierdo ; Teclado: A [<0],D [>0])
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainHorizontal");
        r += Input.GetAxis("K_MainHorizontal");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }     

    public static float MainVertical()                          // (Mando: Joystick Izquierdo ; Teclado: S,W)
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainVertical");
        r += Input.GetAxis("K_MainVertical");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 MainJoystick()
    {
        return new Vector3 (MainHorizontal(), 0, MainVertical());
    }


    // -- LookAxis

    public static float LookHorizontal()                       // (Mando: Joystick Derecho ; Teclado: Flecha izq [<0], Flecha drch [>0])
    {
        float r = 0.0f;
        r += Input.GetAxis("J_LookHorizontal");
        r += Input.GetAxis("K_LookHorizontal");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float LookVertical()                         // (Mando: Joystick Derecho ; Teclado: Flecha abajo [>0], Flecha arriba [<0])
    {
        float r = 0.0f;
        r += Input.GetAxis("J_LookVertical");
        r += Input.GetAxis("K_LookVertical");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 LookJoystick()
    {
        return new Vector3(LookHorizontal(), 0, LookVertical());
    }


    // -- Buttons

    public static bool AButton()                            // (Teclado: K)
    {
        return Input.GetButtonDown("A_Button");
    }

    public static bool BButton()                            // (Teclado: L)
    {
        return Input.GetButtonDown("B_Button");
    }

    public static bool XButton()                            // (Teclado: H)
    {
        return Input.GetButtonDown("X_Button");
    }

    public static bool YButton()                            // (Teclado: I)
    {
        return Input.GetButtonDown("Y_Button");
    }

    public static bool LBButton()                           // (Teclado: U)
    {
        return Input.GetButtonDown("LB_Button");
    }

    public static bool RBButton()                           // (Teclado: O)
    {
        return Input.GetButtonDown("RB_Button");
    }

    public static float JTriggers()                         // LT [>0] and RT [<0] buttons
    {
        float r = 0.0f;
        r += Input.GetAxis("J_Triggers");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static bool LTButton()                           // (Teclado: Y)
    {
        return Input.GetButtonDown("LT_Button");
    }

    public static bool RTButton()                           // (Teclado: P)
    {
        return Input.GetButtonDown("RT_Button");
    }

    public static bool BackButton()                         // (Teclado: E)
    {
        return Input.GetButtonDown("Back_Button");
    }

    public static bool StartButton()                        // (Teclado: Esc)
    {
        return Input.GetButtonDown("Start_Button");
    }
}
