using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogicalTree
{
    // Клас, що містить метод, який відповідає за створення
    // генеалогічного дерева відносно обраного вузла.
    public class SpecialTree
    {
        private TreeView treeView;

        public SpecialTree(TreeView treeView)
        {
            this.treeView = treeView;
        }

        public void UpdatedTreeView(TreeNode selectedNode, BuildTree expandNodes)
        {
            NewShape updatedForm = new NewShape();
            TreeView updatedTreeView = updatedForm.newTree;

            TreeNode rootNode = new TreeNode(selectedNode.Text);
            updatedTreeView.Nodes.Add(rootNode);

            foreach (TreeNode childNode in selectedNode.Nodes)
            {
                rootNode.Nodes.Add((TreeNode)childNode.Clone());
            }

            BuildTree.ExpandAllNodes(updatedTreeView.Nodes);
            //updatedForm.Controls.Add(updatedTreeView);
            updatedForm.ShowDialog();
        }
    }
}
