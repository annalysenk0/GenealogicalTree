using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogicalTree
{
    public class ExpandNodes
    {
        private TreeView treeView;
        public ExpandNodes(TreeView treeView)
        {
            this.treeView = treeView;
        }

        public static void ExpandAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Expand();
                ExpandAllNodes(node.Nodes);
            }
        }
    }
}
