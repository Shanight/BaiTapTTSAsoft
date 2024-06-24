namespace WinFormsCoBan
{
    partial class TaoUser
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            iduser = new TextBox();
            username = new TextBox();
            password = new TextBox();
            password1 = new TextBox();
            email = new TextBox();
            phonenumber = new TextBox();
            disabled = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã nhân viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 69);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên nhân viên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 140);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 3;
            label3.Text = "Nhập lại mật khẩu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 103);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 2;
            label4.Text = "Mật khẩu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 216);
            label5.Name = "label5";
            label5.Size = new Size(97, 20);
            label5.TabIndex = 5;
            label5.Text = "Số điện thoại";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 179);
            label6.Name = "label6";
            label6.Size = new Size(46, 20);
            label6.TabIndex = 4;
            label6.Text = "Email";
            // 
            // iduser
            // 
            iduser.Location = new Point(151, 29);
            iduser.Name = "iduser";
            iduser.Size = new Size(206, 27);
            iduser.TabIndex = 6;
            // 
            // username
            // 
            username.Location = new Point(151, 66);
            username.Name = "username";
            username.Size = new Size(206, 27);
            username.TabIndex = 7;
            // 
            // password
            // 
            password.Location = new Point(151, 100);
            password.Name = "password";
            password.Size = new Size(206, 27);
            password.TabIndex = 8;
            password.UseSystemPasswordChar = true;
            // 
            // password1
            // 
            password1.Location = new Point(151, 137);
            password1.Name = "password1";
            password1.Size = new Size(206, 27);
            password1.TabIndex = 9;
            // 
            // email
            // 
            email.Location = new Point(151, 176);
            email.Name = "email";
            email.Size = new Size(206, 27);
            email.TabIndex = 10;
            // 
            // phonenumber
            // 
            phonenumber.Location = new Point(151, 213);
            phonenumber.Name = "phonenumber";
            phonenumber.Size = new Size(206, 27);
            phonenumber.TabIndex = 11;
            // 
            // disabled
            // 
            disabled.AutoSize = true;
            disabled.Location = new Point(151, 256);
            disabled.Name = "disabled";
            disabled.Size = new Size(127, 24);
            disabled.TabIndex = 12;
            disabled.Text = "Không hiển thị";
            disabled.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(263, 300);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 13;
            button1.Text = "Đóng";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(163, 300);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 14;
            button2.Text = "Lưu";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(63, 300);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 15;
            button3.Text = "Nhập tiếp";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // TaoUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 388);
            Controls.Add(button3);
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
            Name = "TaoUser";
            Text = "TaoUser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox iduser;
        private TextBox username;
        private TextBox password;
        private TextBox password1;
        private TextBox email;
        private TextBox phonenumber;
        private CheckBox disabled;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}