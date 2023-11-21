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

        public TreeNode GetRandomThirdLevelNode(List<TreeNode> secondLevelNodes)
        {
            List<TreeNode> allThirdLevelNodes = secondLevelNodes.SelectMany(node => node.Children).ToList();
            return GetRandomNode(allThirdLevelNodes);
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
        public bool CheckUser(String btn, String text)
        {
            char btnC = btn[0];
            char textC = text[0];
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