using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group24_MP_Demo
{
    public partial class Payment_Form : Form
    {
        string CustomerID;
        int EmployeeID;
        int VehicleID;
        int payment_type;
        public Payment_Form(string CustID , int empId, int carId)
        {
            InitializeComponent();
            this.CustomerID = CustID;
            this.EmployeeID = empId;
            this.VehicleID = carId;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                payment_type = 1;

                checkBox1.Checked = false;

                groupBox1.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                payment_type = 2;
                checkBox2.Checked = false;

                groupBox1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Invoice_Form form = new Invoice_Form(CustomerID, EmployeeID, VehicleID, payment_type, true);
            this.Dispose();
            form.Show();
        }
    }
}
