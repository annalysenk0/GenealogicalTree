namespace Дерево
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            file = new ToolStripMenuItem();
            saveMenuItem = new ToolStripMenuItem();
            exitMenuItem = new ToolStripMenuItem();
            Tree = new ToolStripMenuItem();
            newTree = new ToolStripMenuItem();
            createPicture = new ToolStripMenuItem();
            uploudTree = new ToolStripMenuItem();
            cleanTree = new ToolStripMenuItem();
            Create = new Button();
            label1 = new Label();
            deleteNode = new Button();
            add = new Button();
            search = new Button();
            treeView = new TreeView();
            pictureBox1 = new PictureBox();
            pictureBox = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            button1 = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { file, Tree });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            // 
            // file
            // 
            file.DropDownItems.AddRange(new ToolStripItem[] { saveMenuItem, exitMenuItem });
            resources.ApplyResources(file, "file");
            file.ForeColor = SystemColors.InactiveCaptionText;
            file.Name = "file";
            // 
            // saveMenuItem
            // 
            saveMenuItem.Name = "saveMenuItem";
            resources.ApplyResources(saveMenuItem, "saveMenuItem");
            saveMenuItem.Click += SaveMenuItem_Click;
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            resources.ApplyResources(exitMenuItem, "exitMenuItem");
            exitMenuItem.Click += closeMenuItem_Click;
            // 
            // Tree
            // 
            Tree.DropDownItems.AddRange(new ToolStripItem[] { newTree, createPicture, uploudTree, cleanTree });
            resources.ApplyResources(Tree, "Tree");
            Tree.ForeColor = SystemColors.InactiveCaptionText;
            Tree.Name = "Tree";
            // 
            // newTree
            // 
            newTree.Name = "newTree";
            resources.ApplyResources(newTree, "newTree");
            newTree.Click += newTree_Click;
            // 
            // createPicture
            // 
            createPicture.Name = "createPicture";
            resources.ApplyResources(createPicture, "createPicture");
            createPicture.Click += createPicture_Click;
            // 
            // uploudTree
            // 
            uploudTree.Name = "uploudTree";
            resources.ApplyResources(uploudTree, "uploudTree");
            uploudTree.Click += uploadTree_Click;
            // 
            // cleanTree
            // 
            cleanTree.Name = "cleanTree";
            resources.ApplyResources(cleanTree, "cleanTree");
            cleanTree.Click += cleanTree_Click;
            // 
            // Create
            // 
            resources.ApplyResources(Create, "Create");
            Create.BackColor = Color.DarkSeaGreen;
            Create.ForeColor = SystemColors.InactiveCaptionText;
            Create.Name = "Create";
            Create.UseVisualStyleBackColor = false;
            Create.Click += editNode_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.DarkGreen;
            label1.Name = "label1";
            // 
            // deleteNode
            // 
            resources.ApplyResources(deleteNode, "deleteNode");
            deleteNode.BackColor = Color.DarkSeaGreen;
            deleteNode.ForeColor = SystemColors.InactiveCaptionText;
            deleteNode.Name = "deleteNode";
            deleteNode.UseVisualStyleBackColor = false;
            deleteNode.Click += deleteNode_Click;
            // 
            // add
            // 
            resources.ApplyResources(add, "add");
            add.BackColor = Color.DarkSeaGreen;
            add.ForeColor = SystemColors.InactiveCaptionText;
            add.Name = "add";
            add.UseVisualStyleBackColor = false;
            add.Click += addNode_Click;
            // 
            // search
            // 
            resources.ApplyResources(search, "search");
            search.BackColor = Color.DarkSeaGreen;
            search.ForeColor = SystemColors.InactiveCaptionText;
            search.Name = "search";
            search.UseVisualStyleBackColor = false;
            search.Click += search_Click;
            // 
            // treeView
            // 
            resources.ApplyResources(treeView, "treeView");
            treeView.BackColor = Color.Honeydew;
            treeView.BorderStyle = BorderStyle.None;
            treeView.Cursor = Cursors.Hand;
            treeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treeView.ForeColor = Color.DarkGreen;
            treeView.FullRowSelect = true;
            treeView.HideSelection = false;
            treeView.ItemHeight = 30;
            treeView.LineColor = Color.DarkGreen;
            treeView.Name = "treeView";
            treeView.PathSeparator = "";
            treeView.DrawNode += treeView_DrawNode;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // pictureBox
            // 
            resources.ApplyResources(pictureBox, "pictureBox");
            pictureBox.Name = "pictureBox";
            pictureBox.TabStop = false;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            resources.ApplyResources(pictureBox3, "pictureBox3");
            pictureBox3.Name = "pictureBox3";
            pictureBox3.TabStop = false;
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.BackColor = Color.DarkSeaGreen;
            button1.ForeColor = SystemColors.InactiveCaptionText;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += openNewForm_Click;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Honeydew;
            resources.ApplyResources(this, "$this");
            Controls.Add(button1);
            Controls.Add(pictureBox);
            Controls.Add(pictureBox1);
            Controls.Add(add);
            Controls.Add(treeView);
            Controls.Add(deleteNode);
            Controls.Add(Create);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Controls.Add(search);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox3);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            TransparencyKey = Color.Transparent;
            FormClosed += Form1_FormClosed;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem file;
        private ToolStripMenuItem saveMenuItem;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem Tree;
        private Button Create;
        private Label label1;
        private Button deleteNode;
        private Button add;
        private Button search;
        private TreeView treeView;
        private PictureBox pictureBox1;
        private PictureBox pictureBox;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button button1;
        private ToolStripMenuItem createPicture;
        private ToolStripMenuItem uploudTree;
        private ToolStripMenuItem cleanTree;
        private ToolStripMenuItem newTree;
    }
}