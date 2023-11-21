using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_AthenaeumGuru_ST10082074.Classes
{
    internal class TreeNode
    {
        public string CallNumber { get; }
        public string Description { get; }
        public List<TreeNode> Children { get; }

        public TreeNode(string callNumber, string description)
        {
            CallNumber = callNumber;
            Description = description;
            Children = new List<TreeNode>();
        }
        public void AddChild(TreeNode child)
        {
            Children.Add(child);
        }

        public void PrintTree(string prefix = "")
        {
            Console.WriteLine(prefix + $"{CallNumber}\t{Description}");

            for (int i = 0; i < Children.Count; i++)
            {
                if (i == Children.Count - 1)
                    Children[i].PrintTree(prefix + "└── ");
                else
                    Children[i].PrintTree(prefix + "├── ");
            }
        }
        public static Tree BuildDeweyTree(string filePath)
        {
            Tree deweyTree = null;
            TreeNode currentLevel1Node = null;
            TreeNode currentLevel2Node = null;
            TreeNode currentLevel3Node = null;

            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split('\t');

                if (parts.Length < 2)
                    continue;

                string level = parts[0];
                string callNumber = parts[1];
                string description = parts[2];

                if (level.Contains("l1"))
                {
                    deweyTree = new Tree(callNumber, description);
                    currentLevel1Node = deweyTree.Root;
                    currentLevel2Node = null; // Reset currentLevel2Node
                    currentLevel3Node = null; // Reset currentLevel2Node
                }
                else if (level.Contains("l2"))
                {
                    currentLevel2Node = new TreeNode(callNumber, description);
                    if (currentLevel1Node != null)
                        currentLevel1Node.AddChild(currentLevel2Node);
                }
                else if (level.Contains("l3"))
                {
                    currentLevel3Node = new TreeNode(callNumber, description);
                    if (currentLevel2Node != null)
                        currentLevel2Node.AddChild(currentLevel3Node);
                }
                else
                {
                    if (currentLevel3Node != null)
                    {
                        TreeNode currentLevel4Node = new TreeNode(callNumber, description);
                        currentLevel3Node.AddChild(currentLevel4Node);
                    }
                }
            }

            return deweyTree;
        }
    }
}
