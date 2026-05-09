using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;

public class WindowedFullscreen : MonoBehaviour
{
    private Toggle _windowedToggle;
    private void Start()
    {
        _windowedToggle = GetComponent<Toggle>();
        int windowedcheck = PlayerPrefs.GetInt("windowedFullscreen");
        bool windowed;
        if (windowedcheck == 1)
        {
            windowed = true;
        }
        else
        {
            windowed = false;
        }
        _windowedToggle.isOn = windowed;
        Screen.fullScreen = windowed;
    }
    public void WindowedSettings(bool windowed)
    {
        int windowedcheck;
        Screen.fullScreen = windowed;
        if(windowed == true)
        {
            windowedcheck = 1;
        }
        else
        {
            windowedcheck = 0;
        }
        PlayerPrefs.SetInt("windowedFullscreen", windowedcheck);
    }
}
