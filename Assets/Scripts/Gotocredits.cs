using UnityEngine;
using System.Collections;

public class Gotocredits : MonoBehaviour
{
    public GUIStyle customstyle;
    void OnGUI()
    {
        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(Screen.width / 2 -50, Screen.height / 2+80, 100, 50), "Credits", customstyle))
        {
            Application.LoadLevel("Credits");
        }


    }
}
