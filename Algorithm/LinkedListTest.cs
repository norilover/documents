using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ConsoleTest.A
{
    public class LinkedListTest
    {
        public static void print(string addElement) => Console.WriteLine(addElement);
        public static void _Main(string[] args)
        {
            LinkedList list = new LinkedList();
            int i = 100;
            while (i-- > 0)
            {
                list.addAtHead(i);
                LinkedListTest.print("add element " + i);
            }

            i = 0;
            while (++i <= list.size())
            {
                LinkedListTest.print("get element " + list.get(i));
            }
        }


        public interface IList
        {
            void addAtTail(int value);
            void addAtHead(int value);
            int  get(int index);
            void addAtIndex(int index, int  value);
        }
        
        public class Node
        {
            public int value;
            public Node next;
        }

        /***
         * 带头节点链表
         */
        public class LinkedList : IList
        {
            private int length;
            private Node dummy, tail;

            public LinkedList()
            {
                dummy = new Node();
                tail = dummy;
                length = 0;
            }

            public int size() => length;

            public void addAtTail(int value)
            {
                tail.next = new Node() {value = value, next = null};

                // tail 指向尾结点
                tail = tail.next;

                length++;
            }

            public void addAtHead(int value)
            {
                Node node = dummy.next;
                dummy.next = new Node() {value = value, next = node};

                // 处理空链表
                if (tail == dummy)
                {
                    tail = dummy.next;
                }

                length++;
            }

            public int get(int index)
            {
                return getNodeByIndex(index).value;
            }

            /***
             * 获取对应的节点的Node
             */
            private Node getNodeByIndex(int index)
            {
                 int fIndex = 0;
                 Node temp = dummy;
                 while (fIndex < index)
                 {
                     temp = temp.next;
                     fIndex++;
                 }
 
                 return temp;               
            }

            public void addAtIndex(int index, int value)
            {
                // 获取index前一个节点
                Node prevNode = getNodeByIndex(index - 1);
                
                Node nextNode = prevNode.next;

                prevNode.next = new Node() {value = value, next = nextNode};

                
                // 空链表
                if (tail == prevNode)
                {
                    tail = prevNode.next;
                }
                
                length++;
            }
        }
    }
}