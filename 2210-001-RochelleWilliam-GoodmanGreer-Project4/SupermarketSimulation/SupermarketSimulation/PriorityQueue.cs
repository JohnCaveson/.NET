//Project:       Project 4
//Filename:      PriorityQueue.cs
//Description:   Contains information and methods for the PriorityQueues
//Course:        CSCI 2210-001 Data Structures
//Author:        Greer Goodman, goodmang@goldmail.etsu.edu
//Author:        William H. Rochelle, rochellew@goldmail.etsu.edu
//Created:       April 5, 2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketSimulation
{
    public class PriorityQueue<T> : IPriorityQueue<T> where T: IComparable
    {
        //ref to top of PQ
        private Node top;
        //number of items in PQ
        public int Count { get; set; }


        /// <summary>
        /// Private class for Nodes in the Priority Queue
        /// </summary>
        /// <seealso cref="SupermarketSimulation.IPriorityQueue{T}" />
        private class Node
        {
            public T Item { get; set; }
            public Node Next { get; set; }

            public Node(T value, Node link)
            {
                Item = value;
                Next = link;
            }
        }//end node       
        
         
        /// <summary>
        /// Enqueues the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Enqueue(T item)
        {
            if(Count == 0)
            {
                top = new Node(item, null);
            }
            else
            {
                Node current = top;
                Node previous = null;

                //search for the first node in the linked struct that is smaller than item
                while(current != null && current.Item.CompareTo(item) >= 0)
                {
                    previous = current;
                    current = current.Next;
                }

                //Have found the palce to insert the new node
                Node newNode = new Node(item, current);

                //if there is a previous node, set it to the link to the new node
                if(previous != null)
                {
                    previous.Next = newNode;
                }
                else
                {
                    top = newNode;
                }
            }
            Count++; //add 1 to the number of nodes in the PQ
        }

        /// <summary>
        /// Dequeues this instance.
        /// </summary>
        /// <exception cref="InvalidOperationException">Cannot remove from empty queue.</exception>
        public void Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot remove from empty queue.");
            }
            else
            {
                Node oldNode = top;
                top = top.Next;
                Count--;
                oldNode = null;//do this so the removed node can be garbage collected
            }
        }
        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            top = null;
        }
        /// <summary>
        /// Peeks this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Cannot obtain top of empty priority queue.</exception>
        public T Peek()
        {
            if(!IsEmpty())
            {
                return top.Item;
            }
            else
            {
                throw new InvalidOperationException("Cannot obtain top of empty priority queue.");
            }
        }

        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }
    }
    /// <summary>
    /// Interface implemented to Clear, get the count and tell you whether or not the Queue is empty
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContainer<T>
    {
        //Clears the queue
        void Clear();
        //Returns a boolean based on if the Queue is empty or not
        bool IsEmpty();
        //Returns the count of the Queue
        int Count { get; set; }
    }
    /// <summary>
    /// Interface implemented to Enqueue, Dequeue and Peek at items in the Priority Queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="SupermarketSimulation.IContainer{T}" />
    public interface IPriorityQueue<T> : IContainer<T>
                            where T : IComparable
    {
        //Add an item to the Queue based on Priority
        void Enqueue(T item);
        //removes first item in the queue
        void Dequeue();
        //Returns the items at the front of the queue without Dequeueing it
        T Peek();
    }
}
