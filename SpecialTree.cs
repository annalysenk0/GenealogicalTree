using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogicalTree
{
    public class SpecialTree
    {
        private TreeView treeView;

        public SpecialTree(TreeView treeView)
        {
            this.treeView = treeView;
        }

        public void UpdatedTreeView(TreeNode selectedNode, ExpandNodes expandNodes)
        {
            NewShape updatedForm = new NewShape();
            TreeView updatedTreeView = updatedForm.newTree;

            // Додаємо обраний вузол як кореневий вузол
            TreeNode rootNode = new TreeNode(selectedNode.Text);
            updatedTreeView.Nodes.Add(rootNode);

            // Додаємо всі нащадки обраного вузла
            foreach (TreeNode childNode in selectedNode.Nodes)
            {
                rootNode.Nodes.Add((TreeNode)childNode.Clone());
            }

            ExpandNodes.ExpandAllNodes(updatedTreeView.Nodes);
            //updatedForm.Controls.Add(updatedTreeView);
            updatedForm.ShowDialog();
        }


    }
}
