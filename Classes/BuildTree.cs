using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogicalTree
{
    // Клас містить методи, які відповідать за побудову генеалогічного дерева
    // (додавання предка, нащадка, редагування вузлів та їх видалення).
    public class BuildTree
    {
        private TreeView treeView;

        public BuildTree(TreeView treeView)
        {
            this.treeView = treeView;
        }

        public void AddRoot()
        {
            using (FormInfo newForm = new FormInfo())
            {
                newForm.ShowDialog();

                Person modules = newForm.Data;
                if (modules != null)
                {
                    string nodeText = modules.LastName + " " + modules.FirstName + 
                        " " + modules.PatronymicName;
                    string nodeDate = modules.Date;
                    nodeText += " " + "(" + nodeDate + ")";

                    TreeNode rootNode = new TreeNode(nodeText);
                    rootNode.Tag = modules;

                    treeView.Nodes.Add(rootNode);
                }
            }
        }

        public void AddNode()
        {
            using (FormInfo newForm = new FormInfo())
            {
                newForm.ShowDialog();
                Person modules = newForm.Data;
                if (modules != null)
                {
                    string nodeText = modules.LastName + " " + modules.FirstName + 
                        " " + modules.PatronymicName;
                    string nodeDate = modules.Date;
                    nodeText += " " + "(" + nodeDate + ")";
                    TreeNode rootNode = new TreeNode(nodeText);
                    rootNode.Tag = modules;
                    TreeNode selectedNode = treeView.SelectedNode;
                    if (selectedNode != null)
                    {
                        selectedNode.Nodes.Add(rootNode);
                    }
                    else
                    {
                        treeView.Nodes.Add(rootNode);
                    }
                }
            }
        }

        public void EditNode()
        {
            TreeNode selectedNode = treeView.SelectedNode;

            if (selectedNode != null)
            {
                Person modules = selectedNode.Tag as Person;

                if (modules != null)
                {
                    using (FormInfo newForm = new FormInfo())
                    {
                        newForm.GetData(modules);
                        newForm.ShowDialog();

                        Person updatedModules = newForm.Data;

                        if (updatedModules != null)
                        {
                            string nodeText = updatedModules.LastName + " " 
                                + updatedModules.FirstName + " " 
                                + updatedModules.PatronymicName;
                            string nodeDate = updatedModules.Date;
                            nodeText += " " + "(" + nodeDate + ")";
                            selectedNode.Text = nodeText;

                            selectedNode.Tag = updatedModules;
                        }
                    }
                    
                }
                else
                    {
                        MessageBox.Show($"Редагування даних можливе лише при " +
                            $"початковому створенні дерева. Завантажене дерево " +
                            $"можна лише переглядати, додавати нові зв'язки та " +
                            $"робити пошук нащадків й предків", "Попередження");
                    }
            }
                    
        }

         public void DeleteNode()
         {
             if (treeView.SelectedNode != null)
             {
                DialogResult result = MessageBox.Show("Ви впевнені, що хочете " +
                    "видалити вузол?", "Підтвердження видалення", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    treeView.SelectedNode.Remove();
                }
             }
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
