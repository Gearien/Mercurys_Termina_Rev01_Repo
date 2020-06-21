using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameInputManager 
{

    static Dictionary<string, KeyCode> keyMapping;
    public static string[] keyMaps = new string[6]
    {
        "MoveForward",
        "MoveBackward",
        "MoveRight",
        "MoveLeft",
        "MoveUp",
        "MoveDown"
    };

    public static KeyCode[] defaults = new KeyCode[6]
    {
        KeyCode.Z,
        KeyCode.S,
        KeyCode.D,
        KeyCode.Q,
        KeyCode.R,
        KeyCode.F
    };
    
    static GameInputManager()
    {
        InitializeDictionnary();
    }

    private static void InitializeDictionnary()
    {
        keyMapping = new Dictionary<string, KeyCode>();
        for (int i = 0; i < keyMaps.Length; ++i)
        {
            keyMapping.Add(keyMaps[i], defaults[i]);
        }
    }

    public static void SetKeyMap(string keyMap,KeyCode key)
    {
        if(!keyMapping.ContainsKey(keyMap))
        {
            throw new ArgumentException("Invalid KeyMap in SetKeyMap: " + keyMap);
        }
        keyMapping[keyMap] = key;
    }

    public static bool GetKeyDown(string keyMap)
    {
        return Input.GetKeyDown(keyMapping[keyMap]);
    }

    public static bool GetKey(string keyMap)
    {
        return Input.GetKey(keyMapping[keyMap]);
    }
}
