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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        Form parent = null;
        public LoginForm(Form form)
        {
            InitializeComponent();

            parent = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen main = new MainScreen();
            main.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=146.230.177.46\istn3;Initial Catalog=ist3cy;User ID=ist3cy;Password=k898hn");
                SqlCommand cmd = new SqlCommand("Select * From LoginTable2 where EmployeeID=@uname and password=@upass", conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                cmd.Parameters.AddWithValue("@uname", empIdTb.Text);
                cmd.Parameters.AddWithValue("@upass", passwordTb.Text) ;
                SqlDataReader rd = cmd.ExecuteReader() ;

                if (rd.HasRows)

                {
                    rd.Close();
                    conn.Close();
                    cmd = new SqlCommand("Select * From EmployeeTable where EmployeeID=@uname", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@uname", empIdTb.Text);
                    rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        if (rd[5].ToString() == "Manager")
                        {
                            ManagerForm man = new ManagerForm(int.Parse(empIdTb.Text));
                            man.Show();
                            this.Hide();
                        }
                        else if (rd[5].ToString() == "Employee")
                        {
                            MainScreen main = new MainScreen(int.Parse(empIdTb.Text));
                            main.Show();
                            this.Hide();
                        }
                    }

                }
                else
                {
                    MessageBox.Show(null, "EmployeeID/Passord is incorrect. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            empIdTb.Focus();
        }
    }

}
