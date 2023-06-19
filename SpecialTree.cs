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

        //public static void GenerateGenealogicalTree(TreeView treeView, TreeNode selectedNode)
        //{
        //    if (selectedNode == null)
        //        return;

        //    // Очищення дерева
        //    treeView.Nodes.Clear();

        //    // Копіювання вибраного вузла та його нащадків
        //    TreeNode rootNode = selectedNode.Clone() as TreeNode;
        //    RemoveNonDescendants(rootNode);

        //    // Додавання нового вузла до кореня дерева
        //    treeView.Nodes.Add(rootNode);
        //}

        //private static void RemoveNonDescendants(TreeNode node)
        //{
        //    // Рекурсивно видалення всіх вузлів, які не є нащадками вибраного вузла
        //    TreeNode selectedNode = node.TreeView.SelectedNode;
        //    for (int i = node.Nodes.Count - 1; i >= 0; i--)
        //    {
        //        TreeNode childNode = node.Nodes[i];
        //        if (!IsDescendant(childNode, selectedNode))
        //        {
        //            node.Nodes.RemoveAt(i);
        //        }
        //        else
        //        {
        //            RemoveNonDescendants(childNode);
        //        }
        //    }
        //}

        //private static bool IsDescendant(TreeNode node, TreeNode selectedNode)
        //{
        //    // Перевірка, чи є вузол нащадком вибраного вузла
        //    while (node != null)
        //    {
        //        if (node == selectedNode)
        //            return true;
        //        node = node.Parent;
        //    }
        //    return false;
        //}


    }
}
