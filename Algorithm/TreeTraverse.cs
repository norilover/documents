using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    /***
     * Tree Traverse
     * Recursion, Iterator, NLR, LNR, LRN
     * Layer Traverse using Queue, Two List
     */
    public class TreeTraverse
    {
        public static void Main2(string[] args)
        {
            /*            1
             *        |      |
             *        2      3
             *      |   |  |   |
             *      4   5  6   7
             */

            TN head = new TN(1);
            
            TN leftTN = new TN(2);
            head.leftNode = leftTN;
            TN rightTN = new TN(3);
            head.rightNode = rightTN;

            leftTN.leftNode = new TN(4);
            leftTN.rightNode = new TN(5);
            
            rightTN.leftNode = new TN(6);
            rightTN.rightNode = new TN(7);
            
            
            // Recursive Traverse
            // NLR_R(head);
            // LNR_R(head);
            // LRN_R(head);
            
            // Iterator Traverse
            // NLR_I(head);
            // LNR_I(head);
            // LRN_I(head);

            // layerTraverse_useQueue(head);
            // layerTraverse_useTwoList(head);
        }

        private static void LRN_I(TN head)
        {
            if (head == null)
                return;

            Stack<TN> stack = new Stack<TN>();

            TN visitedTN = null;
            TN temp = head;
            while (stack.Count > 0 || temp != null)
            {
                if (temp == null)
                {
                    temp = stack.Peek();
                    
                    if (temp.rightNode != null && temp.rightNode != visitedTN)
                    {
                        temp = temp.rightNode;
                        stack.Push(temp);
                        
                        temp = temp.leftNode; 
                        continue;
                    }

                    // Traverse node and pop stack
                    temp = stack.Pop();
                    visitedTN = temp;
                    print(temp.value);
                    temp = null;
                }
                else
                {
                    stack.Push(temp);
                    temp = temp.leftNode;
                }
            }
        }

        private static void LNR_I(TN head)
        {
            if (head == null)
                return;
            
            Stack<TN> stack = new Stack<TN>();
            
            TN temp = head;
            while (stack.Count > 0 || temp != null)
            {
                if (temp == null)
                {
                    temp = stack.Pop();
                    print(temp.value);

                    temp = temp.rightNode;
                }
                else
                {
                    stack.Push(temp);

                    temp = temp.leftNode;
                }
            }
        }

        private static void layerTraverse_useTwoList(TN head)
        {
            if (head == null)
                return;

            List<TN> traverseList = new List<TN>();
            
            traverseList.Add(head);
            while (traverseList.Count >= 0)
            {
                int len = traverseList.Count;
                
                List<TN> savePresentLayerElementsList = new List<TN>();
                // The number of the next layer must less than or equals to len * 2
                // List<TN> savePresentLayerElementsList = new List<TN>(len << 1);
                for (int i = 0; i < len; i++)
                {
                    TN temp = traverseList[i];
                    print(temp.value);
                    
                    if(temp.leftNode != null)
                        savePresentLayerElementsList.Add(temp.leftNode);
                    
                    if(temp.rightNode != null)
                        savePresentLayerElementsList.Add((temp.rightNode));
                }

                traverseList = savePresentLayerElementsList;
            }
        }

        private static void layerTraverse_useQueue(TN head)
        {
            if (head == null)
                return;

            Queue<TN> queue = new Queue<TN>();

            queue.Enqueue(head);
            while (queue.Count > 0)
            {
                int length = queue.Count;
                for (int i = 0; i < length; i++)
                {
                    TN temp = queue.Dequeue();
                    print(temp.value);
                    
                    if(temp.leftNode != null)
                        queue.Enqueue(temp.leftNode);
                    
                    if(temp.rightNode != null)
                        queue.Enqueue((temp.rightNode));
                }
            }
        }

        private static void NLR_I(TN head)
        {
            Stack<TN> stack = new Stack<TN>();

            if (head == null)
                return;
            
            TN temp = head;
            while (stack.Count > 0 || temp != null)
            {
                if (temp == null)
                {
                    temp = stack.Pop();
                    temp = temp.rightNode;
                }
                else
                {
                    stack.Push(temp);
                    print(temp.value);

                    temp = temp.leftNode;
                }
            }
        }

        private static void LRN_R(TN head)
        {
            if (head == null)
                return;
            
            LRN_R(head.leftNode);
            LRN_R(head.rightNode);
            
            print(head.value);
        }

        private static void LNR_R(TN head)
        {
            if (head == null)
                return;
            
            LNR_R(head.leftNode);
            
            print(head.value);
            
            LNR_R(head.rightNode);
        }

        private static void NLR_R(TN head)
        {
            if (head == null)
                return;
            
            print(head.value);
            
            NLR_R(head.leftNode);
            NLR_R(head.rightNode);
        }

        private static void print(int headValue)
        {
            Console.WriteLine(headValue);
        }
    }
    

    public class TN
    {
        public TN(int value)
        {
            this.value = value;
            leftNode = null;
            rightNode = null;
        }

        public int value;
        public TN leftNode;
        public TN rightNode;
    }
   
    
    
}