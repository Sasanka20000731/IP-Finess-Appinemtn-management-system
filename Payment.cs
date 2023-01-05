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

namespace IpFitness
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void button_MakeAppointment_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {

            {

                //  try
                //   {


                String dbString = "Data Source=DESKTOP-N1AKUG5;Initial Catalog=ProjectE2046609;Integrated Security=True";
                SqlConnection con = new SqlConnection(dbString);
                con.Open();

                String sqlQary = "insert into Table_MakePayment values('" + textBox_Name.Text + "', '" + textBox_trainnerName.Text + "','" + textBox_Hours.Text + "','" + textBox_PaymentForAppointment.Text + "','" +textBox_AppointmentNo.Text + "' )";
                SqlCommand com = new SqlCommand(sqlQary, con);
                com.ExecuteNonQuery();


                //     }
                //   catch (Exception)
                //    {
                //       MessageBox.Show("Error!!");
                //    }

                MessageBox.Show("Successfull added an payment!!!");

                textBox_Name.Clear();
                textBox_Hours.Clear();
                textBox_trainnerName.Clear();
                textBox_Price_PerHour.Clear();
                textBox_PaymentForAppointment.Clear();


                textBox_Name.Focus();

            }
        }

        private void button_ViewAllPayment_Click(object sender, EventArgs e)
        {
            panel_DeletePAyament.Visible = false;
            pictureBox2.Visible = false;


            String dbString = "Data Source=DESKTOP-N1AKUG5;Initial Catalog=ProjectE2046609;Integrated Security=True";
            SqlConnection con = new SqlConnection(dbString);
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from [dbo].[Table_MakePayment]";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView_AllPayments.DataSource = DS.Tables[0];
        }

        private void textBox_AppointmentNo_TextChanged(object sender, EventArgs e)
        {
            String dbString = "Data Source=DESKTOP-N1AKUG5;Initial Catalog=ProjectE2046609;Integrated Security=True";
            SqlConnection con = new SqlConnection(dbString);
            con.Open();

            if (textBox_AppointmentNo.Text != " ")
            {

                SqlCommand cmd = new SqlCommand("Select Name,TrainerName,Apphours from Appointment where AppointmentNo =@AppointmentNo", con);
                cmd.Parameters.AddWithValue("@AppointmentNo", textBox_AppointmentNo.Text);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    textBox_Name.Text = da.GetValue(0).ToString();
                    textBox_trainnerName.Text = da.GetValue(1).ToString();
                    textBox_Hours.Text = da.GetValue(2).ToString();
                }
                con.Close();

            }
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            String dbString = "Data Source=DESKTOP-N1AKUG5;Initial Catalog=ProjectE2046609;Integrated Security=True";
            SqlConnection con = new SqlConnection(dbString);
            con.Open();

            if (textBox_deleteAppNo_Payment.Text != " ")
            {


                if (MessageBox.Show("Are you shure to delete this data???", "Delete Records", MessageBoxButtons.YesNo) == DialogResult.Yes)



                {

                    SqlCommand cmd = new SqlCommand("Delete Table_MakePayment where AppointmentNO=@AppointmentNO", con);
                    cmd.Parameters.AddWithValue("@AppointmentNO", int.Parse(textBox_deleteAppNo_Payment.Text));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Succesfully dleted");
                    textBox_DeletePaymentName.Clear();
                    textBox_deleteAppNo_Payment.Clear();
                    


                }
            }
        }

        private void textBox_deleteAppNo_Payment_TextChanged(object sender, EventArgs e)
        {
            String dbString = "Data Source=DESKTOP-N1AKUG5;Initial Catalog=ProjectE2046609;Integrated Security=True";
            SqlConnection con = new SqlConnection(dbString);
            con.Open();

            if (textBox_deleteAppNo_Payment.Text != " ")
            {

                SqlCommand cmd = new SqlCommand("Select Name from Table_MakePayment where AppointmentNO =@AppointmentNO", con);
                cmd.Parameters.AddWithValue("@AppointmentNO", textBox_deleteAppNo_Payment.Text);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    textBox_DeletePaymentName.Text = da.GetValue(0).ToString();
                    
                  
                }
                con.Close();

            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Add_Payments_Click(object sender, EventArgs e)
        {
            panel_DeletePAyament.Visible = false;
            pictureBox2.Visible = false;
        }

        private void button_Delete_Payment_Click(object sender, EventArgs e)
        {
            panel_DeletePAyament.Visible = true;
            pictureBox2.Visible = false;
        }

        private void button_Genarate_Click(object sender, EventArgs e)
        {
            int hours = Convert.ToInt32(textBox_Hours.Text);
            int value = Convert.ToInt32(textBox_Price_PerHour.Text);

            int price = hours * value;

            textBox_PaymentForAppointment.Text = price.ToString();
        }
    }
}
