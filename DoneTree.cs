using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Дерево;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            openFileDialog.Title = "Load TreeView from JSON";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                string json = File.ReadAllText(openFileDialog.FileName);
                List<Person> modules = JsonConvert.DeserializeObject<List<Person>>(json);

                treeView.Nodes.Clear();

                foreach (Person module in modules)
                {
                    TreeNode rootNode = CreateTreeNode(module);
                    treeView.Nodes.Add(rootNode);
                }
            }
        }
        
        private static TreeNode CreateTreeNode(Person module)
        {
            TreeNode node = new TreeNode(module.FirstName);

            foreach (Person childModule in module.SubModules)
            {
                TreeNode childNode = CreateTreeNode(childModule);
                node.Nodes.Add(childNode);
            }

            return node;
        }
    }
}

