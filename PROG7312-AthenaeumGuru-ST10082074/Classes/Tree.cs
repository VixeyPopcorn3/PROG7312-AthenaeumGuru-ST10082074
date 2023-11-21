using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_AthenaeumGuru_ST10082074.Classes
{
    internal class Tree
    {
        public TreeNode Root { get; }

        public Tree(string callNumber, string description)
        {
            Root = new TreeNode(callNumber, description);
        }

    }
}
