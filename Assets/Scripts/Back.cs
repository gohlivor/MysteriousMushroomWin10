using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour
{
    public GUIStyle customstyle;
    void OnGUI()
    {
        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 100, 100, 50), "Back", customstyle))
        {
            Application.LoadLevel("Gameover");
        }


    }
}

