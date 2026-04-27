using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : Vehicle
{
    public override void Drive()
    {
        base.Drive();
        Debug.Log("truck driving");
    }
    public override void EnterCar()
    {
        Debug.Log("EnteredTruck");
    }
}
