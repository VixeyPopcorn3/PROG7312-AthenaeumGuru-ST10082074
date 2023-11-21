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
        // Root: Gets the root node of the tree.
        public TreeNode Root { get; }

        // Constructor: Initializes a new instance of the Tree class with a root node.
        public Tree(string callNumber, string description)
        {
            // Create the root node with the specified call number and description.
            Root = new TreeNode(callNumber, description);
        }

    }
}
