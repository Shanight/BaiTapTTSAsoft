namespace WinFormsCoBan
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
            components = new System.ComponentModel.Container();
            bindingSource1 = new BindingSource(components);
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            dataGridView2 = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            Create = new ToolStripMenuItem();
            Edit = new ToolStripMenuItem();
            Read = new ToolStripMenuItem();
            Delete = new ToolStripMenuItem();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // bindingSource1
            // 
            bindingSource1.CurrentChanged += bindingSource1_CurrentChanged;
            // 
            // button1
            // 
            button1.Location = new Point(12, 412);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "Trợ giúp";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(575, 412);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "Thực hiện";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(694, 412);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 3;
            button3.Text = "Đóng";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 12);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 29;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(776, 371);
            dataGridView2.TabIndex = 4;
            dataGridView2.CellMouseClick += clickfocus;
            dataGridView2.MouseClick += click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { Create, Edit, Read, Delete });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(169, 100);
            contextMenuStrip1.TabStop = true;
            // 
            // Create
            // 
            Create.Name = "Create";
            Create.ShortcutKeyDisplayString = "";
            Create.ShortcutKeys = Keys.Control | Keys.N;
            Create.Size = new Size(168, 24);
            Create.Text = "Thêm";
            Create.Click += Create_Click;
            // 
            // Edit
            // 
            Edit.Name = "Edit";
            Edit.ShortcutKeys = Keys.Control | Keys.E;
            Edit.Size = new Size(168, 24);
            Edit.Text = "Sửa";
            Edit.Click += Edit_Click;
            // 
            // Read
            // 
            Read.Name = "Read";
            Read.ShortcutKeys = Keys.Control | Keys.V;
            Read.Size = new Size(168, 24);
            Read.Text = "Xem";
            Read.Click += Read_Click;
            // 
            // Delete
            // 
            Delete.Name = "Delete";
            Delete.ShortcutKeys = Keys.Control | Keys.D;
            Delete.Size = new Size(168, 24);
            Delete.Text = "Xóa";
            Delete.Click += Delete_Click;
            // 
            // button4
            // 
            button4.Location = new Point(462, 412);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 5;
            button4.Text = "Load lại";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(dataGridView2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private BindingSource bindingSource1;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem test1ToolStripMenuItem;
        public ToolStripMenuItem Create;
        public ToolStripMenuItem Read;
        public ToolStripMenuItem Delete;
        public ToolStripMenuItem Edit;
        private Button button4;
    }
}
