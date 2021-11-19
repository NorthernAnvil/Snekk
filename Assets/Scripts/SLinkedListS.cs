using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Script.LinkedSnek { 

public class SLinkedListS<T>
{
    public Node head;

    public class Node
    {
        public T data;
        public Node next;
        public Node(T d)
        {
            data = d;
            next = null;
        }
    }

    public void addLast(T new_data)
        {
            Node new_node = new Node(new_data);

            if (head == null)
            {
                head = new Node(new_data);
                return;
            }

            new_node.next = null;

            Node last = head;
            while (last.next != null)
                last = last.next;

            last.next = new_node;
            return;
        }


    public int getCount()
        {
            Node temp = head;
            int count = 0;
            while (temp != null)
            {
                count++;
                temp = temp.next;
            }

            return count;
        }
    public T getIndex(int key)
        {
            Node current = head;
            int count = 0;

            while (current != null)
            {
                if (count == key) return current.data;

                count++;
                current = current.next;

            }
            return default;
        }

    public void printList()
    {
        Debug.Log(("Count of nodes is " + getCount()));
        
        Node n = head;
        while (n != null)
            {
                Debug.Log(n.data + " ");
                n = n.next;

                    
            }
    }


}
}