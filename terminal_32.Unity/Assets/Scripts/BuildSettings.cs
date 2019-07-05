using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSettings : MonoBehaviour
{    
	void Awake ()
    {
        Screen.fullScreen = false;
        Screen.SetResolution(512, 480, false);
    }

    void OnApplicationQuit()
    {
        Screen.fullScreen = false;
        Screen.SetResolution(512, 480, false);
    }
}
