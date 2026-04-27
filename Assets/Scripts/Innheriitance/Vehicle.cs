using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
    public virtual void Drive()
    {
        Debug.Log("tires turning");
    }
    public abstract void EnterCar();
    private void Update()
    {
        Drive();
    }
    private void Start()
    {
        EnterCar();
    }
}
