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
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
            Fillcombo();
        }

        void Fillcombo()
        {
            try
            {


                String conString = "Data Source=DESKTOP-N1AKUG5;Initial Catalog=ProjectE2046609;Integrated Security=True";
                SqlConnection conDatabase = new SqlConnection(conString);
                conDatabase.Open();
                String sqlQary = "Select * from TblUserAcc";
                SqlCommand com = new SqlCommand(sqlQary, conDatabase);
                SqlDataReader myReader = com.ExecuteReader(); 
            

               


                while (myReader.Read())
                {
                  
                    comboBox_trainnerName.Items.Add(myReader ["UserName"]);

                }
                



            }
            catch (Exception)
            {
            }



        }





























        private void btn_makeAppointment_Click(object sender, EventArgs e)
        {

            try
            {


                String dbString = "Data Source=DESKTOP-N1AKUG5;Initial Catalog=ProjectE2046609;Integrated Security=True";
                SqlConnection con = new SqlConnection(dbString);
                con.Open();

                String sqlQary = "insert into Appointment values('" + textBox_Appoint_Number.Text + "', '" + textBox_Name.Text + "','" + textBox_Contact.Text + "','" + textBox_Age.Text + "','" + comboBox_gender.Text + "','" + dateTimePicker1.Text + "','" + comboBox_trainnerName.Text + "','" + textBox_Hours.Text + "','" + textBox_Remark.Text + "')";
                SqlCommand com = new SqlCommand(sqlQary, con);
                com.ExecuteNonQuery();


            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }

            MessageBox.Show("Successfull added an appointment!!!");
               textBox_Appoint_Number.Clear();
               textBox_Name.Clear();
               textBox_Contact.Clear();
               textBox_Age.Clear();
               textBox_Hours.Clear();
               comboBox_gender.Text = string.Empty;
               comboBox_trainnerName.Text = string.Empty;
               dateTimePicker1.Text = string.Empty;
               textBox_Appoint_Number.Focus();
            textBox_Remark.Clear();


        }

        private void button_MakeAppointment_Click(object sender, EventArgs e)
        {
            panal_MakeAppointment.Visible = true;
            panel_ViewAllAppointment.Visible = false;
            panel_Delete.Visible = false;
            pictureBox2.Visible = false;
        }

        private void button_ViewAllAppontment_Click(object sender, EventArgs e)
        {
            panal_MakeAppointment.Visible = true;
            panel_ViewAllAppointment.Visible = true;
            panel_Delete.Visible = false;
            pictureBox2.Visible = false;

            String dbString = "Data Source=DESKTOP-N1AKUG5;Initial Catalog=ProjectE2046609;Integrated Security=True";
            SqlConnection con = new SqlConnection(dbString);
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from [dbo].[Appointment]";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            dataGridView_ALLAppointment.DataSource = DS.Tables[0];


        }

        private void button_DeleteAppointment_Click(object sender, EventArgs e)
        {
            panal_MakeAppointment.Visible = true;
            panel_ViewAllAppointment.Visible = true;
            panel_Delete.Visible = true;
            pictureBox2.Visible = false;
            pictureBox2.Visible = false;
        }

        private void textBox_DeleteAPPNo_TextChanged(object sender, EventArgs e)
        {
            String dbString = "Data Source=DESKTOP-N1AKUG5;Initial Catalog=ProjectE2046609;Integrated Security=True";
            SqlConnection con = new SqlConnection(dbString);
            con.Open();

            if (textBox_DeleteAPPNo.Text != " ")
            {

                SqlCommand cmd = new SqlCommand("Select Name from Appointment where AppointmentNo =@AppointmentNo", con);
                cmd.Parameters.AddWithValue("@AppointmentNo", textBox_DeleteAPPNo.Text);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    textBox_DeleteUserName.Text = da.GetValue(0).ToString();


                }
                con.Close();

            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            String dbString = "Data Source=DESKTOP-N1AKUG5;Initial Catalog=ProjectE2046609;Integrated Security=True";
            SqlConnection con = new SqlConnection(dbString);
            con.Open();

            if (MessageBox.Show("Are you shure to delete this data???", "Delete Records", MessageBoxButtons.YesNo) == DialogResult.Yes)

            {
                SqlCommand cmd = new SqlCommand("Delete Appointment where AppointmentNo=@AppointmentNo", con);
                cmd.Parameters.AddWithValue("@AppointmentNo", int.Parse(textBox_DeleteAPPNo.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Succesfully dleted");


                textBox_DeleteAPPNo.Clear();
                textBox_DeleteUserName.Clear();

            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_Appoint_Number.Clear();
            textBox_Name.Clear();
            textBox_Contact.Clear();
            textBox_Age.Clear();
            textBox_Hours.Clear();
            comboBox_gender.Text = string.Empty;
            comboBox_trainnerName.Text = string.Empty;
            dateTimePicker1.Text = string.Empty;
            textBox_Remark.Clear();
        }

        private void button_EditAppointment_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
        }

        private void button_CloseAppointment_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Delete_CLear_Click(object sender, EventArgs e)
        {
            textBox_DeleteUserName.Clear();
            textBox_DeleteAPPNo.Clear();
        }
    }
}
