namespace Дерево
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            labelSearch = new Label();
            node = new TextBox();
            ancestry = new TextBox();
            label2 = new Label();
            label3 = new Label();
            posterity = new TextBox();
            canceldata = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // labelSearch
            // 
            labelSearch.Anchor = AnchorStyles.Top;
            labelSearch.AutoSize = true;
            labelSearch.Font = new Font("Tahoma", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            labelSearch.ForeColor = Color.DarkGreen;
            labelSearch.ImeMode = ImeMode.NoControl;
            labelSearch.Location = new Point(190, 9);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(522, 41);
            labelSearch.TabIndex = 1;
            labelSearch.Text = "Пошук нащадків та предків:";
            labelSearch.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // node
            // 
            node.AccessibleRole = AccessibleRole.Text;
            node.Anchor = AnchorStyles.Top;
            node.BackColor = Color.Honeydew;
            node.BorderStyle = BorderStyle.None;
            node.Font = new Font("Tahoma", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            node.ForeColor = Color.DarkGreen;
            node.Location = new Point(51, 65);
            node.Name = "node";
            node.ReadOnly = true;
            node.Size = new Size(787, 33);
            node.TabIndex = 2;
            node.TextAlign = HorizontalAlignment.Center;
            // 
            // ancestry
            // 
            ancestry.Anchor = AnchorStyles.Top;
            ancestry.BackColor = SystemColors.Window;
            ancestry.Location = new Point(20, 153);
            ancestry.Multiline = true;
            ancestry.Name = "ancestry";
            ancestry.ReadOnly = true;
            ancestry.ScrollBars = ScrollBars.Vertical;
            ancestry.Size = new Size(368, 189);
            ancestry.TabIndex = 3;
            ancestry.WordWrap = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DarkGreen;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(130, 116);
            label2.Name = "label2";
            label2.Size = new Size(134, 34);
            label2.TabIndex = 4;
            label2.Text = "Предки:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.DarkGreen;
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(627, 116);
            label3.Name = "label3";
            label3.Size = new Size(159, 34);
            label3.TabIndex = 6;
            label3.Text = "Нащадки:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // posterity
            // 
            posterity.Anchor = AnchorStyles.Top;
            posterity.BackColor = SystemColors.Window;
            posterity.Location = new Point(517, 153);
            posterity.Multiline = true;
            posterity.Name = "posterity";
            posterity.ReadOnly = true;
            posterity.ScrollBars = ScrollBars.Vertical;
            posterity.Size = new Size(368, 189);
            posterity.TabIndex = 5;
            // 
            // canceldata
            // 
            canceldata.Anchor = AnchorStyles.Top;
            canceldata.BackColor = Color.DarkSeaGreen;
            canceldata.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            canceldata.ForeColor = SystemColors.InactiveCaptionText;
            canceldata.Location = new Point(390, 455);
            canceldata.Name = "canceldata";
            canceldata.Size = new Size(145, 40);
            canceldata.TabIndex = 19;
            canceldata.Text = "Закрити";
            canceldata.UseVisualStyleBackColor = false;
            canceldata.Click += canceldata_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(341, 494);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(242, 33);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(341, 423);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(242, 33);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            // 
            // Search
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(905, 547);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(canceldata);
            Controls.Add(label3);
            Controls.Add(posterity);
            Controls.Add(label2);
            Controls.Add(ancestry);
            Controls.Add(node);
            Controls.Add(labelSearch);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Search";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Search";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelSearch;
        private Label label2;
        private Label label3;
        public TextBox ancestry;
        public TextBox node;
        public TextBox posterity;
        private Button canceldata;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}