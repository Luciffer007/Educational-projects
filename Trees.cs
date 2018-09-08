using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTreeNode
    {
        // Node value.
        public long? Data { get; internal set; }
        // Link to the parent node.
        public BinaryTreeNode Parent { get; internal set; }
        // Link to the left child node.
        public BinaryTreeNode Left { get; internal set; }
        // Link to the right child node.
        public BinaryTreeNode Right { get; internal set; }

        // An auxiliary method for finding a tree node with a given value.
        internal BinaryTreeNode Find(long number)
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
        internal long? FindMax()
        {
            // Go down the right branch.
            return Right != null ? Right.FindMax() : Data;
        }

        // Finding the tree node with the minimum value.
        internal long? FindMin()
        {
            // Go down the left branch.
            return Left != null ? Left.FindMin() : Data;
        }
    }

    public abstract class BinaryTreeBase
    {
        // Root node of a binary tree.
        public BinaryTreeNode Root { get; protected set; }

        public BinaryTreeBase(long rootValue)
        {
            Root = new BinaryTreeNode();
            Root.Parent = null;
            Root.Left = null;
            Root.Right = null;
            Root.Data = rootValue;
        }

        // Maximum and minimum values of binary tree.
        public long? Max
        {
            get
            {
                return Root.FindMax();
            }
        }

        public long? Min
        {
            get
            {
                return Root.FindMin();
            }
        }

        // Search for a tree node with a given value.
        public BinaryTreeNode FindInTree(long number)
        {
            return Root.Find(number);
        }

        // Inserting a single node into a tree.
        public abstract void Insert (long number, BinaryTreeNode node);

        // Inserting multiple nodes into a tree.
        public void Insert(long[] numberArray)
        {
            // For each element of the array. 
            for (int i = 0; i < numberArray.Length; i++)
            {
                // Perform the operation of inserting a new node of the tree.
                Insert(numberArray[i], Root);
            }
        }

        // Removing a node from a tree.
        public void Delete(BinaryTreeNode node)
        {
            // Validation of entered data.
            if (node == null || node.Parent == null) return;

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
                BinaryTreeNode temp = node.Right;
                while (temp.Left != null)
                    temp = temp.Left;
                temp.Left = node.Left;
                node.Left.Parent = temp;
            }
        }
    }

    public class BinarySortTree : BinaryTreeBase
    {
        public BinarySortTree(long rootValue)
            : base(rootValue) { }

        public override void Insert(long number, BinaryTreeNode node)
        {
            // If the specified value is less than or equal to the current node value.
            if (node.Data >= number)
            {
                // Create a new left child node, if there is none.
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode();
                    node.Left.Data = number;
                    node.Left.Parent = node;
                }
                // Or go down the left branch to the node below and repeat the operation.
                else Insert(number, node.Left);
            }
            else
            {
                // Otherwise create a new right child node, if there is none. 
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode();
                    node.Right.Data = number;
                    node.Right.Parent = node;
                }
                // Or go down the right branch to the node below and repeat the operation.
                else Insert(number, node.Right);
            }
        }
    }

    public class BinarySearchTree : BinaryTreeBase
    {
        public BinarySearchTree(long rootValue)
            : base(rootValue) { }

        public override void Insert(long number, BinaryTreeNode node)
        {
            // If the node is empty or its value is equal to the given.
            if (node.Data == number)
            {
                // Write the given value into it.
                node.Data = number;
                return;
            }

            // If the given value is less than the value of the current node.
            if (node.Data > number)
            {
                // Create a new left child node, if there is none.
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode();
                    node.Left.Data = number;
                    node.Left.Parent = node;
                }
                // Or go down the left branch to the node below and repeat the operation.
                else Insert(number, node.Left);
            }
            else
            {
                // Otherwise create a new right child node, if there is none. 
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode();
                    node.Right.Data = number;
                    node.Right.Parent = node;
                }
                // Or go down the right branch to the node below and repeat the operation.
                else Insert(number, node.Right);
            }
        }
    }
}
