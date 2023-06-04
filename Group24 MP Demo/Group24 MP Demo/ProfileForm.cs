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
    public partial class ProfileForm : Form
    {
        Form parent = null;
        public ProfileForm(Form form)
        {
            InitializeComponent();

            parent = form;
        }

        private void ProfileFrom_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 100);
            loyaltyPtsLbl.Text = value.ToString();
            progressBar1.Value = value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateWindow.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateWindow.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                emailTB.Enabled = true;
            }else
            {
                emailTB.Clear();
                emailTB.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                passwordTB.Enabled = true;
                cPasswordTB.Enabled = true;
            }
            else
            {
                passwordTB.Clear();
                passwordTB.Enabled = false;
                cPasswordTB.Clear();
                cPasswordTB.Enabled = false;
            }
        }
    }
}
