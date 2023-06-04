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
using Microsoft.VisualBasic;

namespace Group24_MP_Demo
{
    public partial class MainScreen : Form
    {
        int EmployeeID;
        public MainScreen()
        {
            InitializeComponent();

        }

        public MainScreen(int EmployeeId)
        {
            InitializeComponent();
            this.EmployeeID = EmployeeId;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int classValue = comboBox1.SelectedIndex;
            if (classValue == 0)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=146.230.177.46\istn3;Initial Catalog=ist3cy;User ID=ist3cy;Password=k898hn");
                SqlCommand cmd = new SqlCommand(@"Select * from VehicleTable", conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=146.230.177.46\istn3;Initial Catalog=ist3cy;User ID=ist3cy;Password=k898hn");
                    SqlCommand cmd = new SqlCommand(@"Select * from VehicleTable where ClassID = '" + classValue + "'", conn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }

            groupBox1.Text = comboBox1.GetItemText(comboBox1.SelectedItem);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;

                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=146.230.177.46\istn3;Initial Catalog=ist3cy;User ID=ist3cy;Password=k898hn");
                    SqlCommand cmd = new SqlCommand(@"Select * from VehicleTable where transmission_type = 'Manual'", conn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                    groupBox1.Text = "Manual";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;

                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=146.230.177.46\istn3;Initial Catalog=ist3cy;User ID=ist3cy;Password=k898hn");
                    SqlCommand cmd = new SqlCommand(@"Select * from VehicleTable where transmission_type = 'Automatic'", conn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                    groupBox1.Text = "Automatic";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void search_focus(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search Car")
            {
                textBox1.Text = "";
            }            
        }

        private void text_changed(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Search Car";
            }
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ist3cyDataSet.VehicleTable' table. You can move, or remove it, as needed.
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=146.230.177.46\istn3;Initial Catalog=ist3cy;User ID=ist3cy;Password=k898hn");
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM VehicleTable where VehicleID NOT IN (Select VehicleID from VehicleBooking AS ActiveBookings where booking_status = 'Active')", conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                dataGridView1.DataSource = dt;

                groupBox1.Text = comboBox1.GetItemText(comboBox1.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("M::" + ex);
            }
            
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker2.Value = dateTimePicker1.Value;
            dateTimePicker2.Value = dateTimePicker2.Value.AddDays(21);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            if (dateTimePicker2.Value.Subtract(dateTimePicker1.Value).TotalDays > 21)
            {
                MessageBox.Show("Please select date no longer than 21 days from pick up date.", "Date Input Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(21);
            }else if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(21);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.AddDays(21).Subtract(dateTimePicker2.Value).TotalDays < 0)
            {
                MessageBox.Show("As we do not posses a Time machine, please refrain from going back in time. THANK YOU!", "Date Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker1.Value = dateTimePicker1.Value.AddDays(Math.Abs(dateTimePicker1.Value.AddDays(21).Subtract(dateTimePicker2.Value).TotalDays));
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=146.230.177.46\istn3;Initial Catalog=ist3cy;User ID=ist3cy;Password=k898hn");
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM VehicleTable where VehicleID NOT IN (Select VehicleID from VehicleBooking where CURRENT_TIMESTAMP BETWEEN pickup_date and return_date)", conn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    dataGridView1.DataSource = dt;

                    groupBox1.Text = comboBox1.GetItemText(comboBox1.SelectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("D::" + ex);
                }
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(21);
            }

            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm screen = new LoginForm(this);

            this.Hide();
            screen.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* if (!isLogedin)
            {
                LoginForm screen = new LoginForm(this);

                this.Hide();
                screen.Show();
            }
            else
            {*/
                ProfileForm profileScreen = new ProfileForm(this);

                this.Hide();
                profileScreen.Show();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            dateTimePicker1.Value = System.DateTime.Today;
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(21);
            */
            LoginForm det = new LoginForm(this);
            this.Hide();
            det.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string output = "Confirm booking for : \n";

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                output += ("\tMake \t\t: " + row.Cells["make"].Value.ToString() + "\n");
                output += ("\tModel\t\t: " + row.Cells["model"].Value.ToString() + "\n");
                output += ("\tTransmission\t: " + row.Cells["transmission_type"].Value.ToString() + "\n");
                output += ("\tYear \t\t: " + row.Cells["year_of_model"].Value.ToString() + "\n");
                output += ("\tColor\t\t: " + row.Cells["color"].Value.ToString() + "\n");

                DialogResult choice = MessageBox.Show(output, "Confirm Booking", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (choice == DialogResult.Yes)
                {
                    string id = Interaction.InputBox("Enter customer ID number:", "ID number");
                    try
                    {
                        SqlConnection conn = new SqlConnection(@"Data Source=146.230.177.46\istn3;Initial Catalog=ist3cy;User ID=ist3cy;Password=k898hn");
                        SqlCommand cmd = new SqlCommand(@"SELECT * FROM CustomerTable where SA_ID_number ='" + id + "'", conn);
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            int int_id = 0;
                            if (int.TryParse(row.Cells["VehicleID"].Value.ToString(),out int_id))
                            {
                                int_id = int.Parse(row.Cells["VehicleID"].Value.ToString());
                                Payment_Form payment = new Payment_Form(id, this.EmployeeID, int_id);
                                payment.Show();
                                this.Dispose();
                            }
                            
                            
                        }else
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("D::" + ex);
                    }
                }
            }
        }
        /*
private void fillByTransmission1ToolStripButton_Click(object sender, EventArgs e)
{
try
{
//this.vehicleTableTableAdapter.FillByTransmission1(this.ist3cyDataSet.VehicleTable);
}
catch (System.Exception ex)
{
System.Windows.Forms.MessageBox.Show(ex.Message);
}

}

private void fillByTransmission2ToolStripButton_Click(object sender, EventArgs e)
{
try
{
this.vehicleTableTableAdapter.FillByTransmission2(this.ist3cyDataSet.VehicleTable);
}
catch (System.Exception ex)
{
System.Windows.Forms.MessageBox.Show(ex.Message);
}

}

private void fillByTransmission_trans_ToolStripButton_Click(object sender, EventArgs e)
{
try
{
this.vehicleTableTableAdapter.FillByTransmission_trans_(this.ist3cyDataSet.VehicleTable);
}
catch (System.Exception ex)
{
System.Windows.Forms.MessageBox.Show(ex.Message);
}

}
*/
    }
}
