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
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        int EmployeeID;

        public ManagerForm(int empID)
        {
            InitializeComponent();
            this.EmployeeID = empID;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainScreen main = new MainScreen(EmployeeID);
            this.Hide();
            main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            newClassPanel.Visible = true;
            newVehiclePanel.Visible = false;
            groupBox1.Text = "Set New Class";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            newVehiclePanel.Visible = true;
            newClassPanel.Visible = false;
            newVehiclePanel.BringToFront();
            groupBox1.Text = "Add New Vehicle";
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(@"Data Source=146.230.177.46\istn3;Initial Catalog=ist3cy;User ID=ist3cy;Password=k898hn");
            SqlCommand cmd = new SqlCommand(@"SELECT pickup_date, return_date, total_amount, payment_method, payment_status, booking_status FROM VehicleBooking", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            EmpRegForm form = new EmpRegForm();
            this.Dispose();
            form.Show();
        }
    }
}
