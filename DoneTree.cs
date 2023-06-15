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
            List<Module> modules = JsonConvert.DeserializeObject<List<Module>>(json);

            treeView.Nodes.Clear();

            foreach (Module module in modules)
            {
                TreeNode rootNode = CreateTreeNodeFromModule(module);
                treeView.Nodes.Add(rootNode);
            }
        }
    }
        
        private static TreeNode CreateTreeNodeFromModule(Module module)
    {
        TreeNode node = new TreeNode(module.FirstName);

        foreach (Module childModule in module.SubModules)
        {
            TreeNode childNode = CreateTreeNodeFromModule(childModule);
            node.Nodes.Add(childNode);
        }

        return node;
    }
    }

}

