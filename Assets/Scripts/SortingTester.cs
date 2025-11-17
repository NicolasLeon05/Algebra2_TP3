using System;
using System.Collections.Generic;
using UnityEngine;

public static class SortingTester
{
    public static void RunTests()
    {
        Debug.Log("===== TESTING ALGORITHMS =====");

        TestType("INT", new List<int> { 5, 3, 9, 1, 4, 7, 2, 6 });

        TestType("STRING", new List<string> { "Juan", "Ana", "Pedro", "Luis" });

        TestType("PLAYER", new List<Player>
        {
            new Player("Carlos"),
            new Player("Ana"),
            new Player("Daniel"),
            new Player("Beatriz")
        });

        Debug.Log("===== TESTING COMPLETE =====");
    }

    private static void TestType<T>(string title, List<T> original) where T : IComparable<T>
    {
        Debug.Log($"\n--- TESTING TYPE: {title} ---");

        void Run(string name, System.Action<List<T>> sort)
        {
            var list = new List<T>(original);

            Debug.Log($"\n{name}:\nBefore: {Stringify(list)}");

            sort(list);

            Debug.Log($"After : {Stringify(list)}");
        }

        Run("BubbleSort", SortingAlgorithms.BubbleSort);
        Run("SelectionSort", SortingAlgorithms.SelectionSort);
        Run("InsertionSort", SortingAlgorithms.InsertionSort);
        Run("GnomeSort", SortingAlgorithms.GnomeSort);
        Run("CocktailShakerSort", SortingAlgorithms.CocktailShakerSort);
        Run("ShellSort", SortingAlgorithms.ShellSort);
        Run("MergeSort", SortingAlgorithms.MergeSort);
        Run("QuickSort", SortingAlgorithms.QuickSort);
        Run("HeapSort", SortingAlgorithms.HeapSort);
        Run("AdaptiveMergeSort", SortingAlgorithms.AdaptiveMergeSort);
        Run("IntroSort", SortingAlgorithms.IntroSort);
        Run("BitonicSort", SortingAlgorithms.BitonicSort);

        if (original.Count <= 5)
            Run("BogoSort", SortingAlgorithms.BogoSort);
        else
            Debug.Log("\nBogoSort: SKIPPED (list was too big)");
    }

    private static string Stringify<T>(List<T> list)
    {
        return string.Join(", ", list);
    }
}
