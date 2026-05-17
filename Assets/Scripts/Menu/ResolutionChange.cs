using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionChange : MonoBehaviour
{
    private Resolution[] _resolution;
    private TMP_Dropdown _dropdown;
    private void Start()
    {
        _dropdown = GetComponent<TMP_Dropdown>();
        _dropdown.ClearOptions();
        List<string> list = new List<string>();
        _resolution = Screen.resolutions;
        for (int i = 0; i < _resolution.Length; i++)
        {
            list.Add(_resolution[i].width.ToString() + " x " + _resolution[i].height.ToString());
        }
        _dropdown.AddOptions(list);
        int index = PlayerPrefs.GetInt("Resolution");
        _dropdown.value = index;
        Screen.SetResolution(_resolution[index].width, _resolution[index].height, Screen.fullScreen);
    }
    public void ChangeResolution(int index)
    {
        PlayerPrefs.SetInt("Resolution", index);
        Screen.SetResolution(_resolution[index].width, _resolution[index].height, Screen.fullScreen);
    }
}
