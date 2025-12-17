using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Rendering;

public static class SortingAlgorithms
{
    // BOGO SORT
    // Time Complexity: O(n!)
    // Space Complexity: O(1)
    public static void BogoSort<T>(List<T> list) where T : IComparable<T>
    { //Ordena de forma aleatoria la lista hasta que en algun momento este bien ordenada
        Random rand = new Random();
        while (!IsSorted(list))
        {
            for (int i = 0; i < list.Count; i++)
            {
                int j = rand.Next(list.Count);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }

        bool IsSorted(List<T> l)
        {
            for (int i = 1; i < l.Count; i++)
                if (l[i - 1].CompareTo(l[i]) > 0)
                    return false;
            return true;
        }
    }

    // BUBBLE SORT
    // Time Complexity: O(n^2)
    // Space Complexity: O(1)
    public static void BubbleSort<T>(List<T> list) where T : IComparable<T>
    { //Mueve los elementos mas grandes (en este caso) al final de la lista
        int n = list.Count;
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 1; i < n; i++)
            {
                if (list[i - 1].CompareTo(list[i]) > 0)
                {
                    (list[i - 1], list[i]) = (list[i], list[i - 1]);
                    swapped = true;
                }
            }
            n--;
        } while (swapped);
    }

    // GNOME SORT
    // Time Complexity: O(n^2)
    // Space Complexity: O(1)
    public static void GnomeSort<T>(List<T> list) where T : IComparable<T>
    { //Arranca como bubble y cuando encuentra un elemento a cambiar implementa insertion
        int i = 1;
        while (i < list.Count)
        {
            if (i == 0 || list[i - 1].CompareTo(list[i]) <= 0)
                i++;
            else
            {
                (list[i], list[i - 1]) = (list[i - 1], list[i]);
                i--;
            }
        }
    }

    // SELECTION SORT
    // Time Complexity: O(n^2)
    // Space Complexity: O(1)
    public static void SelectionSort<T>(List<T> list) where T : IComparable<T>
    {
        //Cambia el elemento mas chico a la primera posicion
        for (int i = 0; i < list.Count - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < list.Count; j++)
                if (list[j].CompareTo(list[minIndex]) < 0)
                    minIndex = j;
            (list[i], list[minIndex]) = (list[minIndex], list[i]);
        }
    }

    // INSERTION SORT
    // Time Complexity: O(n^2)
    // Space Complexity: O(1)
    public static void InsertionSort<T>(List<T> list) where T : IComparable<T>
    {
        //Arranca por indice 1 y va ordendando los valores hacia atras
        for (int i = 1; i < list.Count; i++)
        {
            T key = list[i];
            int j = i - 1;
            while (j >= 0 && list[j].CompareTo(key) > 0)
            {
                list[j + 1] = list[j];
                j--;
            }
            list[j + 1] = key;
        }
    }

    // COCKTAIL SHAKER SORT
    // Time Complexity: O(n^2)
    // Space Complexity: O(1)
    public static void CocktailShakerSort<T>(List<T> list) where T : IComparable<T>
    {
        //Como bubble sort, pero una vez que movio un elemento hacia atras del todo, hace el proceso inverso hacia el principio
        bool swapped = true;
        int start = 0;
        int end = list.Count - 1;

        while (swapped)
        {
            swapped = false;
            for (int i = start; i < end; i++)
            {
                if (list[i].CompareTo(list[i + 1]) > 0)
                {
                    (list[i], list[i + 1]) = (list[i + 1], list[i]);
                    swapped = true;
                }
            }

            if (!swapped) break;

            swapped = false;
            end--;

            for (int i = end - 1; i >= start; i--)
            {
                if (list[i].CompareTo(list[i + 1]) > 0)
                {
                    (list[i], list[i + 1]) = (list[i + 1], list[i]);
                    swapped = true;
                }
            }

            start++;
        }
    }

    // SHELL SORT
    // Time Complexity: O(n^2)
    // Space Complexity: O(1)
    public static void ShellSort<T>(List<T> list) where T : IComparable<T>
    {
        //Mejora de insertion. Ordena elementos separados por un "gap" que se va reduciendo hasta que se hace un insertion final
        int n = list.Count;
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i++)
            {
                T temp = list[i];
                int j;
                for (j = i; j >= gap && list[j - gap].CompareTo(temp) > 0; j -= gap)
                    list[j] = list[j - gap];
                list[j] = temp;
            }
        }


        int m = 15;
        int aux = m;

        for (int j = 0; j < m; j = aux / 2)
        {
            // log_2 8 = 3
            // log_2 n 
        }
    }

    // QUICK SORT
    // Time Complexity: O(n log n) promedio, O(n^2) peor caso
    // Space Complexity: O(log n) promedio, O(n^2) peor caso
    public static void QuickSort<T>(List<T> list) where T : IComparable<T>
    {
        //Paint
        void Sort(int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(low, high);
                Sort(low, pivotIndex - 1);
                Sort(pivotIndex + 1, high);
            }
        }

        int Partition(int low, int high)
        {
            T pivot = list[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (list[j].CompareTo(pivot) < 0)
                {
                    i++;
                    (list[i], list[j]) = (list[j], list[i]);
                }
            }
            (list[i + 1], list[high]) = (list[high], list[i + 1]);
            return i + 1;
        }

        Sort(0, list.Count - 1);
    }

    // HEAP SORT
    // Time Complexity: O(n log n)
    // Space Complexity: O(1)
    public static void HeapSort<T>(List<T> list) where T : IComparable<T>
    {
        //Nodo padre siempre mayor a los hijos.
        //Organiza el heap en un max heap. 
        //Mueve el elemento padre al final de la lista y lo "descarta" del heap. Repite el proceso
        int n = list.Count;

        void Heapify(int i, int size)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            //Chequea que ningun hijo sea mayor
            if (left < size && list[left].CompareTo(list[largest]) > 0)
                largest = left;
            if (right < size && list[right].CompareTo(list[largest]) > 0)
                largest = right;

            if (largest != i) //Si el mayor no es el actual, el arbol no esta ordenado
            {
                (list[i], list[largest]) = (list[largest], list[i]); //Cambia el mayor por el actual
                Heapify(largest, size); //Vuelve a revisar si el arbol esta ordenado
            }
        }

        for (int i = n / 2 - 1; i >= 0; i--) //Reorganiza desde el ultimo nodo con hijos hasta el primero. Construye el max heap
            Heapify(i, n);

        for (int i = n - 1; i > 0; i--) //Intercambia la raíz del heap con el último elemento no ordenado.
        {
            (list[0], list[i]) = (list[i], list[0]);
            Heapify(0, i);
        }
    }

    // MERGE SORT
    // Time Complexity: O(n log n)
    // Space Complexity: O(n)
    public static void MergeSort<T>(List<T> list) where T : IComparable<T>
    {
        //Divide la lista en mitades hasta que quedan listas con 1 elemento. Las empieza a juntar ordenandolas de mayor a menor
        //hasta volver a tener la lista final ordenada

        if (list.Count <= 1) return; //Si la lista es de un solo elemento, sale

        int mid = list.Count / 2;
        var left = list.GetRange(0, mid);
        var right = list.GetRange(mid, list.Count - mid);

        //Divide las mitades de la lista en mitades
        MergeSort(left);
        MergeSort(right);

        list.Clear();
        int i = 0, j = 0;

        //Fusiona left y right
        while (i < left.Count && j < right.Count)
        {
            //Compara los elementos de left y right y agrega el menor a la lista.
            //Se mueve al siguiente elemento de la lista que tenia el menor numero
            if (left[i].CompareTo(right[j]) <= 0)
                list.Add(left[i++]);
            else
                list.Add(right[j++]);
        }

        //Si quedaron elementos en alguna de las sublistas los agrega
        list.AddRange(left.GetRange(i, left.Count - i));
        list.AddRange(right.GetRange(j, right.Count - j));
    }

    // ADAPTIVE MERGE SORT
    // Time Complexity: O(n log n)
    // Space Complexity: O(n)
    public static void AdaptiveMergeSort<T>(List<T> list) where T : IComparable<T>
    {
        //Busca sublistas ya ordenadas (runs) para realizar menos trabajo de fusion

        if (list.Count <= 1) return;

        var runs = new List<(int start, int length)>();

        int i = 0;
        while (i < list.Count)
        {
            int start = i; //Inicio de la run
            i++;


            //Si la lista esta desordenada (el valor anterior es mayor que el actual)
            //busca una run en orden descendente y la revierte
            if (i < list.Count && list[i - 1].CompareTo(list[i]) > 0)
            {
                while (i < list.Count && list[i - 1].CompareTo(list[i]) > 0)
                    i++;
                list.Reverse(start, i - start);
            }
            else
            {
                //Si la lista ya esta ordenada ascendentemente, avanza hasta el final de la run
                while (i < list.Count && list[i - 1].CompareTo(list[i]) <= 0)
                    i++;
            }

            //Almacena la run como un par (inicio, longitud)
            runs.Add((start, i - start));
        }

        while (runs.Count > 1)
        {
            var newRuns = new List<(int start, int length)>();

            for (int r = 0; r < runs.Count; r += 2)
            {
                //Si las runs son impares, agrega la ultimo run sin fusionar
                if (r + 1 >= runs.Count)
                {
                    newRuns.Add(runs[r]);
                    continue;
                }

                var (s1, len1) = runs[r];
                var (s2, len2) = runs[r + 1];

                //Fusiona las dos runs
                Merge(list, s1, len1, s2, len2);

                newRuns.Add((s1, len1 + len2));
            }

            runs = newRuns;
        }
    }

    //Igual que mergeSort, pero recibe parametros para crear las particiones que se quieren
    static void Merge<T>(List<T> list, int start1, int len1, int start2, int len2) where T : IComparable<T>
    {


        var left = list.GetRange(start1, len1);
        var right = list.GetRange(start2, len2);

        int i = 0, j = 0, k = start1;

        while (i < left.Count && j < right.Count)
        {
            if (left[i].CompareTo(right[j]) <= 0)
                list[k++] = left[i++];
            else
                list[k++] = right[j++];
        }

        while (i < left.Count)
            list[k++] = left[i++];

        while (j < right.Count)
            list[k++] = right[j++];
    }

    // INTRO SORT
    // Time Complexity: O(n log n)
    // Space Complexity: O(log n)
    public static void IntroSort<T>(List<T> list) where T : IComparable<T>
    {
        //Utiliza Insertion Sort, Quick Sort y Heap Sort para maximizar eficiencia

        int n = list.Count;
        int depthLimit = (int)(2 * Math.Log(n, 2)); //Profundidad maxima para la recursividad(O(log n))

        void Sort(int start, int end, int depth)
        {
            int size = end - start + 1;

            if (size <= 16) //Si la lista es pequeña, utiliza Insertion
            {
                InsertionSortRange(list, start, end);
                return;
            }

            if (depth == 0) //Si alcanza el limite de recursividad, cambia a Heap Sort para evitar el peor caso de QuickSort
            {
                HeapSortRange(list, start, end);
                return;
            }

            //Realiza Quick Sort
            int p = Partition(start, end);
            Sort(start, p - 1, depth - 1);
            Sort(p + 1, end, depth - 1);
        }

        int Partition(int low, int high)
        {
            T pivot = list[(low + high) / 2];
            int i = low;
            int j = high;

            while (i <= j)
            {
                while (list[i].CompareTo(pivot) < 0) i++;
                while (list[j].CompareTo(pivot) > 0) j--;

                if (i <= j)
                {
                    (list[i], list[j]) = (list[j], list[i]);
                    i++;
                    j--;
                }
            }

            return i - 1;
        }

        Sort(0, n - 1, depthLimit);
    }

    // Helper: Insertion sort for a range
    static void InsertionSortRange<T>(List<T> list, int start, int end) where T : IComparable<T>
    {
        for (int i = start + 1; i <= end; i++)
        {
            T key = list[i];
            int j = i - 1;
            while (j >= start && list[j].CompareTo(key) > 0)
            {
                list[j + 1] = list[j];
                j--;
            }
            list[j + 1] = key;
        }
    }

    // Helper: Heap sort for a range
    static void HeapSortRange<T>(List<T> list, int start, int end) where T : IComparable<T>
    {
        int size = end - start + 1;

        void Heapify(int root, int length)
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            if (left < length && list[start + left].CompareTo(list[start + largest]) > 0)
                largest = left;
            if (right < length && list[start + right].CompareTo(list[start + largest]) > 0)
                largest = right;

            if (largest != root)
            {
                (list[start + root], list[start + largest]) = (list[start + largest], list[start + root]);
                Heapify(largest, length);
            }
        }

        for (int i = size / 2 - 1; i >= 0; i--)
            Heapify(i, size);

        for (int i = size - 1; i > 0; i--)
        {
            (list[start], list[start + i]) = (list[start + i], list[start]);
            Heapify(0, i);
        }
    }


    // BITONIC SORT
    // Time Complexity: O(n log^2 n)
    // Space Complexity: O(log n)
    public static void BitonicSort<T>(List<T> list) where T : IComparable<T>
    {
        //Funciona solo con potencias de 2

        void BitonicMerge(int low, int cnt, bool ascending)
        {
            if (cnt > 1)
            {
                int k = cnt / 2;
                for (int i = low; i < low + k; i++)
                    if ((list[i].CompareTo(list[i + k]) > 0) == ascending)
                        (list[i], list[i + k]) = (list[i + k], list[i]);
                BitonicMerge(low, k, ascending);
                BitonicMerge(low + k, k, ascending);
            }
        }

        void BitonicSortRec(int low, int cnt, bool ascending)
        {
            if (cnt > 1)
            {
                int k = cnt / 2;
                BitonicSortRec(low, k, true); //Ordena la primera mitad de forma ascendente
                BitonicSortRec(low + k, k, false); //Ordena la segunda mitad de forma descendente
                BitonicMerge(low, cnt, ascending); //Mergea la secuencia completa
            }
        }

        BitonicSortRec(0, list.Count, true);
    }

    // RADIX SORT (LSD)
    // Time Complexity: O(n * k) (k = maximo de digitos)
    // Space Complexity: O(n + k)
    public static void RadixSortLSD(List<int> list)
    {
        //Ordena los numeros comenzando por el digito menos significativo (unidad)

        int max = list.Max(); //Encuentra el numero maximo en la lista, para determinar el número de dígitos
        for (int exp = 1; max / exp > 0; exp *= 10) //Itera sobre cada dígito (unidades, decenas, centenas, etc)
            CountingSort(list, exp);

        void CountingSort(List<int> arr, int exp)
        {
            //Paint
            int n = arr.Count;
            int[] output = new int[n];
            int[] count = new int[10];

            for (int i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                int index = (arr[i] / exp) % 10;
                output[count[index] - 1] = arr[i];
                count[index]--;
            }

            for (int i = 0; i < n; i++)
                arr[i] = output[i];
        }
    }

    // RADIX SORT (MSD)
    // Time Complexity: O(n * k)
    // Space Complexity: O(n + k)
    public static void RadixSortMSD(List<int> list)
    {
        //Ordena los numeros comenzando por el digito mas significativo

        if (list == null || list.Count <= 1) return;

        int max = list.Max(x => Math.Abs(x)); //Valor absoluto maximo en la lista
        int exp = 1;
        while (max / exp >= 10) exp *= 10; //Lugar del dígito más significativo

        MSD(list, 0, list.Count, exp);
    }

    static void MSD(List<int> arr, int start, int end, int exp)
    {
        if (exp == 0 || end - start <= 1) return;

        List<int>[] buckets = new List<int>[19]; //Array de listas para cada numero de -9 a 9
        for (int i = 0; i < buckets.Length; i++) buckets[i] = new List<int>();

        for (int i = start; i < end; i++)
        {
            int digit = (arr[i] / exp) % 10;
            buckets[digit + 9].Add(arr[i]); //Mueve los numeros a los buckets correspondientes
        }

        //Vuelve a llenar el arreglo original con los numeros de los buckets en el orden correspondiente
        int index = start;
        for (int b = 0; b < buckets.Length; b++)
        {
            var bucket = buckets[b];
            if (bucket.Count == 0) continue;

            for (int k = 0; k < bucket.Count; k++)
                arr[index++] = bucket[k];

            //Llama recursivamente para ordenar los elementos en el siguiente nivel de digitos
            MSD(arr, index - bucket.Count, index, exp / 10);
        }
    }

}
