using UnityEngine;
using System.Collections;

public class myCamera : MonoBehaviour {

    string buildNumber = "0.0.2";

    int lineHeight = 25;

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, lineHeight * 2), "WSAD to move.\nSpace to shoot.\nKill'em all ! :D");

        GUI.Label(new Rect(5, Screen.height - lineHeight, 150, lineHeight), "Build " + buildNumber);
    }
}
