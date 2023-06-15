namespace Дерево
{
    partial class FormInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInfo));
            lable0 = new Label();
            lastname = new TextBox();
            firstname = new TextBox();
            label1 = new Label();
            patronymicname = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            savedata = new Button();
            canceldata = new Button();
            date = new TextBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lable0
            // 
            lable0.AutoSize = true;
            lable0.BackColor = Color.DarkSeaGreen;
            lable0.BorderStyle = BorderStyle.FixedSingle;
            lable0.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lable0.ForeColor = SystemColors.InactiveCaptionText;
            lable0.Location = new Point(25, 60);
            lable0.Name = "lable0";
            lable0.Size = new Size(106, 26);
            lable0.TabIndex = 0;
            lable0.Text = "Призвіще:";
            // 
            // lastname
            // 
            lastname.AutoCompleteMode = AutoCompleteMode.Suggest;
            lastname.BackColor = SystemColors.Window;
            lastname.Location = new Point(311, 60);
            lastname.Name = "lastname";
            lastname.Size = new Size(277, 27);
            lastname.TabIndex = 1;
            lastname.TextChanged += textBox_TextChanged;
            // 
            // firstname
            // 
            firstname.BackColor = SystemColors.Window;
            firstname.Location = new Point(311, 101);
            firstname.Name = "firstname";
            firstname.Size = new Size(278, 27);
            firstname.TabIndex = 2;
            firstname.TextChanged += textBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.DarkSeaGreen;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.InactiveCaptionText;
            label1.Location = new Point(26, 101);
            label1.Name = "label1";
            label1.Size = new Size(54, 26);
            label1.TabIndex = 2;
            label1.Text = "Ім'я:";
            // 
            // patronymicname
            // 
            patronymicname.BackColor = SystemColors.Window;
            patronymicname.Location = new Point(311, 141);
            patronymicname.Name = "patronymicname";
            patronymicname.Size = new Size(278, 27);
            patronymicname.TabIndex = 3;
            patronymicname.TextChanged += textBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.DarkSeaGreen;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.InactiveCaptionText;
            label2.Location = new Point(25, 141);
            label2.Name = "label2";
            label2.Size = new Size(165, 26);
            label2.TabIndex = 4;
            label2.Text = "Ім'я по батькові:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.DarkGreen;
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(174, 9);
            label3.Name = "label3";
            label3.Size = new Size(297, 36);
            label3.TabIndex = 6;
            label3.Text = "Персональні дані:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.DarkSeaGreen;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.InactiveCaptionText;
            label4.Location = new Point(25, 182);
            label4.Name = "label4";
            label4.Size = new Size(184, 26);
            label4.TabIndex = 7;
            label4.Text = "Дата народження:";
            // 
            // savedata
            // 
            savedata.BackColor = Color.DarkSeaGreen;
            savedata.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            savedata.ForeColor = SystemColors.InactiveCaptionText;
            savedata.Location = new Point(311, 310);
            savedata.Name = "savedata";
            savedata.Size = new Size(141, 33);
            savedata.TabIndex = 5;
            savedata.Text = "Зберегти";
            savedata.UseVisualStyleBackColor = false;
            savedata.Click += saveButton_Click;
            // 
            // canceldata
            // 
            canceldata.BackColor = Color.DarkSeaGreen;
            canceldata.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            canceldata.ForeColor = SystemColors.InactiveCaptionText;
            canceldata.Location = new Point(164, 310);
            canceldata.Name = "canceldata";
            canceldata.Size = new Size(141, 33);
            canceldata.TabIndex = 17;
            canceldata.Text = "Скасувати";
            canceldata.UseVisualStyleBackColor = false;
            canceldata.Click += canceldata_Click;
            // 
            // date
            // 
            date.BackColor = SystemColors.Window;
            date.Location = new Point(311, 181);
            date.Name = "date";
            date.Size = new Size(278, 27);
            date.TabIndex = 4;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(187, 271);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(242, 33);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 23;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(187, 349);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(242, 33);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // FormInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(613, 388);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(date);
            Controls.Add(canceldata);
            Controls.Add(savedata);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(patronymicname);
            Controls.Add(label2);
            Controls.Add(firstname);
            Controls.Add(label1);
            Controls.Add(lastname);
            Controls.Add(lable0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormInfo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormInfo";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lable0;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button savedata;
        private Button canceldata;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        public TextBox firstname;
        public TextBox patronymicname;
        public TextBox date;
        public TextBox lastname;
    }
}