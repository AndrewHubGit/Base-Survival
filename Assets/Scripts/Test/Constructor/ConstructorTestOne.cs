using Unity.VisualScripting;
using UnityEngine;

public class ConstructorTestOne
{
    private string _name;
    private int _age;
    public ConstructorTestOne(string name, int age)
    {
        _name = name;
        _age = age;
    }
    public void Info()
    {
        Debug.Log(_name);
        Debug.Log(_age);
    }
    public void NewName(string newName)
    {
        _name = newName;
    }
}
