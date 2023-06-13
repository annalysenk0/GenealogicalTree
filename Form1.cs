using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using static System.Windows.Forms.DataFormats;
using System.Net;
using System.Text;
using System.Drawing.Imaging;
using System.Xml;
using Newtonsoft.Json;


namespace Дерево
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveInfo();
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

        public void AddRoot()
        {
            using (FormInfo newForm = new FormInfo())
            {
                newForm.ShowDialog();

                Module modules = newForm.Data;

                if (modules != null)
                {
                    // Створення тексту вузла з іменем та датою народження
                    string nodeText = modules.LastName + " " + modules.FirstName + " " + modules.PatronymicName;
                    string nodeDate = modules.Date;
                    nodeText += " " + "(" + nodeDate + ")";

                    // Створення нового вузла з головним нащадком
                    TreeNode rootNode = new TreeNode(nodeText);
                    rootNode.Tag = modules;

                    // Додавання вузла до дерева
                    treeView.Nodes.Add(rootNode);
                }
            }
        }


        private void openNewForm_Click(object sender, EventArgs e)
        {
            AddRoot();
        }

        public void AddNode()
        {
            using (FormInfo newForm = new FormInfo())
            {
                newForm.ShowDialog();

                Module modules = newForm.Data;

                if (modules != null)
                {
                    // Створення тексту вузла з іменем та датою народження
                    string nodeText = modules.LastName + " " + modules.FirstName + " " + modules.PatronymicName;
                    string nodeDate = modules.Date;
                    nodeText += " " + "(" + nodeDate + ")";

                    // Створення нового вузла з головним нащадком
                    TreeNode rootNode = new TreeNode(nodeText);
                    rootNode.Tag = modules;

                    // Отримання вибраного вузла в дереві
                    TreeNode selectedNode = treeView.SelectedNode;

                    if (selectedNode != null)
                    {
                        // Додавання нового вузла як нащадка до вибраного вузла
                        selectedNode.Nodes.Add(rootNode);
                    }
                    else
                    {
                        // Якщо не вибрано жодного вузла, додати новий вузол до кореня дерева
                        treeView.Nodes.Add(rootNode);
                    }
                }
            }
        }


        private void addNode_Click(object sender, EventArgs e)
        {
            AddNode();
        }

        public void EditNode()
        {
            TreeNode selectedNode = treeView.SelectedNode;

            if (selectedNode != null)
            {
                Module modules = selectedNode.Tag as Module;

                if (modules != null)
                {
                    using (FormInfo newForm = new FormInfo())
                    {
                        newForm.GetData(modules); // Передача даних вузла до форми редагування
                        newForm.ShowDialog();

                        Module updatedModules = newForm.Data;

                        if (updatedModules != null)
                        {
                            // Оновлення тексту вузла з оновленими даними
                            string nodeText = updatedModules.LastName + " " + updatedModules.FirstName + " " + updatedModules.PatronymicName;
                            string nodeDate = updatedModules.Date;
                            nodeText += " " + "(" + nodeDate + ")";
                            selectedNode.Text = nodeText;

                            // Оновлення даних вузла
                            selectedNode.Tag = updatedModules;
                        }
                    }
                }
            }
        }


        private void editNode_Click(object sender, EventArgs e)
        {
            EditNode();
        }




        private void ExpandAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Expand();
                ExpandAllNodes(node.Nodes);
            }
        }

        public void SearchConnexion()
        {
            Search searchForm = new Search();

            TreeNode selectedNode = treeView.SelectedNode;
            if (selectedNode != null)
            {
                ExpandAllNodes(treeView.Nodes);
                searchForm.node.Text = selectedNode.Text;

                List<string> descendants = GetDescendants(selectedNode);
                if (descendants.Count > 0)
                {
                    searchForm.posterity.Text = string.Join(Environment.NewLine, descendants);
                }
                else
                {
                    searchForm.posterity.Text = "Нащадків не знайдено.";
                }

                List<string> ancestors = GetAncestors(selectedNode);
                if (ancestors.Count > 0)
                {
                    searchForm.ancestry.Text = string.Join(Environment.NewLine, ancestors);
                }
                else
                {
                    searchForm.ancestry.Text = "Предків не знайдено.";
                }

                searchForm.ShowDialog();
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            SearchConnexion();
        }

        private List<string> GetDescendants(TreeNode node)
        {
            List<string> descendants = new List<string>();
            foreach (TreeNode childNode in node.Nodes)
            {
                descendants.Add(childNode.Text);
                descendants.AddRange(GetDescendants(childNode));
            }
            return descendants;
        }

        private List<string> GetAncestors(TreeNode node)
        {
            List<string> ancestors = new List<string>();
            TreeNode parent = node.Parent;
            while (parent != null)
            {
                ancestors.Add(parent.Text);
                parent = parent.Parent;
            }
            return ancestors;
        }

        public void DeleteNode()
        {
            // Переконайтеся, що вузол є обраним
            if (treeView.SelectedNode != null)
            {
                // Показати підтверджувальне повідомлення
                DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити вузол?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Перевірка результату підтвердження
                if (result == DialogResult.Yes)
                {
                    // Видалення обраного вузла
                    treeView.SelectedNode.Remove();
                }
            }
        }

        private void deleteNode_Click(object sender, EventArgs e)
        {
            DeleteNode();
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

        public void UploudTree()
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

        private void uploudTree_Click(object sender, EventArgs e)
        {
            UploudTree();
        }

        public class SerializableTreeNode
        {
            public string Text { get; set; }
            public object Tag { get; set; }
            public List<SerializableTreeNode> Nodes { get; set; }
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

        private void createPicture_Click(object sender, EventArgs e)
        {
            CreatePicture();
        }
    }


}


