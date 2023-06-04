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
    public partial class Invoice_Form : Form
    {
        public Invoice_Form()
        {
            InitializeComponent();
        }

        
        int EmployeeID;
        int VehicleID;
        string CustID;
        int payment_type;
        bool paid;

        public Invoice_Form(string custId, int empId,int vehicleId,int payment_type, bool paymentMade)
        {
            InitializeComponent();
            this.EmployeeID = empId;
            this.CustID = custId;
            this.VehicleID = vehicleId;
            this.payment_type = payment_type;
            this.paid = paymentMade;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            LoginForm form = new LoginForm();
            form.Show();
        }
    }
}
