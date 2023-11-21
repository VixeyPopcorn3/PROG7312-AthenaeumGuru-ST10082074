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

        // Constructor: Initializes the FindingCallNumbers class with a given Dewey Decimal System tree.
        public FindingCallNumbers(Tree deweyTree)
        {
            _deweyTree = deweyTree;
            _random = new Random();
        }

        // GetRandomSecondLevelNodes: Returns a list of 4 random second-level nodes ordered in numerical order.
        public List<TreeNode> GetRandomSecondLevelNodes(int count)
        {
            List<TreeNode> allSecondLevelNodes = _deweyTree.Root.Children.ToList();

            // GetRandomNodes: Selects and returns a specified number of random nodes from the given list.
            List<TreeNode> randomSecondLevelNodes = GetRandomNodes(allSecondLevelNodes, count);

            // Order the random second-level nodes in numerical order based on string comparison
            randomSecondLevelNodes = randomSecondLevelNodes.OrderBy(node => node.CallNumber).ToList();

            return randomSecondLevelNodes;
        }

        // GetRandomThirdLevelNodes: Returns a list of 4 random third-level nodes under a given second-level node.
        public List<TreeNode> GetRandomThirdLevelNodes(TreeNode secondLevelNode, int count)
        {
            if (secondLevelNode != null && secondLevelNode.Children != null && secondLevelNode.Children.Any())
            {
                List<TreeNode> allThirdLevelNodes = secondLevelNode.Children.ToList();
                
                // GetRandomNodes: Selects and returns a specified number of random nodes from the given list.
                return GetRandomNodes(allThirdLevelNodes, count);
            }

            return new List<TreeNode>();
        }

        // GetRandomFourthLevelNode: Returns a random fourth-level node from a list of third-level nodes.
        public TreeNode GetRandomFourthLevelNode(List<TreeNode> thirdLevelNodes)
        {
            if (thirdLevelNodes != null && thirdLevelNodes.Any())
            {
                // GetRandomNode: Returns a random node from the given list.
                List<TreeNode> allFourthLevelNodes = thirdLevelNodes
                    .SelectMany(node => node.Children)
                    .ToList();

                return GetRandomNode(allFourthLevelNodes);
            }

            return null;
        }

        // GetRandomNodes: Selects and returns a specified number of random nodes from the given list.
        private List<TreeNode> GetRandomNodes(List<TreeNode> nodes, int count)
        {
            List<TreeNode> randomNodes = new List<TreeNode>();

            while (randomNodes.Count < count && nodes.Count > 0)
            {
                // GetRandomNode: Returns a random node from the given list.
                TreeNode randomNode = GetRandomNode(nodes);
                randomNodes.Add(randomNode);
                nodes.Remove(randomNode);
            }

            return randomNodes;
        }

        // GetRandomNode: Returns a random node from the given list.
        private TreeNode GetRandomNode(List<TreeNode> nodes)
        {
            int index = _random.Next(nodes.Count);
            return nodes[index];
        }

        // CheckUser: Compares two characters and returns true if they are equal, false otherwise.
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