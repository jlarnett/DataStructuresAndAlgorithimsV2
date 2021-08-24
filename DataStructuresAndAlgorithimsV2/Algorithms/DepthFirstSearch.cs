using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2.Algorithms
{
    class DepthFirstSearch
    {

    }

    class DNode
    {
        public DNode left { get; set; }
        public DNode right { get; set; }
        public int value { get; set; }

        public DNode(int value)
        {
            this.left = null;
            this.right = null;
            this.value = value;
        }
    }

    class DBinarySearchTree
    {
        public DNode root;

        public DBinarySearchTree()
        {
            this.root = null;
        }

        public void Insert(int value)
        {
            DNode newNode = new DNode(value);
            if (this.root == null)
            {
                this.root = newNode;
                return;
            }

            DNode currentNode = this.root;
            while (true)
            {
                if (currentNode.value > value)
                {
                    if (currentNode.left == null)
                    {
                        currentNode.left = new DNode(value);
                        return;
                    }

                    currentNode = currentNode.left;
                }
                else
                {
                    if (currentNode.right == null)
                    {
                        currentNode.right = new DNode(value);
                        return;
                    }

                    currentNode = currentNode.right;
                }
            }
        }

        public List<int> DFSInOrder()
        {
            List<int> result = new List<int>();
            TraverseInOrder(this.root, result);
            return result;
        }

        public List<int> DFSPreOrder()
        {
            List<int> result = new List<int>();
            TraversePreOrder(this.root, result);
            return result;
        }

        public List<int> DFSPostOrder()
        {
            List<int> result = new List<int>();
            TraversePostOrder(this.root, result);
            return result;
        }


        public List<int> TraverseInOrder(DNode node, List<int> list)
        {
            if (node.left != null)
            {
                TraverseInOrder(node.left, list);
            }

            list.Add(node.value);

            if (node.right != null)
            {
                TraverseInOrder(node.right, list);
            }

            return list;
        }

        public List<int> TraversePreOrder(DNode node, List<int> list)
        {
            list.Add(node.value);

            if (node.left != null)
            {
                TraversePreOrder(node.left, list);
            }

            if (node.right != null)
            {
                TraversePreOrder(node.right, list);
            }

            return list;
        }

        public List<int> TraversePostOrder(DNode node, List<int> list)
        {
            if (node.left != null)
            {
                TraversePostOrder(node.left, list);
            }

            if (node.right != null)
            {
                TraversePostOrder(node.right, list);
            }

            list.Add(node.value);
            return list;
        }
    }
}
