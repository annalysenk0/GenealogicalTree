using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogicalTree
{
    // Клас "Пошук у дереві" має методи пошуку зв'язків між вузлами
    // (отримання предків та нащадків обраного вузла).
    public class SearchTree
    {
        private TreeView treeView;
        public SearchTree(TreeView treeView)
        {
            this.treeView = treeView;
        }

        public void SearchConnexion()
        {
            SearchForm searchForm = new SearchForm();
            TreeNode selectedNode = treeView.SelectedNode;
            if (selectedNode != null)
            {
                BuildTree.ExpandAllNodes(treeView.Nodes);
                searchForm.node.Text = selectedNode.Text;
                List<string> descendants = GetDescendants(selectedNode);
                if (descendants.Count > 0)
                {
                    searchForm.posterity.Text = string.Join(Environment.NewLine, descendants);
                }
                else
                {
                    searchForm.posterity.Text = "Нащадків не знайдено.";
                }
                List<string> ancestors = GetAncestors(selectedNode);
                if (ancestors.Count > 0)
                {
                    searchForm.ancestry.Text = string.Join(Environment.NewLine, ancestors);
                }
                else
                {
                    searchForm.ancestry.Text = "Предків не знайдено.";
                }
                searchForm.ShowDialog();
            }
        }

        private List<string> GetDescendants(TreeNode node)
        {
            List<string> descendants = new List<string>();
            foreach (TreeNode childNode in node.Nodes)
            {
                descendants.Add(childNode.Text);
                descendants.AddRange(GetDescendants(childNode));
            }
            return descendants;
        }

        private List<string> GetAncestors(TreeNode node)
        {
            List<string> ancestors = new List<string>();
            TreeNode parent = node.Parent;
            while (parent != null)
            {
                ancestors.Add(parent.Text);
                parent = parent.Parent;
            }
            return ancestors;
        }
    }
}
