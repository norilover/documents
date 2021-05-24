using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Schema;

namespace ConsoleTest
{
    /***
     * Quick Sort
     */
    public class Sort
    {
        public static void Main(string[] args)
        {
            int[] array = new[] {1, 5, 2, 6, 1};
            
            // BubbleSort bubbleSort = new BubbleSort();
            // bubbleSort.sort(array);
            // print(array);
            
            //
            // InsertSort insertSort = new InsertSort();
            // insertSort.sort(array);
            // print(array);

            // QuickSort quickSort = new QuickSort();
            // quickSort.sort(array);
            // print(array);

            // MergeSort mergeSort = new MergeSort();
            // mergeSort.sort(array);
            //
            // HeapSort heapSort = new HeapSort();
            // heapSort.sort(array);
            //
            // XShellSort xshellSort = new XShellSort();
            // xshellSort.sort(array);
             
        }

        private static void print(int[] array)
        {
            foreach (var VARIABLE in array)
            {
                Console.WriteLine(VARIABLE);
            }
        }
    }
    
    
    public class QuickSort
    {
        public void sort(int[] array)
        {
            if (array == null || array.Length <= 1)
                return;

            nativeSort(array, 0, array.Length - 1);
        }

        private void nativeSort(int[] array, int left, int right)
        {
            if (left >= right)
                return;
            
            int middle = nativePartition(ref array, left, right);
            
            nativeSort(array, left, middle - 1);
            nativeSort(array, middle + 1, right);
        }

        private int nativePartition(ref int[] array, int left, int right)
        {
            // can be optimised
            int pivot = array[left];

            while (left < right)
            {
                while (right > left && array[right] >= pivot)
                    right--;
                array[left] = array[right];

                while (left < right && array[left] <= pivot)
                    left++;
                array[right] = array[left];
            }

            array[left] = pivot;

            return left;
        }
    }

    public class InsertSort
    {
        public void sort(int[] array)
        {
            if (array == null || array.Length <= 1) 
                return;
            
            nativeSort(array);
        }

        private void nativeSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (min > array[j])
                        nativeSwap(ref min, ref array[j]);
                }
            }
        }

        /***
         * EG.
         *  i  = 0001
         *  i1 = 0011
         *  
         *  i  ^= i1:
         *       0010
         *  
         *  i1 ^= i:
         *       0001
         *  
         *  i  ^= i1:
         *       0011
         */
        private void nativeSwap(ref int i, ref int i1)
        {
            i ^= i1;
            i1 ^= i;
            i ^= i1;
        }
        /*
         Above method Like below
         private void nativeCommonSwap(ref int i, ref int i1)
         {
             int temp = i;
             i = i1;
             i1 = temp;
         }
         */
    }

    public class BubbleSort
    {
        public void sort(int[] array)
        {
            if (array == null || array.Length <= 1)
                return;

            nativeSort(array);
        }

        private void nativeSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                bool isSequenceFlag = true;
                
                for (int j = 1; j < array.Length - i; j++)
                {
                    if (array[j - 1] > array[j])
                    {
                        nativeSwap(ref array[j - 1], ref array[j]);
                        
                        if(isSequenceFlag)
                            isSequenceFlag = false;
                    }
                }

                if (isSequenceFlag)
                    return;
            }
        }

        /***
         * EG.
         *  i  = 0001
         *  i1 = 0011
         *  
         *  i  ^= i1:
         *       0010
         *  
         *  i1 ^= i:
         *       0001
         *  
         *  i  ^= i1:
         *       0011
         */
        private void nativeSwap(ref int i, ref int i1)
        {
            i ^= i1;
            i1 ^= i;
            i ^= i1;
        }
        /*
         Above method Like below
         private void nativeCommonSwap(ref int i, ref int i1)
         {
             int temp = i;
             i = i1;
             i1 = temp;
         }
         */
    }
}