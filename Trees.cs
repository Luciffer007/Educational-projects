using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesLibrary
{
    public class BinarySearchTree
    {
        // Node value.
        public long? Data { get; private set; }
        // Link to the parent node.
        public BinarySearchTree Parent { get; private set; }
        // Link to the left child node.
        public BinarySearchTree Left { get; private set; }
        // Link to the right child node.
        public BinarySearchTree Right { get; private set; }

        public BinarySearchTree(long root)
        {
            Data = root;
        }

        // Inserting a single node into a tree.
        public void Insert(long number)
        {
            // If the node is empty or its value is equal to the given.
            if (Data == null || Data == number)
            {
                // Write the given value into it.
                Data = number;
                return;
            }

            // If the given value is less than the value of the current node.
            if (Data > number)
            {
                // Create a new left child node, if there is none.
                if (Left == null)
                {
                    Left = new BinarySearchTree(number);
                    Left.Parent = this;
                }
                // Or go down the left branch to the node below and repeat the operation.
                else Left.Insert(number);
            }
            else
            {
                // Otherwise create a new right child node, if there is none. 
                if (Right == null)
                {
                    Right = new BinarySearchTree(number);
                    Right.Parent = this;
                }
                // Or go down the right branch to the node below and repeat the operation.
                else Right.Insert(number);
            }
        }

        // Inserting multiple nodes into a tree.
        public void Insert(long[] numberArray)
        {
            // For each element of the array. 
            for (int i = 0; i < numberArray.Length; i++)
            {
                // Perform the operation of inserting a new node of the tree.
                Insert(numberArray[i]);
            }
        }

        // Removing a node from a tree.
        public void Delete(BinarySearchTree node)
        {
            // If there are no child nodes.
            if (node.Left == null && node.Right == null)
            {
                // Just delete the node.
                if (node == node.Parent.Left) node.Parent.Left = null;
                else node.Parent.Right = null;
                return;
            }

            // If there is a right child node
            if (node.Left == null && node.Right != null)
            {
                // Replace the deleted node with it.
                if (node == node.Parent.Left) node.Parent.Left = node.Right;
                else node.Parent.Right = node.Right;
                node.Right.Parent = node.Parent;
                return;
            }

            // If there is a left child node
            if (node.Left != null && node.Right == null)
            {
                // Replace the deleted node with it.
                if (node == node.Parent.Left) node.Parent.Left = node.Left;
                else node.Parent.Right = node.Left;
                node.Left.Parent = node.Parent;
                return;
            }

            // If there are both children node.
            if (node.Left != null && node.Right != null)
            {
                // Replace the deleted node with the right child node
                if (node == node.Parent.Left) node.Parent.Left = node.Right;
                else node.Parent.Right = node.Right;
                node.Right.Parent = node.Parent;

                // And the left child node insert in the right child node.
                BinarySearchTree temp = node.Right;
                while (temp.Left != null) temp = temp.Left;
                temp.Left = node.Left;
                node.Left.Parent = temp;
            }
        }

        // Search for a tree node with a given value.
        public BinarySearchTree Find(long number)
        {
            // If the given value is equal to the value of the node, return the current node.
            if (Data == number) return this;

            // If the given value is less than the value of the current node.
            if (Data > number && Left != null)
            {
                // Search in the left branch.
                return Left.Find(number);
            }

            // If the given value is greater than the value of the current node.
            if (Data < number && Right != null)
            {
                // Search in the right branch.
                return Right.Find(number);
            }

            // If the node is not found, return null.
            return null;
        }

        // Finding the tree node with the maximum value.
        public long? FindMax()
        {
            // Go down the right branch.
            return Right != null ? Right.FindMax() : Data;
        }

        // Finding the tree node with the minimum value.
        public long? FindMin()
        {
            // Go down the left branch.
            return Left != null ? Left.FindMin() : Data;
        }
    }
}
