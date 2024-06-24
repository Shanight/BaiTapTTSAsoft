﻿using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
namespace WinFormsCoBan
{
    public partial class Form1 : Form
    {
        string constring = @"Data Source=.\SQLEXPRESS;Initial Catalog=test1asoft;User id=sa;password=123456";

        public Form1()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.loaddata();
        }

        private void loaddata()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("select ROW_NUMBER() OVER (ORDER BY UserID) AS [STT], UserID as \"Mã nhân viên\", UserName as \"Tên nhân viên\", Email, Tel as \"Số điện thoại\", Disabled from Users", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn
                            {
                                DataPropertyName = "Disabled",
                                HeaderText = "Không hiển thị",
                                Name = "DisabledColumn",
                                TrueValue = "1",
                                FalseValue = "0"
                            };
                            if (!dataGridView2.Columns.Contains("DisabledColumn")) // Check if the column already exists
                            {
                                dataGridView2.Columns.Add(checkboxColumn);
                                
                            }
                            dataGridView2.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button2, new Point(0, button2.Height));
        }

        private void Create_Click(object sender, EventArgs e)
        {
            TaoUser taoUser = new TaoUser();
            taoUser.ShowDialog();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0) // Check if any row is selected
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0]; // Get the first selected row

                string UserID = selectedRow.Cells["Mã nhân viên"].Value.ToString();
                // Get the checkbox value

                UpdateUser updateUser = new UpdateUser();
                updateUser.UserID = UserID;


                // Pass the data to the UpdateUser form
                updateUser.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0) // Check if any row is selected
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0]; // Get the first selected row

                string UserID = selectedRow.Cells["Mã nhân viên"].Value.ToString();
                // Get the checkbox value
                Form1 mainForm = new Form1();
                Delete delete = new Delete(mainForm);
                delete.UserID = UserID;
                // Pass the data to the UpdateUser form
                delete.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!");
            }
        }

        private void Read_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0) // Check if any row is selected
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0]; // Get the first selected row

                string UserID = selectedRow.Cells["Mã nhân viên"].Value.ToString();
                // Get the checkbox value

                Xem xem = new Xem();
                xem.UserID = UserID;


                // Pass the data to the UpdateUser form
                xem.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void click(object sender, MouseEventArgs e)
        {
        }


        private void clickfocus(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
