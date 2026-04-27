using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueReferenceTypes : MonoBehaviour
{
    private int number;
    [SerializeField] private int[] numbersA;
    [SerializeField] private int[] numbersB;
    private void Start()
    {
        //number = Increase(number);
        //Debug.Log(number);
        numbersB = numbersA;
        IncreaseNumbers(numbersA);
    }
    public void IncreaseNumbers(int[] numbers)
    {
        numbers[0]++;
    }
    public int Increase(int n)
    {
        n++;
        return n;
    }
}
