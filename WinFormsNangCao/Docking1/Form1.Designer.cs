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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdGird1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnTroGiup = new System.Windows.Forms.Button();
            this.c1FlexGridSearchPanel1 = new C1.Win.C1FlexGrid.C1FlexGridSearchPanel();
            this.c1CommandHolder1 = new C1.Win.C1Command.C1CommandHolder();
            this.cmnuMenu1 = new C1.Win.C1Command.C1ContextMenu();
            this.btnCreate = new C1.Win.C1Command.C1CommandLink();
            this.treCreate = new C1.Win.C1Command.C1Command();
            this.btnEdit = new C1.Win.C1Command.C1CommandLink();
            this.treEdit = new C1.Win.C1Command.C1Command();
            this.btnView = new C1.Win.C1Command.C1CommandLink();
            this.treView = new C1.Win.C1Command.C1Command();
            this.btnDelete = new C1.Win.C1Command.C1CommandLink();
            this.treDelete = new C1.Win.C1Command.C1Command();
            this.c1Command1 = new C1.Win.C1Command.C1Command();
            this.c1Command2 = new C1.Win.C1Command.C1Command();
            this.c1Command3 = new C1.Win.C1Command.C1Command();
            this.c1Command4 = new C1.Win.C1Command.C1Command();
            this.c1Command5 = new C1.Win.C1Command.C1Command();
            this.c1Command7 = new C1.Win.C1Command.C1Command();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGird1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdGird1);
            this.panel1.Controls.Add(this.btnThucHien);
            this.panel1.Controls.Add(this.btnDong);
            this.panel1.Controls.Add(this.btnTroGiup);
            this.panel1.Controls.Add(this.c1FlexGridSearchPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 471);
            this.panel1.TabIndex = 2;
            // 
            // grdGird1
            // 
            this.grdGird1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.grdGird1.AllowEditing = false;
            this.c1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(this.grdGird1, this.c1FlexGridSearchPanel1);
            this.grdGird1.ColumnInfo = "10,1,0,0,0,-1,Columns:";
            this.grdGird1.ColumnPickerInfo.SearchMode = C1.Win.C1FlexGrid.ColumnPickerSearchMode.Highlight;
            this.grdGird1.Location = new System.Drawing.Point(1, 52);
            this.grdGird1.Name = "grdGird1";
            this.grdGird1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.grdGird1.Size = new System.Drawing.Size(871, 338);
            this.grdGird1.TabIndex = 5;
            this.grdGird1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clickfocus);
            // 
            // btnThucHien
            // 
            this.btnThucHien.Location = new System.Drawing.Point(643, 403);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(106, 33);
            this.btnThucHien.TabIndex = 4;
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.UseVisualStyleBackColor = true;
            this.btnThucHien.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(755, 403);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(106, 33);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTroGiup
            // 
            this.btnTroGiup.Location = new System.Drawing.Point(12, 403);
            this.btnTroGiup.Name = "btnTroGiup";
            this.btnTroGiup.Size = new System.Drawing.Size(106, 33);
            this.btnTroGiup.TabIndex = 2;
            this.btnTroGiup.Text = "Trợ giúp";
            this.btnTroGiup.UseVisualStyleBackColor = true;
            // 
            // c1FlexGridSearchPanel1
            // 
            this.c1FlexGridSearchPanel1.Location = new System.Drawing.Point(4, 13);
            this.c1FlexGridSearchPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.c1FlexGridSearchPanel1.Name = "c1FlexGridSearchPanel1";
            this.c1FlexGridSearchPanel1.Size = new System.Drawing.Size(869, 31);
            this.c1FlexGridSearchPanel1.TabIndex = 0;
            // 
            // c1CommandHolder1
            // 
            this.c1CommandHolder1.Commands.Add(this.cmnuMenu1);
            this.c1CommandHolder1.Commands.Add(this.c1Command1);
            this.c1CommandHolder1.Commands.Add(this.c1Command2);
            this.c1CommandHolder1.Commands.Add(this.c1Command3);
            this.c1CommandHolder1.Commands.Add(this.c1Command4);
            this.c1CommandHolder1.Commands.Add(this.c1Command5);
            this.c1CommandHolder1.Commands.Add(this.treDelete);
            this.c1CommandHolder1.Commands.Add(this.c1Command7);
            this.c1CommandHolder1.Commands.Add(this.treEdit);
            this.c1CommandHolder1.Commands.Add(this.treView);
            this.c1CommandHolder1.Commands.Add(this.treCreate);
            this.c1CommandHolder1.Owner = this;
            // 
            // cmnuMenu1
            // 
            this.cmnuMenu1.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.btnCreate,
            this.btnEdit,
            this.btnView,
            this.btnDelete});
            this.cmnuMenu1.Name = "cmnuMenu1";
            this.cmnuMenu1.ShortcutText = "";
            this.cmnuMenu1.Virgin = false;
            // 
            // btnCreate
            // 
            this.btnCreate.Command = this.treCreate;
            // 
            // treCreate
            // 
            this.treCreate.Image = ((System.Drawing.Image)(resources.GetObject("treCreate.Image")));
            this.treCreate.Name = "treCreate";
            this.treCreate.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.treCreate.ShortcutText = "";
            this.treCreate.Text = "Thêm";
            this.treCreate.Virgin = false;
            this.treCreate.Click += new C1.Win.C1Command.ClickEventHandler(this.c1Command10_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Command = this.treEdit;
            this.btnEdit.SortOrder = 1;
            // 
            // treEdit
            // 
            this.treEdit.Image = ((System.Drawing.Image)(resources.GetObject("treEdit.Image")));
            this.treEdit.Name = "treEdit";
            this.treEdit.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            this.treEdit.ShortcutText = "";
            this.treEdit.Text = "Sửa";
            this.treEdit.Virgin = false;
            this.treEdit.Click += new C1.Win.C1Command.ClickEventHandler(this.c1Command8_Click);
            // 
            // btnView
            // 
            this.btnView.Command = this.treView;
            this.btnView.SortOrder = 2;
            this.btnView.Text = "Xem";
            // 
            // treView
            // 
            this.treView.Image = ((System.Drawing.Image)(resources.GetObject("treView.Image")));
            this.treView.Name = "treView";
            this.treView.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.treView.ShortcutText = "";
            this.treView.Text = "Thêm";
            this.treView.Virgin = false;
            this.treView.Click += new C1.Win.C1Command.ClickEventHandler(this.treView_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Command = this.treDelete;
            this.btnDelete.SortOrder = 3;
            // 
            // treDelete
            // 
            this.treDelete.Image = ((System.Drawing.Image)(resources.GetObject("treDelete.Image")));
            this.treDelete.Name = "treDelete";
            this.treDelete.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            this.treDelete.ShortcutText = "";
            this.treDelete.Text = "&Delete";
            this.treDelete.Virgin = false;
            this.treDelete.Click += new C1.Win.C1Command.ClickEventHandler(this.c1Command6_Click);
            // 
            // c1Command1
            // 
            this.c1Command1.C1ContextMenu = this.cmnuMenu1;
            this.c1Command1.Name = "c1Command1";
            this.c1Command1.Pressed = true;
            this.c1Command1.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.c1Command1.ShortcutText = "";
            this.c1Command1.Text = "Thêm";
            this.c1Command1.Virgin = false;
            // 
            // c1Command2
            // 
            this.c1Command2.Name = "c1Command2";
            this.c1Command2.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.c1Command2.ShortcutText = "";
            this.c1Command2.Text = "Thêm";
            this.c1Command2.Virgin = false;
            // 
            // c1Command3
            // 
            this.c1Command3.Name = "c1Command3";
            this.c1Command3.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            this.c1Command3.ShortcutText = "";
            this.c1Command3.Text = "Sửa";
            this.c1Command3.Virgin = false;
            // 
            // c1Command4
            // 
            this.c1Command4.Name = "c1Command4";
            this.c1Command4.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.c1Command4.ShortcutText = "";
            this.c1Command4.Text = "Xem";
            this.c1Command4.Virgin = false;
            // 
            // c1Command5
            // 
            this.c1Command5.Name = "c1Command5";
            this.c1Command5.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            this.c1Command5.ShortcutText = "";
            this.c1Command5.Text = "Xóa";
            this.c1Command5.Virgin = false;
            // 
            // c1Command7
            // 
            this.c1Command7.Image = ((System.Drawing.Image)(resources.GetObject("c1Command7.Image")));
            this.c1Command7.Name = "c1Command7";
            this.c1Command7.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.c1Command7.ShortcutText = "";
            this.c1Command7.Text = "Go to...";
            this.c1Command7.Virgin = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 471);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGird1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1FlexGrid.C1FlexGridSearchPanel c1FlexGridSearchPanel1;
        private System.Windows.Forms.Button btnThucHien;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnTroGiup;
        public C1.Win.C1FlexGrid.C1FlexGrid grdGird1;
        private C1.Win.C1Command.C1CommandHolder c1CommandHolder1;
        private C1.Win.C1Command.C1ContextMenu cmnuMenu1;
        private C1.Win.C1Command.C1CommandLink btnCreate;
        private C1.Win.C1Command.C1CommandLink btnEdit;
        private C1.Win.C1Command.C1Command treEdit;
        private C1.Win.C1Command.C1CommandLink btnView;
        private C1.Win.C1Command.C1Command c1Command7;
        private C1.Win.C1Command.C1CommandLink btnDelete;
        private C1.Win.C1Command.C1Command treDelete;
        private C1.Win.C1Command.C1Command c1Command1;
        private C1.Win.C1Command.C1Command c1Command2;
        private C1.Win.C1Command.C1Command c1Command3;
        private C1.Win.C1Command.C1Command c1Command4;
        private C1.Win.C1Command.C1Command c1Command5;
        private C1.Win.C1Command.C1Command treView;
        public C1.Win.C1Command.C1Command treCreate;
    }
}

