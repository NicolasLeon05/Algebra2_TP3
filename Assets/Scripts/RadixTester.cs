using System.Collections.Generic;
using UnityEngine;

public static class RadixTester
{
    public static void TestRadix()
    {
        Debug.Log("\n--- TESTING RADIX SORT (solo int) ---");

        var nums = new List<int> { 170, 45, 75, 90, 2, 802, 2 };

        // LSD
        var lsd = new List<int>(nums);
        Debug.Log("\nRadixSortLSD:");
        Debug.Log("Before: " + string.Join(", ", lsd));
        SortingAlgorithms.RadixSortLSD(lsd);
        Debug.Log("After : " + string.Join(", ", lsd));

        // MSD
        var msd = new List<int>(nums);
        Debug.Log("\nRadixSortMSD:");
        Debug.Log("Before: " + string.Join(", ", msd));
        SortingAlgorithms.RadixSortMSD(msd);
        Debug.Log("After : " + string.Join(", ", msd));
    }
}
