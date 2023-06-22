using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GenealogicalTree.DoneTree;
using Дерево;

namespace GenealogicalTree
{
    // Клас, який містить метод збереження інформаційної частини дерева
    // та метод перетворення вузлів у module.
    public class SaveTree
    {
        private TreeView treeView;
        public SaveTree(TreeView treeView)
        {
            this.treeView = treeView;
        }

        public void SaveInfo()
        {
            List<Person> modules = new List<Person>();

            foreach (TreeNode rootNode in treeView.Nodes)
            {
                Person module = CreateModule(rootNode);
                modules.Add(module);
            }

            string json = JsonConvert.SerializeObject(modules, Formatting.Indented);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            saveFileDialog.Title = "Збереження дерева у форматі JSON";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, json);
                MessageBox.Show("Дані з дерева були успішно збережені.");
            }
        }

        private static Person CreateModule(TreeNode node)
        {
            Person module = new Person(node.Text, "", "", "");

            foreach (TreeNode childNode in node.Nodes)
            {
                Person childModule = CreateModule(childNode);
                module.SubModules.Add(childModule);
            }
            return module;
        }
    }
}
