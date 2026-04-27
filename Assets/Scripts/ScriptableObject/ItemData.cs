using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemData", menuName = "Items")]

public class ItemData : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private GameObject _activeItem;
    public Sprite Sprite => _sprite;
    public GameObject ActiveItem => _activeItem;
}
