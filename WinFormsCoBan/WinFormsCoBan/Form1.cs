using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
namespace WinFormsCoBan
{
    public partial class Form1 : Form
    {
        private int changeIntoCheckBoxColumnOneTimeFlag = 0;

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

        public void loaddata()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand("SELECT ROW_NUMBER() OVER (ORDER BY UserID) AS [STT], UserID AS [Mã nhân viên], UserName AS [Tên nhân viên], Email, Tel AS [Số điện thoại], Disabled AS [Không hiển thị] FROM Users", con);


                SqlDataAdapter sda = new SqlDataAdapter(cmd);


                DataTable dt = new DataTable();

                // Add CheckBox column to DataGridView
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                checkBoxColumn.HeaderText = "Không hiển thị";
                checkBoxColumn.Name = "Disabled";
                checkBoxColumn.DataPropertyName = "Không hiển thị";
                checkBoxColumn.FalseValue = 0;
                checkBoxColumn.TrueValue = 1;

                try
                {
                    // Fill the DataTable   using SqlDataAdapter
                    sda.Fill(dt);

                    // Set the DataSource of userGridView to the filled DataTable
                    dataGridView2.DataSource = dt;

                    if (changeIntoCheckBoxColumnOneTimeFlag == 0)
                    {
                        // Replace existing column in DataGridView
                        dataGridView2.Columns.Remove("Không hiển thị"); // Remove existing column if necessary
                        dataGridView2.Columns.Add(checkBoxColumn); // Add new CheckBox column
                        changeIntoCheckBoxColumnOneTimeFlag++;
                    }

                }
                finally
                {
                    // Dispose of the DataTable, SqlDataAdapter, and SqlCommand
                    dt.Dispose();
                    sda.Dispose();
                    cmd.Dispose();
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
            TaoUser taoUser = new TaoUser(this);
            taoUser.ShowDialog();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0) // Check if any row is selected
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0]; // Get the first selected row

                string UserID = selectedRow.Cells["Mã nhân viên"].Value.ToString();
                // Get the checkbox value

                UpdateUser updateUser = new UpdateUser(this);
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
