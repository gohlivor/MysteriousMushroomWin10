using UnityEngine;
using System.Collections;

public class ButtonPlay : MonoBehaviour
{
    public GUIStyle customstyle;
    void OnGUI()
    {
        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(Screen.width/2-100,Screen.height/2+25, 200, 100), "Play", customstyle))
        {
            Application.LoadLevel("Mushroomscene");
        }
        

    }
}
