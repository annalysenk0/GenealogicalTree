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
    public partial class ShapeForm : Form
    {
        private SaveTree saveTree;

        public ShapeForm()
        {
            InitializeComponent();
        }

        private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            bool isSelected = (e.State & TreeNodeStates.Selected) != 0;

            Color foreColor = isSelected ? Color.Black : newTree.ForeColor;
            Color backColor = isSelected ? Color.DarkSeaGreen : newTree.BackColor;

            using (SolidBrush backgroundBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            TextRenderer.DrawText(e.Graphics, e.Node.Text, newTree.Font, e.Bounds, foreColor, TextFormatFlags.VerticalCenter);

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
