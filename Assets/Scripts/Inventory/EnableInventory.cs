using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnableInventory : MonoBehaviour
{
    [SerializeField] private Player _player;
    public void InventorySwitch()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        _player.ChangeDirection(Vector3.zero);
        Cursor.visible = gameObject.activeSelf;
        if (Cursor.visible)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameObject.SetActive(false);
    }
}
