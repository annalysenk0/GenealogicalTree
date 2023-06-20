using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Дерево;


namespace GenealogicalTree
{
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

                Module modules = newForm.Data;

                if (modules != null)
                {
                    // Створення тексту вузла з іменем та датою народження
                    string nodeText = modules.LastName + " " + modules.FirstName + " " + modules.PatronymicName;
                    string nodeDate = modules.Date;
                    nodeText += " " + "(" + nodeDate + ")";

                    // Створення нового вузла з головним нащадком
                    TreeNode rootNode = new TreeNode(nodeText);
                    rootNode.Tag = modules;

                    // Додавання вузла до дерева
                    treeView.Nodes.Add(rootNode);
                }
            }
        }

        public void AddNode()
        {
            using (FormInfo newForm = new FormInfo())
            {
                newForm.ShowDialog();

                Module modules = newForm.Data;

                if (modules != null)
                {
                    // Створення тексту вузла з іменем та датою народження
                    string nodeText = modules.LastName + " " + modules.FirstName + " " + modules.PatronymicName;
                    string nodeDate = modules.Date;
                    nodeText += " " + "(" + nodeDate + ")";

                    // Створення нового вузла з головним нащадком
                    TreeNode rootNode = new TreeNode(nodeText);
                    rootNode.Tag = modules;

                    // Отримання вибраного вузла в дереві
                    TreeNode selectedNode = treeView.SelectedNode;

                    if (selectedNode != null)
                    {
                        // Додавання нового вузла як нащадка до вибраного вузла
                        selectedNode.Nodes.Add(rootNode);
                    }
                    else
                    {
                        // Якщо не вибрано жодного вузла, додати новий вузол до кореня дерева
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
                Module modules = selectedNode.Tag as Module;

                if (modules != null)
                {
                    using (FormInfo newForm = new FormInfo())
                    {
                        newForm.GetData(modules); // Передача даних вузла до форми редагування
                        newForm.ShowDialog();

                        Module updatedModules = newForm.Data;

                        if (updatedModules != null)
                        {
                            // Оновлення тексту вузла з оновленими даними
                            string nodeText = updatedModules.LastName + " " + updatedModules.FirstName + " " + updatedModules.PatronymicName;
                            string nodeDate = updatedModules.Date;
                            nodeText += " " + "(" + nodeDate + ")";
                            selectedNode.Text = nodeText;

                            // Оновлення даних вузла
                            selectedNode.Tag = updatedModules;
                        }
                    }
                    
                }
                else
                    {
                        MessageBox.Show($"Редагування даних можливе лише при початковому створенні дерева. Завантажене дерево можна лише переглядати, додавати нові зв'язки та робити пошук нащадків й предків", "Попередження");
                    }
            }
                    
        }

            public void DeleteNode()
            {
                if (treeView.SelectedNode != null)
                {
                    // Показати підтверджувальне повідомлення
                    DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити вузол?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Перевірка результату підтвердження
                    if (result == DialogResult.Yes)
                    {
                        // Видалення обраного вузла
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
