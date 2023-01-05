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
    public partial class Form_Report_Dashboad : Form
    {
        public Form_Report_Dashboad()
        {
            InitializeComponent();
        }

        private void button_Most_Demmanding_Trainner_Click(object sender, EventArgs e)
        {
            Form_MostDemmanding form_MostDemmanding = new Form_MostDemmanding();
            form_MostDemmanding.Show();
        }

        private void button_Least_Demmanding_Trainner_Click(object sender, EventArgs e)
        {
            Form_Least_Demmanding_Trainners form_Least_Demmanding_Trainners = new Form_Least_Demmanding_Trainners();
           form_Least_Demmanding_Trainners.Show();
        }

        private void button_View_Income_Click(object sender, EventArgs e)
        {
            Form_Income form_Income = new Form_Income();
            form_Income.Show();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
