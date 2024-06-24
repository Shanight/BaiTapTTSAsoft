namespace WinFormsCoBan
{
    partial class UpdateUser
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
            button2 = new Button();
            button1 = new Button();
            disabled = new CheckBox();
            phonenumber = new TextBox();
            email = new TextBox();
            password1 = new TextBox();
            password = new TextBox();
            username = new TextBox();
            iduser = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(171, 292);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 30;
            button2.Text = "Lưu";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(271, 292);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 29;
            button1.Text = "Đóng";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // disabled
            // 
            disabled.AutoSize = true;
            disabled.Location = new Point(159, 248);
            disabled.Name = "disabled";
            disabled.Size = new Size(127, 24);
            disabled.TabIndex = 28;
            disabled.Text = "Không hiển thị";
            disabled.UseVisualStyleBackColor = true;
            // 
            // phonenumber
            // 
            phonenumber.Location = new Point(159, 205);
            phonenumber.Name = "phonenumber";
            phonenumber.Size = new Size(206, 27);
            phonenumber.TabIndex = 27;
            // 
            // email
            // 
            email.Location = new Point(159, 168);
            email.Name = "email";
            email.Size = new Size(206, 27);
            email.TabIndex = 26;
            // 
            // password1
            // 
            password1.Location = new Point(159, 129);
            password1.Name = "password1";
            password1.Size = new Size(206, 27);
            password1.TabIndex = 25;
            password1.UseSystemPasswordChar = true;
            // 
            // password
            // 
            password.Location = new Point(159, 92);
            password.Name = "password";
            password.Size = new Size(206, 27);
            password.TabIndex = 24;
            password.UseSystemPasswordChar = true;
            // 
            // username
            // 
            username.Location = new Point(159, 58);
            username.Name = "username";
            username.Size = new Size(206, 27);
            username.TabIndex = 23;
            // 
            // iduser
            // 
            iduser.Location = new Point(159, 21);
            iduser.Name = "iduser";
            iduser.ReadOnly = true;
            iduser.Size = new Size(206, 27);
            iduser.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 208);
            label5.Name = "label5";
            label5.Size = new Size(97, 20);
            label5.TabIndex = 21;
            label5.Text = "Số điện thoại";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 171);
            label6.Name = "label6";
            label6.Size = new Size(46, 20);
            label6.TabIndex = 20;
            label6.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 132);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 19;
            label3.Text = "Nhập lại mật khẩu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 95);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 18;
            label4.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 61);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 17;
            label2.Text = "Tên nhân viên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 24);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 16;
            label1.Text = "Mã nhân viên";
            // 
            // UpdateUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 389);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(disabled);
            Controls.Add(phonenumber);
            Controls.Add(email);
            Controls.Add(password1);
            Controls.Add(password);
            Controls.Add(username);
            Controls.Add(iduser);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UpdateUser";
            Text = "UpdateUser";
            Load += update_load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Button button1;
        private CheckBox disabled;
        private TextBox phonenumber;
        private TextBox email;
        private TextBox password1;
        private TextBox password;
        private TextBox username;
        private TextBox iduser;
        private Label label5;
        private Label label6;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
    }
}