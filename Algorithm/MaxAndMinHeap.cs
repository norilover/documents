using System;
using System.Data.SqlTypes;
using System.Xml.Schema;

namespace DefaultNamespace
{
    public class MaxAndMinHeap
    {
        public static void Main1(string[] args)
        {
            IHeap1 iHeap1 = new Heap(200);

            int i = 0;
            while (++i < 50)
                iHeap1.push(i);

            iHeap1.push(10000);
            
            i = 450;
            while (++i < 500)
                iHeap1.push(i);

            while (iHeap1.size() > 0)
            {
                Console.WriteLine(iHeap1.pop());
            }
        }
        
    }

    public interface IHeap
    {
        int getParentIndex(int i);
        int getLeftChildIndex(int i);
        int getRightChildIndex(int i);
        int extract();
        void decreaseKey(int i, int newValue);
        int get();
        void deleteKey(int i);
        void insertKey(int key);
    }

    public class MinHeap : IHeap
    {
        private int capacity;
        private int heapSize;
        private int[] array;

        public MinHeap(int capacity)
        {
            this.capacity = capacity;
            this.heapSize = 0;
            this.array = new int[this.capacity];
        }

        public int getParentIndex(int i)
        {
            // return ((i + 1) >> 1) - 1;
            return ((i - 1) / 2);
        }

        public int getLeftChildIndex(int i)
        {
            return (i * 2) + 1;
        }

        public int getRightChildIndex(int i)
        {
            return (i * 2) + 2;
        }

        public int extract()
        {
            return extractMin();
        }

        public void decreaseKey(int i, int newValue)
        {
            array[i] = newValue;

            while (i != 0 && array[getParentIndex(i)] > array[i])
            {
                swap(ref array[i], ref array[getParentIndex(i)]);
                i = getParentIndex(i);
            }
        }

        private int extractMin()
        {
            if(heapSize <= 0)
                return Int32.MaxValue;

            if (heapSize == 1)
            {
                heapSize--;
                return array[0];
            }

            int root = array[0];
            array[0] = array[heapSize - 1];

            heapSize--;
            heapify(0);

            return root;
        }

        public int get()
        {
            return heapSize > 0 ? array[0] : -1;
        }

        public void deleteKey(int key)
        {
            if (heapSize <= 0)
                return;

            int keyIndex = getKeyIndex(key);
        }

        private int getKeyIndex(int key)
        {
            // return findKeyIndex1(key);
            // return findKeyIndex2(key);
            
            decreaseKey(key,int.MaxValue);

            return extract();
        }
        
        /*
        private int findKeyIndex2(int key)
        {
            // Use the min heap 
            return binarySearchKey(key, 0);
        }

        private int binarySearchKey(int key, int i)
        {
            // if (i >= heapSize)
            if (i >= heapSize || i < 0)
                return -1;

            if (key == array[i])
                return i;

            if (array[i] > key)
                return -1;
            
            int leftFindIndex = binarySearchKey(key, getLeftChildIndex(i));

            return leftFindIndex == -1 ? binarySearchKey(key, getRightChildIndex(i)) : leftFindIndex;
        }

        private int findKeyIndex1(int key)
        {
            for (int i = 0; i < heapSize; i++)
                if (array[i] == key)
                    return i;

            return -1;
        }*/

        public void insertKey(int key)
        {
            // Check whether can available
            if (this.capacity <= heapSize)
                return;

            array[heapSize] = key;
            heapSize++;

            this.heapify(getParentIndex(heapSize - 1));
        }

        public void heapify(int parentIndex)
        {
            int smallValueIndex = parentIndex;
            int leftChildIndex  = getLeftChildIndex(parentIndex);
            int rightChildIndex = getRightChildIndex(parentIndex);
            
            if (smallValueIndex < heapSize && array[smallValueIndex] > array[leftChildIndex])
                smallValueIndex = leftChildIndex;

            if (smallValueIndex < heapSize && array[smallValueIndex] > array[rightChildIndex])
                smallValueIndex = rightChildIndex;

            // No suit the rule of min heap
            if (smallValueIndex != parentIndex)
            {
                this.swap(ref array[smallValueIndex], ref array[parentIndex]);
                
                decreaseKey( heapSize, getParentIndex(parentIndex));
            }
        }

        private void swap(ref int i, ref int i1)
        {
            i  ^= i1;
            i1 ^= i;
            i  ^= i1;
        }
    }
    
    
    public class MaxHeap : IHeap
    {
        public int getParentIndex(int i)
        {
            throw new System.NotImplementedException();
        }

        public int getLeftChildIndex(int i)
        {
            throw new System.NotImplementedException();
        }

        public int getRightChildIndex(int i)
        {
            throw new System.NotImplementedException();
        }

        public int extract()
        {
            throw new System.NotImplementedException();
        }

        public void decreaseKey(int i, int newValue)
        {
            throw new System.NotImplementedException();
        }

        public int get()
        {
            throw new System.NotImplementedException();
        }

        public void deleteKey(int i)
        {
            throw new System.NotImplementedException();
        }

        public void insertKey(int key)
        {
            throw new System.NotImplementedException();
        }
    }


    interface IHeap1
    {
        void sink(int index);
        void swim(int index);

        void push(int value);
        int pop();
        
        int size();
    }

    public class Heap : IHeap1
    {
        private int[] array = null;
        private int n = 0;
        private int capacity = 0;
        
        public Heap(int capacity)
        {
            this.capacity = capacity;
            this.array = new int[this.capacity];
        }

        public void sink(int index)
        {
            int saveIndex =  0;
            int parentIndex = index;
            int sinkValue = array[index];
            

            while ((saveIndex = parentIndex << 1 + 1) < n)
            {
                if (saveIndex + 1 < n && array[saveIndex] < array[saveIndex + 1])
                    saveIndex += 1;

                if (sinkValue < array[saveIndex])
                {
                    array[parentIndex] = array[saveIndex];
                    parentIndex = saveIndex;
                }
                else
                {
                    break;
                }
            }

            if (parentIndex != index)
                array[parentIndex] = sinkValue;
        }

        public void swim(int index)
        {
            int saveIndex = 0;
            int childIndex = index;
            int swimValue = array[index];

            while ((saveIndex = (childIndex - 1) >> 1) >= 0)
            {
                if (swimValue > array[saveIndex])
                {
                    array[childIndex] = array[saveIndex];
                    childIndex = saveIndex;
                }
                else
                {
                    break;
                }
            }

            if (childIndex != index)
                array[childIndex] = swimValue;
        }

        public void push(int value)
        {
            if (n >= capacity)
                return;

            array[n++] = value;
            swim(n - 1);

            return;
        }

        public int pop()
        {
            if (n <= 0)
                return -1;

            int removeValue = array[0];
            array[0] = array[--n];
            sink(0);
            
            return removeValue;
        }

        public int size()
        {
            return n;
        }

        public override string ToString()
        {
            string result = null;
            foreach (var i in this.array)
            {
                result += i + ",";
            }

            return result;
        }
    }
}