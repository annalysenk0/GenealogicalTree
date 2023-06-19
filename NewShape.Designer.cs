namespace GenealogicalTree
{
    partial class NewShape
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewShape));
            label1 = new Label();
            newTree = new TreeView();
            pictureBox2 = new PictureBox();
            canceldata = new Button();
            savedata = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkGreen;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(171, 12);
            label1.Name = "label1";
            label1.Size = new Size(839, 41);
            label1.TabIndex = 2;
            label1.Text = "Генеалогічне дерево відносно обраного вузла";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // newTree
            // 
            newTree.Anchor = AnchorStyles.Top;
            newTree.BackColor = Color.Honeydew;
            newTree.BorderStyle = BorderStyle.None;
            newTree.Location = new Point(60, 69);
            newTree.Name = "newTree";
            newTree.Size = new Size(1019, 476);
            newTree.TabIndex = 3;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Bottom;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(226, 581);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(174, 33);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 27;
            pictureBox2.TabStop = false;
            // 
            // canceldata
            // 
            canceldata.Anchor = AnchorStyles.Bottom;
            canceldata.BackColor = Color.DarkSeaGreen;
            canceldata.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            canceldata.ForeColor = SystemColors.InactiveCaptionText;
            canceldata.Location = new Point(553, 581);
            canceldata.Name = "canceldata";
            canceldata.Size = new Size(141, 33);
            canceldata.TabIndex = 25;
            canceldata.Text = "Закрити";
            canceldata.UseVisualStyleBackColor = false;
            // 
            // savedata
            // 
            savedata.Anchor = AnchorStyles.Bottom;
            savedata.BackColor = Color.DarkSeaGreen;
            savedata.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            savedata.ForeColor = SystemColors.InactiveCaptionText;
            savedata.Location = new Point(406, 581);
            savedata.Name = "savedata";
            savedata.Size = new Size(141, 33);
            savedata.TabIndex = 24;
            savedata.Text = "Зберегти";
            savedata.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(700, 581);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(174, 33);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 28;
            pictureBox1.TabStop = false;
            // 
            // NewShape
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(1140, 640);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(canceldata);
            Controls.Add(savedata);
            Controls.Add(newTree);
            Controls.Add(label1);
            Name = "NewShape";
            Text = "NewShape";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TreeView newTree;
        private PictureBox pictureBox2;
        private Button canceldata;
        private Button savedata;
        private PictureBox pictureBox1;
    }
}