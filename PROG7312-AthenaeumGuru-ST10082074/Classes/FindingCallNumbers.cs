using PROG7312_AthenaeumGuru_ST10082074.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TressSampleApplication.Classes;

namespace PROG7312_AthenaeumGuru_ST10082074.Classes
{
    internal class FindingCallNumbers
    {
        private readonly Tree _deweyTree;
        private readonly Random _random;

        public FindingCallNumbers(Tree deweyTree)
        {
            _deweyTree = deweyTree;
            _random = new Random();
        }
        public List<TreeNode> GetRandomSecondLevelNodes(int count)
        {
            List<TreeNode> allSecondLevelNodes = _deweyTree.Root.Children.ToList();
            return GetRandomNodes(allSecondLevelNodes, count);
        }

        /*public List<TreeNode> GetRandomThirdLevelNodes(TreeNode fourthLevelNode, int count)
        {
            if (fourthLevelNode != null && fourthLevelNode.Parent != null && fourthLevelNode.Parent.Parent != null)
            {
                List<TreeNode> allThirdLevelNodes = fourthLevelNode.Parent.Parent.Children
                    .SelectMany(node => node.Children)
                    .ToList();

                return GetRandomNodes(allThirdLevelNodes, count);
            }

            return new List<TreeNode>();
        }

        public TreeNode GetRandomFourthLevelNode(List<TreeNode> secondLevelNodes)
        {
            List<TreeNode> allFourthLevelNodes = secondLevelNodes
                .SelectMany(node => node.Children) // Level 3
                .SelectMany(node => node.Children) // Level 4
                .ToList();

            return GetRandomNode(allFourthLevelNodes);
        }*/
        public List<TreeNode> GetRandomThirdLevelNodes(TreeNode secondLevelNode, int count)
        {
            if (secondLevelNode != null && secondLevelNode.Children != null && secondLevelNode.Children.Any())
            {
                List<TreeNode> allThirdLevelNodes = secondLevelNode.Children.ToList();
                return GetRandomNodes(allThirdLevelNodes, count);
            }

            return new List<TreeNode>();
        }

        public TreeNode GetRandomFourthLevelNode(List<TreeNode> thirdLevelNodes)
        {
            if (thirdLevelNodes != null && thirdLevelNodes.Any())
            {
                List<TreeNode> allFourthLevelNodes = thirdLevelNodes
                    .SelectMany(node => node.Children)
                    .ToList();

                return GetRandomNode(allFourthLevelNodes);
            }

            return null;
        }


        private List<TreeNode> GetRandomNodes(List<TreeNode> nodes, int count)
        {
            List<TreeNode> randomNodes = new List<TreeNode>();

            while (randomNodes.Count < count && nodes.Count > 0)
            {
                TreeNode randomNode = GetRandomNode(nodes);
                randomNodes.Add(randomNode);
                nodes.Remove(randomNode);
            }

            return randomNodes;
        }

        private TreeNode GetRandomNode(List<TreeNode> nodes)
        {
            int index = _random.Next(nodes.Count);
            return nodes[index];
        }

        public bool CheckUser(char btnC, char textC)
        {
            //char btnC = btn[0];
            //char textC = text[0];
            if (btnC.Equals(textC))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}