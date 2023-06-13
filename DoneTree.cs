using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogicalTree
{
    public class DoneTree
    {
        private TreeView treeView;
        public DoneTree(TreeView treeView)
        {
            this.treeView = treeView;
        }

        public void UploadTree()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string jsonFilePath = openFileDialog.FileName;
                string jsonContent = File.ReadAllText(jsonFilePath);

                List<SerializableTreeNode> nodes = JsonConvert.DeserializeObject<List<SerializableTreeNode>>(jsonContent);

                // Очищення поточного дерева перед завантаженням нового
                treeView.Nodes.Clear();

                // Додавання завантажених вузлів до дерева
                treeView.Nodes.AddRange(ConvertToTreeViewNodes(nodes).ToArray());
            }
        }

        public class SerializableTreeNode
        {
            public string Text { get; set; }
            public object Tag { get; set; }
            public List<SerializableTreeNode> Nodes { get; set; }
        }


        private List<TreeNode> ConvertToTreeViewNodes(List<SerializableTreeNode> serializableNodes)
        {
            List<TreeNode> treeNodes = new List<TreeNode>();
            foreach (SerializableTreeNode serializableNode in serializableNodes)
            {
                TreeNode treeNode = new TreeNode
                {
                    Text = serializableNode.Text,
                    Tag = serializableNode.Tag,
                };

                if (serializableNode.Nodes != null)
                {
                    treeNode.Nodes.AddRange(ConvertToTreeViewNodes(serializableNode.Nodes).ToArray());
                }

                treeNodes.Add(treeNode);
            }
            return treeNodes;
        }
    }
}
