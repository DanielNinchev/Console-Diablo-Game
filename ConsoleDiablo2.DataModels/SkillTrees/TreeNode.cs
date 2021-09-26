using System;
using System.Collections.Generic;

namespace ConsoleDiablo2.DataModels.SkillTrees
{
    //TODO: fix exception constants
    public class TreeNode<T>
    {
        //Contains the value of the node
        private T root;

        //Shows whether the current node has parent
        private bool hasParent;

        //Contains the children of the node
        private List<TreeNode<T>> children;

        /// <summary> Constructs a tree node </summary>
        /// <param name="root">the value of the node</param>
        public TreeNode(T root)
        {
            if (root == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            this.root = root;
            children = new List<TreeNode<T>>();
        }

        /// <summary> The value of the node </summary>
        public T Name
        {
            get => root;
            set => root = value;
        }

        public bool HasParent
        {
            get => hasParent;
        }

        /// <summary> The number of node's children </summary>
        public int ChildrenCount => children.Count;

        /// <summary> Adds child to the node </summary>
        /// <param name="child">the child to be added</param>
        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            if (child.hasParent)
            {
                throw new ArgumentException("The node already has a parent!");
            }

            child.hasParent = true;
            children.Add(child);
        }

        /// <summary> Gets the child of the node at given index </summary>
        /// <param name="index">the index of the desired child</param>
        /// <returns>the child on the given position</returns>
        public TreeNode<T> GetChild(int index)
        {
            return children[index];
        }
    }
}
