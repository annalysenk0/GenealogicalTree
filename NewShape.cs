using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace GenealogicalTree
{
    public partial class NewShape : Form
    {
        private SaveTree saveTree;

        public NewShape()
        {
            InitializeComponent();
            saveTree = new SaveTree(newTree);
        }

        private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            // Перевірка, чи вузол виділений
            bool isSelected = (e.State & TreeNodeStates.Selected) != 0;

            // Визначення кольорів для виділеного та не-виділеного вузла
            Color foreColor = isSelected ? Color.Black : newTree.ForeColor;
            Color backColor = isSelected ? Color.DarkSeaGreen : newTree.BackColor;

            // Заповнення фону вузла
            using (SolidBrush backgroundBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            // Зображення тексту вузла
            TextRenderer.DrawText(e.Graphics, e.Node.Text, newTree.Font, e.Bounds, foreColor, TextFormatFlags.VerticalCenter);

            // Явно встановлюємо фокус на вузол, щоб підсвітка залишалась після втрати фокусу
            if (isSelected)
            {
                ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds);
            }

        }

        private void canceldata_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void savedata_Click(object sender, EventArgs e)
        {
            saveTree.SaveInfo();
        }
    }
}
