using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GenealogicalTree.DoneTree;

namespace GenealogicalTree
{
    public class SaveTree
    {
        private TreeView treeView;
        public SaveTree(TreeView treeView)
        {
            this.treeView = treeView;
        }

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
                MessageBox.Show($"Дані з дерева були успішно збережені у файл {filePath}.");
            }
        }

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
