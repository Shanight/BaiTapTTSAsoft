using System.Data;
using System.Data.SqlClient;
namespace WinFormsCoBan
{
    public partial class Form1 : Form
    {
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
            string constring = @"Data Source=.\SQLEXPRESS;Initial Catalog=test1asoft;User id=sa;password=123456";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("select ROW_NUMBER() OVER (ORDER BY UserID) AS [STT], UserID as \"Mã nhân viên\", UserName as \"Tên nhân viên\", Email, Tel as \"Số điện thoại\", Disabled from Users", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            // Change the "Không hiển thị" column to a checkbox column
                            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn
                            {
                                DataPropertyName = "Disabled",
                                HeaderText = "Không hiển thị",
                                Name = "DisabledColumn",
                                TrueValue = "1",
                                FalseValue = "0"
                            };

                            // Add the checkbox column to the DataGridView
                            dataGridView2.Columns.Add(checkboxColumn);


                            // Set the DataSource of the DataGridView
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

        }
    }
}
