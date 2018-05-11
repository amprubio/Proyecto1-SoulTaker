using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputManager  {

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
}
