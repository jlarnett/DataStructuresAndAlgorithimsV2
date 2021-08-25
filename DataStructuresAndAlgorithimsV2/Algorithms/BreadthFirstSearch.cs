using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2.Algorithms
{
    class BreadthFirstSearch
    {
        public static List<int> BreadthFirstSearchIterative(Node currentNode)
        {
            /*******************************************************************
            *   O(n) Time Complexity
            *   Iterative BFS approach
            ********************************************************************/

            List<int> list = new List<int>();
            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(currentNode);

            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();
                list.Add(currentNode.value);

                if (currentNode.left != null)
                {
                    queue.Enqueue(currentNode.left);
                }

                if (currentNode.right != null)
                {
                    queue.Enqueue(currentNode.right);
                }
            }

            return list;
        }

        public static List<int> BreadthFirstSearchRecursive(Queue<Node> queue, List<int> list)
        {
            /*******************************************************************
            *   O(n) Time Complexity
            *   Recursive BFS approach
            ********************************************************************/

            if (queue.Count == 0)
            {
                return list;
            }

            var currentNode = queue.Dequeue();
            list.Add(currentNode.value);

            if (currentNode.left != null)
            {
                queue.Enqueue(currentNode.left);
            }

            if (currentNode.right != null)
            {
                queue.Enqueue(currentNode.right);
            }

            return BreadthFirstSearchRecursive(queue, list);
        }

    }

    class Node
    {
        /*******************************************************************
        *   Basic Binary Tree Node Implementation.
        ********************************************************************/
        public Node left { get; set; }
        public Node right { get; set; }
        public int value { get; set; }


        public Node(int value)
        {
            this.left = null;
            this.right = null;
            this.value = value;
        }
    }

    class BinarySearchTree
    {
        /*******************************************************************
        *   Basic Binary Tree Implementation with basic Insert for it. Used for DFS
        ********************************************************************/
        public Node root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        public void Insert(int value)
        {
            Node newNode = new Node(value);

            if (this.root == null)
            {
                this.root = newNode;
                return;
            }

            Node currentNode = this.root;

            while (true)
            {
                if (currentNode.value > value)
                {
                    if (currentNode.left == null)
                    {
                        currentNode.left = new Node(value);
                        return;
                    }
                    currentNode = currentNode.left;
                }
                else
                {
                    if (currentNode.right == null)
                    {
                        currentNode.right = new Node(value);
                        return;
                    }
                    currentNode = currentNode.right;
                }
            }
        }
    }
}
