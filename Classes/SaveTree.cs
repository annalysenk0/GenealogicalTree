using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GenealogicalTree.DoneTree;

namespace GenealogicalTree
{
    // Клас,що містить метод збереження інформаційної частини дерева (вузлів)
    // та метод серіалізації вузлів.
    public class SaveTree
    {
        private TreeView treeView;
        public SaveTree(TreeView treeView)
        {
            this.treeView = treeView;
        }

        public void SaveInfo()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "JSON файл (*.json)|*.json";
            saveDialog.Title = "Зберегти дерево вузлів";

            DialogResult result = saveDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = saveDialog.FileName;

                var nodes = ConvertToSerializableNodes(treeView.Nodes);

                string json = JsonConvert.SerializeObject
                    (nodes, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(filePath, json);
                MessageBox.Show("Дані з дерева були успішно збережені.");
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

