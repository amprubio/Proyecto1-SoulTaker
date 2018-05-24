using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputManager  {

    //Keyboard Keys

    public static Dictionary<string, KeyCode> keyMapping;

    public static string[] keyMaps = new string[10]
    {
        "LeftKey",
        "RightKey",
        "JumpKey",
        "AttackKey",
        "HealKey",
        "InteractKey",
        "GranadeKey",
        "ShieldKey",
        "StartKey",
        "SelectKey"
    };

    public static KeyCode[] keys = new KeyCode[10]
    {
        KeyCode.A,
        KeyCode.D,
        KeyCode.K,
        KeyCode.Space,
        KeyCode.Q,
        KeyCode.W,
        KeyCode.E,
        KeyCode.F,
        KeyCode.Escape,
        KeyCode.I,
    };

    static GameInputManager()
    {
        InitializeDictionary();
    }

    private static void InitializeDictionary()
    {
        keyMapping = new Dictionary<string, KeyCode>();
        for(int i = 0; i < keyMaps.Length; i++)
        {
            keyMapping.Add(keyMaps[i], keys[i]);
        }
    }

    public static void SetKey(string keyMap, KeyCode key)
    {
        keyMapping[keyMap] = key;
    }

    public static bool GetKeyDown(string key)
    {
        return Input.GetKeyDown(keyMapping[key]);
    }

    public static bool GetKey(string key)
    {
        return Input.GetKey(keyMapping[key]);
    }

    public static bool GetKeyUp(string key)
    {
        return Input.GetKeyUp(keyMapping[key]);
    }

    //Controller Buttons

    // -- MoveAxis

    public static float MainHorizontal()                         // Mando: Joystick Izquierdo
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainHorizontal");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float MainVertical()                          // Mando: Joystick Izquierdo
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainVertical");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 MainJoystick()
    {
        return new Vector3(MainHorizontal(), 0, MainVertical());
    }


    // -- LookAxis

    public static float LookHorizontal()                       // Mando: Joystick Derecho
    {
        float r = 0.0f;
        r += Input.GetAxis("J_LookHorizontal");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float LookVertical()                         // Mando: Joystick Derecho
    {
        float r = 0.0f;
        r += Input.GetAxis("J_LookVertical");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 LookJoystick()
    {
        return new Vector3(LookHorizontal(), 0, LookVertical());
    }


    // -- Buttons

    public static bool AButtonDown()                            
    {
        return Input.GetButtonDown("A_Button");
    }

    public static bool AButton()
    {
        return Input.GetButton("A_Button");
    }

    public static bool AButtonUp()
    {
        return Input.GetButtonUp("A_Button");
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

    public static bool LBButton()                           
    {
        return Input.GetButtonDown("LB_Button");
    }

    public static bool RBButton()                           
    {
        return Input.GetButtonDown("RB_Button");
    }

    public static float JTriggers()                         // LT [>0] and RT [<0] buttons
    {
        float r = 0.0f;
        r += Input.GetAxis("J_Triggers");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static bool LTButton()                           
    {
        return Input.GetButtonDown("LT_Button");
    }

    public static bool RTButton()                          
    {
        return Input.GetButtonDown("RT_Button");
    }

    public static bool BackButton()                         
    {
        return Input.GetButtonDown("Back_Button");
    }

    public static bool StartButton()                        
    {
        return Input.GetButtonDown("Start_Button");
    }

    
}
