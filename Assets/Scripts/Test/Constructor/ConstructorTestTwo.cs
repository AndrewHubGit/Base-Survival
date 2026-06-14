using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructorTestTwo : MonoBehaviour
{
    private ConstructorTestOne _constructorTestTwo;
    private ConstructorTestOne _constructorTestOne;
    private void Start()
    {
        _constructorTestOne = new ConstructorTestOne("Max", 22);
        _constructorTestTwo = new ConstructorTestOne("Andrew", 18);
        _constructorTestOne.Info();
        _constructorTestTwo.NewName("Tom");
        _constructorTestTwo.Info();
    }
}
