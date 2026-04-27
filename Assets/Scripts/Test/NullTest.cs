using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullTest : MonoBehaviour
{
    private string _playerName;
    private string _selectedPlayerName;
    private string _defaultPlayerName = "default";
    [SerializedDictionary("Resources" , "amount")]
    public SerializedDictionary<Environment, int> ResourceAmount;
    [SerializeField] private Environment _environment;
    private void Start()
    {
        _playerName ??= "default";
        Debug.Log(_playerName?.ToString()?.ToLower());
        _playerName = _selectedPlayerName?? _defaultPlayerName;
        if (_playerName != null)
        {
            Debug.Log(_playerName);
        }
        else
        {
            Debug.Log("error");
        }
        Debug.Log(_playerName??"error");
        for (int i = 0; i < _playerName?.Length; i++)
        {
            Debug.Log(_playerName);
        }
    }
}
