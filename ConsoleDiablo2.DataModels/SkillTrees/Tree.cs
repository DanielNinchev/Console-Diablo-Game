using System;
using System.Collections.Generic;

namespace ConsoleDiablo2.DataModels.SkillTrees
{
    public class Tree<T>
    {
        // The root of the Tree
        private TreeNode<T> root;

        //The names of each root in a list
        private List<T> rootNames = new List<T>();

        /// <summary> Constructs the Tree </summary>
        /// <param name="name">the value of the node</param>
        public Tree(T name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            root = new TreeNode<T>(name);
        }

        /// <summary> Constructs the Tree </summary>
        /// <param name="name">the name of the tree</param>
        /// <param name="children">the children (derivative skills) of the root</param>
        public Tree(T name, params Tree<T>[] children) : this(name)
        {
            foreach (Tree<T> child in children)
            {
                root.AddChild(child.root);
            }
        }

        /// <summary> Traverses and prints Tree in Depth First Search (DFS) order </summary>
        /// <param name="root">the root of the Tree to be traversed</param>
        /// <param name="spaces">the spaces used for representation
        /// of the parent-child relation</param>
        private void PrintDFS(TreeNode<T> root, string spaces)
        {
            string spaceFromConsoleWindowToFirstRoot = "";

            for (int i = 0; i <= Console.WindowWidth / 10; i++)
            {
                spaceFromConsoleWindowToFirstRoot = string.Concat(spaceFromConsoleWindowToFirstRoot, " ");
            }

            if (this.root == null)
            {
                return;
            }

            Console.WriteLine(spaceFromConsoleWindowToFirstRoot + spaces + root.Name);

            TreeNode<T> child = null;

            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                PrintDFS(child, spaces + "   ");
            }
        }

        /// <summary> Traverses & prints the Tree in Depth First Search (DFS) order </summary>
        public void PrintDFS() => PrintDFS(root, string.Empty);

        private void AddTreeNodeToCollection(TreeNode<T> root)
        {
            if (this.root == null)
            {
                return;
            }

            TreeNode<T> child = null;

            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);

                if (!child.Name.ToString().Contains("SKILLS"))
                {
                    rootNames.Add(child.Name);
                }     

                AddTreeNodeToCollection(child);
            }
        }

        public void AddTreeNodeToCollection() => this.AddTreeNodeToCollection(this.root);

        public List<T> GetRootNamesInAList() => this.GetRootNamesInAList(this.root);

        private List<T> GetRootNamesInAList(TreeNode<T> root)
        {
            this.AddTreeNodeToCollection(root);

            return this.rootNames;
        }
    }
}

