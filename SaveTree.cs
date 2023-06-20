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
    public class SaveTree
    {
        private TreeView treeView;
        public SaveTree(TreeView treeView)
        {
            this.treeView = treeView;
        }


        public void SaveInfo()
        {
         
                List<Module> modules = new List<Module>();

                foreach (TreeNode rootNode in treeView.Nodes)
                {
                    Module module = CreateModule(rootNode);
                    modules.Add(module);
                }

                string json = JsonConvert.SerializeObject(modules, Formatting.Indented);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JSON files (*.json)|*.json";
                saveFileDialog.Title = "Save TreeView as JSON";
                

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, json);

                    // Повідомлення про успішне збереження
                    MessageBox.Show("Дані з дерева були успішно збережені.");
                }
        }

            private static Module CreateModule(TreeNode node)
            {
                Module module = new Module(node.Text, "", "", "");

                foreach (TreeNode childNode in node.Nodes)
                {
                    Module childModule = CreateModule(childNode);
                    module.SubModules.Add(childModule);
                }

                return module;
            }
        }
}
