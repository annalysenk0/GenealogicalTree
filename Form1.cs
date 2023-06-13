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
        public Form1()
        {
            InitializeComponent();
            buildTree = new BuildTree(treeView);
            searchTree = new SearchTree(treeView);
            doneTree = new DoneTree(treeView);
            saveTree = new SaveTree(treeView);
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

        //public void SaveInfo()
        //{
        //    // Створення діалогового вікна збереження файлу
        //    SaveFileDialog saveDialog = new SaveFileDialog();
        //    saveDialog.Filter = "JSON файл (*.json)|*.json";
        //    saveDialog.Title = "Зберегти дерево вузлів";

        //    // Показуємо діалогове вікно та очікуємо вибору користувача
        //    DialogResult result = saveDialog.ShowDialog();

        //    // Перевіряємо, чи користувач обрав файл та натиснув кнопку "Зберегти"
        //    if (result == DialogResult.OK)
        //    {
        //        // Отримуємо шлях до вибраного файлу
        //        string filePath = saveDialog.FileName;

        //        // Отримання дерева вузлів у вигляді колекції SerializableTreeNode
        //        var nodes = ConvertToSerializableNodes(treeView.Nodes);

        //        // Конвертування дерева вузлів у JSON-рядок
        //        string json = JsonConvert.SerializeObject(nodes, Newtonsoft.Json.Formatting.Indented);

        //        // Збереження JSON-рядка у вибраний файл
        //        File.WriteAllText(filePath, json);

        //        // Повідомлення про успішне збереження
        //        MessageBox.Show($"Дані з дерева були успішно збережені у файл {filePath}.");
        //    }
        //}

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            saveTree.SaveInfo();
        }

        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
        }

        //public void EditNode()
        //{
        //    TreeNode selectedNode = treeView.SelectedNode;

        //    if (selectedNode != null)
        //    {
        //        Module modules = selectedNode.Tag as Module;

        //        if (modules != null)
        //        {
        //            using (FormInfo newForm = new FormInfo())
        //            {
        //                newForm.GetData(modules); // Передача даних вузла до форми редагування
        //                newForm.ShowDialog();

        //                Module updatedModules = newForm.Data;

        //                if (updatedModules != null)
        //                {
        //                    // Оновлення тексту вузла з оновленими даними
        //                    string nodeText = updatedModules.LastName + " " + updatedModules.FirstName + " " + updatedModules.PatronymicName;
        //                    string nodeDate = updatedModules.Date;
        //                    nodeText += " " + "(" + nodeDate + ")";
        //                    selectedNode.Text = nodeText;

        //                    // Оновлення даних вузла
        //                    selectedNode.Tag = updatedModules;
        //                }
        //            }
        //        }
        //    }
        //}

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

        public void CreatePicture()
        {
            // Створення об'єкту Bitmap для збереження зображення
            Bitmap image = new Bitmap(treeView.Width, treeView.Height);

            // Запуск методу DrawToBitmap для зображення TreeView на Bitmap
            treeView.DrawToBitmap(image, new Rectangle(0, 0, treeView.Width, treeView.Height));

            // Збереження зображення
            image.Save("C:\\Users\\anech\\source\\repos\\Дерево\\tree_picture\\treeview_image.png", ImageFormat.Png);

            MessageBox.Show("Дерево було успішно збережено як зображення у папці 'tree_picture'.", "Збереження дерева", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void uploadTree_Click(object sender, EventArgs e)
        {
            doneTree.UploadTree();
        }

        //public void UploadTree()
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "JSON files (*.json)|*.json";
        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        string jsonFilePath = openFileDialog.FileName;
        //        string jsonContent = File.ReadAllText(jsonFilePath);

        //        List<SerializableTreeNode> nodes = JsonConvert.DeserializeObject<List<SerializableTreeNode>>(jsonContent);

        //        // Очищення поточного дерева перед завантаженням нового
        //        treeView.Nodes.Clear();

        //        // Додавання завантажених вузлів до дерева
        //        treeView.Nodes.AddRange(ConvertToTreeViewNodes(nodes).ToArray());
        //    }
        //}


        //public class SerializableTreeNode
        //{
        //    public string Text { get; set; }
        //    public object Tag { get; set; }
        //    public List<SerializableTreeNode> Nodes { get; set; }
        //}

        //private List<SerializableTreeNode> ConvertToSerializableNodes(TreeNodeCollection nodes)
        //{
        //    List<SerializableTreeNode> serializableNodes = new List<SerializableTreeNode>();
        //    foreach (TreeNode node in nodes)
        //    {
        //        SerializableTreeNode serializableNode = new SerializableTreeNode
        //        {
        //            Text = node.Text,
        //            Tag = node.Tag,
        //            Nodes = ConvertToSerializableNodes(node.Nodes)
        //        };
        //        serializableNodes.Add(serializableNode);
        //    }
        //    return serializableNodes;
        //}

        //private List<TreeNode> ConvertToTreeViewNodes(List<SerializableTreeNode> serializableNodes)
        //{
        //    List<TreeNode> treeNodes = new List<TreeNode>();
        //    foreach (SerializableTreeNode serializableNode in serializableNodes)
        //    {
        //        TreeNode treeNode = new TreeNode
        //        {
        //            Text = serializableNode.Text,
        //            Tag = serializableNode.Tag,
        //        };

        //        if (serializableNode.Nodes != null)
        //        {
        //            treeNode.Nodes.AddRange(ConvertToTreeViewNodes(serializableNode.Nodes).ToArray());
        //        }

        //        treeNodes.Add(treeNode);
        //    }
        //    return treeNodes;
        //}

        private void createPicture_Click(object sender, EventArgs e)
        {
            CreatePicture();
        }
    }


}


