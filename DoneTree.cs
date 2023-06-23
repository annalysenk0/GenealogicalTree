using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Дерево;
using static GenealogicalTree.SaveTree;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GenealogicalTree
{
    // Клас відповідає за завантаження збереженого дерева .json
    // у treeview програми (перший метод) та перетворення 
    // серіалізованих вузлів у список вузлів TreeNode (другий метод).
    public class DoneTree
    {
        private TreeView treeView;
        public DoneTree(TreeView treeView)
        {
            this.treeView = treeView;
        }

        //public void UploadTree()
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "JSON files (*.json)|*.json";
        //    openFileDialog.Title = "Load TreeView from JSON";
        //    openFileDialog.ShowDialog();

        //    if (openFileDialog.FileName != "")
        //    {
        //        string json = File.ReadAllText(openFileDialog.FileName);
        //        List<Person> modules = JsonConvert.DeserializeObject<List<Person>>(json);

        //        treeView.Nodes.Clear();

        //        foreach (Person module in modules)
        //        {
        //            TreeNode rootNode = CreateTreeNode(module);
        //            treeView.Nodes.Add(rootNode);
        //        }
        //    }
        //}

        //private static TreeNode CreateTreeNode(Person module)
        //{
        //    TreeNode node = new TreeNode(module.FirstName);

        //    foreach (Person childModule in module.SubModules)
        //    {
        //        TreeNode childNode = CreateTreeNode(childModule);
        //        node.Nodes.Add(childNode);
        //    }

        //    return node;
        //}

        public void UploadTree()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string jsonFilePath = openFileDialog.FileName;
                string jsonContent = File.ReadAllText(jsonFilePath);

                List<SerializableTreeNode> nodes = 
                    JsonConvert.DeserializeObject<List<SerializableTreeNode>>(jsonContent);

                treeView.Nodes.Clear();

                treeView.Nodes.AddRange(ConvertToTreeViewNodes(nodes).ToArray());
            }
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

