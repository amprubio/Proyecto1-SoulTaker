using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    public Text[] keyControls;

    private GameObject currentKey;
    private string selected = "PressKey";

    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i<keyControls.Length; i++)
        {
            keyControls[i].text = GameInputManager.keyMapping[GameInputManager.keyMaps[i]].ToString();
        }
    }

    private void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                GameInputManager.SetKey(currentKey.name, e.keyCode);
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {        currentKey = clicked;
        currentKey.transform.GetChild(0).GetComponent<Text>().text = selected;
    }


}
