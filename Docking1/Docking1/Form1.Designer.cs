namespace Docking1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            C1.Win.C1Win7Pack.C1ThumbButton c1ThumbButton1 = new C1.Win.C1Win7Pack.C1ThumbButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.c1FlexGridSearchPanel1 = new C1.Win.C1FlexGrid.C1FlexGridSearchPanel();
            this.c1ContextMenu1 = new C1.Win.C1Command.C1ContextMenu();
            this.c1CommandLink2 = new C1.Win.C1Command.C1CommandLink();
            this.c1Command2 = new C1.Win.C1Command.C1Command();
            this.c1CommandLink1 = new C1.Win.C1Command.C1CommandLink();
            this.c1Command3 = new C1.Win.C1Command.C1Command();
            this.c1CommandLink3 = new C1.Win.C1Command.C1CommandLink();
            this.c1Command4 = new C1.Win.C1Command.C1Command();
            this.c1CommandLink4 = new C1.Win.C1Command.C1CommandLink();
            this.c1Command5 = new C1.Win.C1Command.C1Command();
            this.c1CommandHolder1 = new C1.Win.C1Command.C1CommandHolder();
            this.c1Command1 = new C1.Win.C1Command.C1Command();
            this.c1TaskbarButton1 = new C1.Win.C1Win7Pack.C1TaskbarButton(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.c1FlexGrid1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.c1FlexGridSearchPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 471);
            this.panel1.TabIndex = 2;
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.c1FlexGrid1.AllowEditing = false;
            this.c1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(this.c1FlexGrid1, this.c1FlexGridSearchPanel1);
            this.c1FlexGrid1.ColumnInfo = "10,1,0,0,0,-1,Columns:";
            this.c1FlexGrid1.ColumnPickerInfo.SearchMode = C1.Win.C1FlexGrid.ColumnPickerSearchMode.Highlight;
            this.c1FlexGrid1.Location = new System.Drawing.Point(1, 52);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.c1FlexGrid1.Size = new System.Drawing.Size(871, 338);
            this.c1FlexGrid1.TabIndex = 5;
            this.c1FlexGrid1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clickfocus);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(643, 403);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 33);
            this.button3.TabIndex = 4;
            this.button3.Text = "Thực hiện";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(755, 403);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 33);
            this.button2.TabIndex = 3;
            this.button2.Text = "Đóng";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Trợ giúp";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // c1FlexGridSearchPanel1
            // 
            this.c1FlexGridSearchPanel1.Location = new System.Drawing.Point(4, 13);
            this.c1FlexGridSearchPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.c1FlexGridSearchPanel1.Name = "c1FlexGridSearchPanel1";
            this.c1FlexGridSearchPanel1.Size = new System.Drawing.Size(869, 31);
            this.c1FlexGridSearchPanel1.TabIndex = 0;
            // 
            // c1ContextMenu1
            // 
            this.c1ContextMenu1.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.c1CommandLink2,
            this.c1CommandLink1,
            this.c1CommandLink3,
            this.c1CommandLink4});
            this.c1ContextMenu1.Name = "c1ContextMenu1";
            this.c1ContextMenu1.ShortcutText = "";
            this.c1ContextMenu1.Virgin = false;
            // 
            // c1CommandLink2
            // 
            this.c1CommandLink2.Command = this.c1Command2;
            // 
            // c1Command2
            // 
            this.c1Command2.Name = "c1Command2";
            this.c1Command2.Pressed = true;
            this.c1Command2.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.c1Command2.ShortcutText = "";
            this.c1Command2.Text = "Thêm";
            this.c1Command2.Virgin = false;
            this.c1Command2.Click += new C1.Win.C1Command.ClickEventHandler(this.c1Command2_Click);
            // 
            // c1CommandLink1
            // 
            this.c1CommandLink1.Command = this.c1Command3;
            this.c1CommandLink1.SortOrder = 1;
            // 
            // c1Command3
            // 
            this.c1Command3.Name = "c1Command3";
            this.c1Command3.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            this.c1Command3.ShortcutText = "";
            this.c1Command3.Text = "Sửa";
            this.c1Command3.Virgin = false;
            this.c1Command3.Click += new C1.Win.C1Command.ClickEventHandler(this.c1Command3_Click);
            // 
            // c1CommandLink3
            // 
            this.c1CommandLink3.Command = this.c1Command4;
            this.c1CommandLink3.SortOrder = 2;
            // 
            // c1Command4
            // 
            this.c1Command4.Name = "c1Command4";
            this.c1Command4.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.c1Command4.ShortcutText = "";
            this.c1Command4.Text = "Xem";
            this.c1Command4.Virgin = false;
            this.c1Command4.Click += new C1.Win.C1Command.ClickEventHandler(this.c1Command4_Click);
            // 
            // c1CommandLink4
            // 
            this.c1CommandLink4.Command = this.c1Command5;
            this.c1CommandLink4.SortOrder = 3;
            // 
            // c1Command5
            // 
            this.c1Command5.Name = "c1Command5";
            this.c1Command5.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            this.c1Command5.ShortcutText = "";
            this.c1Command5.Text = "Xóa";
            this.c1Command5.Virgin = false;
            this.c1Command5.Click += new C1.Win.C1Command.ClickEventHandler(this.c1Command5_Click);
            // 
            // c1CommandHolder1
            // 
            this.c1CommandHolder1.Commands.Add(this.c1ContextMenu1);
            this.c1CommandHolder1.Commands.Add(this.c1Command1);
            this.c1CommandHolder1.Commands.Add(this.c1Command2);
            this.c1CommandHolder1.Commands.Add(this.c1Command3);
            this.c1CommandHolder1.Commands.Add(this.c1Command4);
            this.c1CommandHolder1.Commands.Add(this.c1Command5);
            this.c1CommandHolder1.Owner = this;
            // 
            // c1Command1
            // 
            this.c1Command1.C1ContextMenu = this.c1ContextMenu1;
            this.c1Command1.Name = "c1Command1";
            this.c1Command1.Pressed = true;
            this.c1Command1.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.c1Command1.ShortcutText = "";
            this.c1Command1.Text = "Thêm";
            this.c1Command1.Virgin = false;
            // 
            // c1TaskbarButton1
            // 
            this.c1TaskbarButton1.ContainerForm = this;
            this.c1TaskbarButton1.JumpList.KnownCategory = C1.Win.C1Win7Pack.JumpListKnownCategory.Recent;
            c1ThumbButton1.Name = "Button1";
            this.c1TaskbarButton1.Thumbnail.Buttons.AddRange(new C1.Win.C1Win7Pack.C1ThumbButton[] {
            c1ThumbButton1});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 471);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1FlexGrid.C1FlexGridSearchPanel c1FlexGridSearchPanel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private C1.Win.C1Command.C1ContextMenu c1ContextMenu1;
        private C1.Win.C1Command.C1Command c1Command1;
        private C1.Win.C1Command.C1CommandHolder c1CommandHolder1;
        private C1.Win.C1Command.C1CommandLink c1CommandLink2;
        private C1.Win.C1Command.C1Command c1Command2;
        private C1.Win.C1Command.C1CommandLink c1CommandLink1;
        private C1.Win.C1Command.C1Command c1Command3;
        private C1.Win.C1Command.C1CommandLink c1CommandLink3;
        private C1.Win.C1Command.C1Command c1Command4;
        private C1.Win.C1Command.C1CommandLink c1CommandLink4;
        private C1.Win.C1Command.C1Command c1Command5;
        public C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid1;
        private C1.Win.C1Win7Pack.C1TaskbarButton c1TaskbarButton1;
    }
}

