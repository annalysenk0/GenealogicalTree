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
            // Створення об'єкту Bitmap для збереження зображення
            Bitmap image = new Bitmap(treeView.Width, treeView.Height);

            // Запуск методу DrawToBitmap для зображення TreeView на Bitmap
            treeView.DrawToBitmap(image, new Rectangle(0, 0, treeView.Width, treeView.Height));

            // Збереження зображення
            image.Save("C:\\Users\\anech\\source\\repos\\Дерево\\tree_picture\\treeview_image.png", ImageFormat.Png);

            MessageBox.Show("Дерево було успішно збережено як зображення у папці 'tree_picture'.", "Збереження дерева", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
