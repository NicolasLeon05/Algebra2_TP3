using System;
using UnityEngine;

public class SortingTestRunner : MonoBehaviour
{
    void Awake()
    {
        SortingTester.RunTests();
        RadixTester.TestRadix();

        Console.WriteLine("\nALL TESTS FINISHED");
    }
}
