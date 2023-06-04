using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Group24_MP_Demo
{
    public partial class EmpRegForm : Form
    {
        Form home;
        public EmpRegForm()
        {
            InitializeComponent();
        }

        public EmpRegForm(Form home)
        {
            InitializeComponent();

            this.home = home;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            home.Show();
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=146.230.177.46\istn3;Initial Catalog=ist3cy;User ID=ist3cy;Password=k898hn");
                SqlCommand cmd = new SqlCommand(@"INSERT INTO[dbo].[EmployeeTable]
           ([first_name]
           ,[last_name]
           ,[contact_number]
           ,[SA_ID_number]
           ,[position])
     VALUES
           ('"+firstName.Text+"','"+lastName.Text+"','"+cellNum.Text+"','"+idNum.Text+"','Employee'" , conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Employee registered successfully");
            }catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
