using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2.DataStructureImplementations
{
    public class BinaryTreeNode
    {

        public int Value { get; set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }

        public BinaryTreeNode(int value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }
    class BinarySearchTree
    {
        private BinaryTreeNode root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        public void Insert(int value)
        {

            /**************************************************************************************
            *   Inserts value into Binary Search Tree.
            *   O(Log N) Runtime for Balanced BST. Worst Case O(N)
            ***************************************************************************************/

            BinaryTreeNode newNode = new BinaryTreeNode(value);

            if (this.root == null)
            {
                root = newNode;
                return;
            }

            BinaryTreeNode currentNode = this.root;

            while (true)
            {
                if (value < currentNode.Value)
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = newNode;
                        return;
                    }

                    currentNode = currentNode.Left;
                }
                else
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = newNode;
                        return;
                    }

                    currentNode = currentNode.Right;
                }
            }
        }

        public BinaryTreeNode Lookup(int value)
        {
            /* *****************************************
            *   Returns the Node of given value.
            *   O(Log N) Runtime for Balance BST. Worst Case O(N)
            ********************************************/
            if (root == null)
            {
                return null;
            }

            BinaryTreeNode currentNode = root;

            while (currentNode != null)
            {
                if (value < currentNode.Value)
                {
                    currentNode = currentNode.Left;
                }
                else if (value > currentNode.Value)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    return currentNode;
                }
            }

            return null;
        }

        public void Remove(int value)
        {
            /*****************************************************************
            *   Removes the given value from the tree, then rearranges it to be correct.
            ******************************************************************/

            if (root == null)
            {
                return;
            }

            var nodeToRemove = root;
            BinaryTreeNode parentNode = null;

            while (nodeToRemove.Value != value)
            {
                //Locates the node to remove & also gets the parent node.
                parentNode = nodeToRemove;

                if (value < nodeToRemove.Value)
                {
                    nodeToRemove = nodeToRemove.Left;
                }
                else if(value > nodeToRemove.Value)
                {
                    nodeToRemove = nodeToRemove.Right;
                }
            }

            BinaryTreeNode replacementNode = null;

            if (nodeToRemove.Right != null)
            {
                //Case our node to remove has right child. 
                replacementNode = nodeToRemove.Right;

                if (replacementNode.Left == null)
                {
                    //If our replacement Node doesn't have left child. we make its left child = our node to remove. 
                    replacementNode.Left = nodeToRemove.Left;
                }
                else
                {
                    //Replacement Node has left child. We find the left most
                    BinaryTreeNode replacementParentNode = nodeToRemove;

                    while (replacementNode.Left != null)
                    {
                        replacementParentNode = replacementNode;
                        replacementNode = replacementNode.Left;
                    }

                    replacementParentNode.Left = null;
                    replacementNode.Left = nodeToRemove.Left;
                    replacementNode.Right = nodeToRemove.Right;
                }
            }
            else if (nodeToRemove.Left != null)
            {
                //Node to remove only has left child node. 
                replacementNode = nodeToRemove.Left;
            }

            if (parentNode == null)
            {
                root = replacementNode;
            }
            else if (parentNode.Left == nodeToRemove)
            {
                parentNode.Left = replacementNode;
            }
            else
            {
                parentNode.Right = replacementNode;
            }
        }
    }
}
