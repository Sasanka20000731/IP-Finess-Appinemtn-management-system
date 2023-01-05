using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpFitness
{
    public partial class Dashboad : Form
    {
        public Dashboad()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Appointment_Click(object sender, EventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.Show();
        }

        private void button_Reports_Click(object sender, EventArgs e)
        {
          Form_Report_Dashboad form_Report_Dashboad = new Form_Report_Dashboad();
            form_Report_Dashboad.Show();
        }

        private void button_Payment_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.Show();
        }

        private void button_Useraccount_Click(object sender, EventArgs e)
        {
            Useraccount useraccount = new Useraccount();
            useraccount.Show();
        }

        private void Dashboad_Load(object sender, EventArgs e)
        {

            if (ClassUL.type == "A")
            {
                button_Appointment.Visible = true;
                button_Payment.Visible = true;
                button_Reports.Visible = true;
                button_Useraccount.Visible = true;

            }
            else if (ClassUL.type == "C")
            {
                button_Appointment.Visible = true;
                button_Payment.Visible = true;
                button_Reports.Visible = false;
                button_Useraccount.Visible = false;

            }
            else if (ClassUL.type == "T")
            {
                button_Appointment.Visible = true;
                button_Payment.Visible = true;
                button_Reports.Visible = true;
                button_Useraccount.Visible = false;

            }




        }
    }
}
