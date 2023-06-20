using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using static System.Windows.Forms.DataFormats;
using System.Net;
using System.Text;
using System.Drawing.Imaging;
using System.Xml;
using Newtonsoft.Json;
using GenealogicalTree;


namespace Дерево
{
    public partial class Form1 : Form
    {
        private BuildTree buildTree;
        private SearchTree searchTree;
        private DoneTree doneTree;
        private SaveTree saveTree;
        private TreePicture treePicture;
        private BuildTree expandNodes;
        private SpecialTree specialTree;
        public Form1()
        {
            InitializeComponent();
            buildTree = new BuildTree(treeView);
            searchTree = new SearchTree(treeView);
            doneTree = new DoneTree(treeView);
            saveTree = new SaveTree(treeView);
            treePicture = new TreePicture(treeView);
            specialTree = new SpecialTree(treeView);
        }

        private void BuildFamilyTree(FamilyMember member, TreeNode parentNode)
        {
            foreach (FamilyMember child in member.Children)
            {
                TreeNode childNode = new TreeNode(child.Name);
                childNode.Tag = child;

                parentNode.Nodes.Add(childNode);

                BuildFamilyTree(child, childNode);
            }
        }


        private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            // Перевірка, чи вузол виділений
            bool isSelected = (e.State & TreeNodeStates.Selected) != 0;

            // Визначення кольорів для виділеного та не-виділеного вузла
            Color foreColor = isSelected ? Color.Black : treeView.ForeColor;
            Color backColor = isSelected ? Color.DarkSeaGreen : treeView.BackColor;

            // Заповнення фону вузла
            using (SolidBrush backgroundBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            // Зображення тексту вузла
            TextRenderer.DrawText(e.Graphics, e.Node.Text, treeView.Font, e.Bounds, foreColor, TextFormatFlags.VerticalCenter);

            // Явно встановлюємо фокус на вузол, щоб підсвітка залишалась після втрати фокусу
            if (isSelected)
            {
                ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds);
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            saveTree.SaveInfo();
        }

        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Дерево не буде збережено. Закрити програму?", "Попередження", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        public void CleanTree()
        {
            DialogResult result = MessageBox.Show("Ви впевнені, що хочете очистити все дерево?", "Попередження про очищення", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                treeView.Nodes.Clear();
            }
        }


        private void cleanTree_Click(object sender, EventArgs e)
        {
            CleanTree();
        }


        private void openNewForm_Click(object sender, EventArgs e)
        {
            buildTree.AddRoot();
        }


        private void addNode_Click(object sender, EventArgs e)
        {
            buildTree.AddNode();
            BuildTree.ExpandAllNodes(treeView.Nodes);
        }


        private void editNode_Click(object sender, EventArgs e)
        {
            buildTree.EditNode();
        }


        private void search_Click(object sender, EventArgs e)
        {
            searchTree.SearchConnexion();
        }


        private void deleteNode_Click(object sender, EventArgs e)
        {
            buildTree.DeleteNode();
        }

        private void uploadTree_Click(object sender, EventArgs e)
        {
            doneTree.UploadTree();
            BuildTree.ExpandAllNodes(treeView.Nodes);
        }

        private void createPicture_Click(object sender, EventArgs e)
        {
            treePicture.CreatePicture();
        }


        private void newTree_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView.SelectedNode;

            if (selectedNode != null)
            {
                specialTree.UpdatedTreeView(selectedNode, expandNodes);
            }
            else
            {
                MessageBox.Show("Оберіть вузол дерева.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


}


