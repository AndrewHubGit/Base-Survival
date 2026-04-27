using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Input : MonoBehaviour
{
    private Player _player;
    private PlayerInput _playerInput;
    [SerializeField] private HotBar _hotbar;
    [SerializeField] private float _sensitivity;
    [SerializeField] private EnableInventory _playerInventory;
    private void Start()
    {
        _player = GetComponent<Player>();
        _playerInput = GetComponent<PlayerInput>();
    }
    public void OnUseItem(InputAction.CallbackContext context)
    {
        if (Cursor.visible)
        {
            return;
        }
        if (context.performed)
        {
            _hotbar.UseItem();
        }
    }
    public void OnWalk(InputAction.CallbackContext context)
    {
        if (Cursor.visible)
        {
            return;
        }
        Vector2 _playerInput = context.ReadValue<Vector2>();
        Vector3 _direction = _player.transform.right * _playerInput.x + _player.transform.forward * _playerInput.y;
        _player.ChangeDirection(_direction);
    }
    public void OnCameraRotation(InputAction.CallbackContext context)
    {
        if (Cursor.visible)
        {
            return;
        }
        var cameraRotation = _playerInput.camera.transform.rotation.eulerAngles;
        Vector2 rotationDirection = context.ReadValue<Vector2>();
        var rotation = Quaternion.Euler(0, _player.transform.rotation.eulerAngles.y + rotationDirection.x * _sensitivity, 0);
        _playerInput.camera.transform.rotation = Quaternion.Euler(cameraRotation.x - rotationDirection.y * _sensitivity, cameraRotation.y , cameraRotation.z);
        _player.SetRotation(rotation);
    }
    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _playerInventory.InventorySwitch();
        }
    }
    public void OnSlotOne(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            _hotbar.SelectSlot(0);
        }
    }
    public void OnSlotTwo(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _hotbar.SelectSlot(1);
        }
    }
    public void OnSlotThree(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _hotbar.SelectSlot(2);
        }
    }
    public void OnSlotFour(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _hotbar.SelectSlot(3);
        }
    }
    public void OnSlotFive(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _hotbar.SelectSlot(4);
        }
    }
    public void OnSlotSix(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _hotbar.SelectSlot(5);
        }
    }
    public void OnSlotSeven(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _hotbar.SelectSlot(6);
        }
    }
}
