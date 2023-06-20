using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogicalTree
{
    public class TreePicture
    {
        private TreeView treeView;
        public TreePicture(TreeView treeView)
        {
            this.treeView = treeView;
        }

        public void CreatePicture()
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PNG зображення (*.png)|*.png";
                saveDialog.Title = "Збереження зображення";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveDialog.FileName;

                    // Створення об'єкту Bitmap для збереження зображення
                    Bitmap image = new Bitmap(treeView.Width, treeView.Height);

                    // Запуск методу DrawToBitmap для зображення TreeView на Bitmap
                    treeView.DrawToBitmap(image, new Rectangle(0, 0, treeView.Width, treeView.Height));

                    // Збереження зображення
                    image.Save(filePath, ImageFormat.Png);

                    MessageBox.Show($"Дерево було успішно збережено у вигляді зображення.", "Збереження дерева", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
