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

        //public void SaveInfo()
        //{
        //    List<Person> modules = new List<Person>();

        //    foreach (TreeNode rootNode in treeView.Nodes)
        //    {
        //        Person module = CreateModule(rootNode);
        //        modules.Add(module);
        //    }

        //    string json = JsonConvert.SerializeObject(modules, Formatting.Indented);

        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "JSON files (*.json)|*.json";
        //    saveFileDialog.Title = "Збереження дерева у форматі JSON";
        //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        File.WriteAllText(saveFileDialog.FileName, json);
        //        MessageBox.Show("Дані з дерева були успішно збережені.");
        //    }
        //}

        //private static Person CreateModule(TreeNode node)
        //{
        //    Person module = new Person(node.Text, "", "", "");

        //    if (node.Nodes.Count > 0)
        //    {
        //        foreach (TreeNode childNode in node.Nodes)
        //        {
        //            Person childModule = CreateModule(childNode);
        //            module.SubModules.Add(childModule);
        //        }
        //    }

        //    return module;
        //}
        public void SaveInfo()
        {
            // Створення діалогового вікна збереження файлу
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "JSON файл (*.json)|*.json";
            saveDialog.Title = "Зберегти дерево вузлів";

            // Показуємо діалогове вікно та очікуємо вибору користувача
            DialogResult result = saveDialog.ShowDialog();

            // Перевіряємо, чи користувач обрав файл та натиснув кнопку "Зберегти"
            if (result == DialogResult.OK)
            {
                // Отримуємо шлях до вибраного файлу
                string filePath = saveDialog.FileName;

                // Отримання дерева вузлів у вигляді колекції SerializableTreeNode
                var nodes = ConvertToSerializableNodes(treeView.Nodes);

                // Конвертування дерева вузлів у JSON-рядок
                string json = JsonConvert.SerializeObject(nodes, Newtonsoft.Json.Formatting.Indented);

                // Збереження JSON-рядка у вибраний файл
                File.WriteAllText(filePath, json);

                // Повідомлення про успішне збереження
                MessageBox.Show($"Дані з дерева були успішно збережені.");
            }
        }

        //public class SerializableTreeNode винесла окремо
        //{
        //    public string Text { get; set; }
        //    public object Tag { get; set; }
        //    public List<SerializableTreeNode> Nodes { get; set; }
        //}

        private List<SerializableTreeNode> ConvertToSerializableNodes(TreeNodeCollection nodes)
        {
            List<SerializableTreeNode> serializableNodes = new List<SerializableTreeNode>();
            foreach (TreeNode node in nodes)
            {
                SerializableTreeNode serializableNode = new SerializableTreeNode
                {
                    Text = node.Text,
                    Tag = node.Tag,
                    Nodes = ConvertToSerializableNodes(node.Nodes)
                };
                serializableNodes.Add(serializableNode);
            }
            return serializableNodes;
        }
    }
}

