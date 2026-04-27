using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motorcycle : Vehicle
{
    public override void Drive()
    {
        base.Drive();
        Debug.Log("motorcycle driving");
    }
    public override void EnterCar()
    {
        Debug.Log("EnteredMotorcycle");
    }
}
