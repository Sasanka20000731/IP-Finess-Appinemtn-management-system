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
    public partial class Useraccount : Form
    {
        public Useraccount()
        {
            InitializeComponent();
        }

        private void button_CreatUserAccount_Click(object sender, EventArgs e)
        {
            panel_addUserForm.Visible = true;
            panel_Delete.Visible = false;
            pictureBox2.Visible = false;

        }

        private void button_ViewAllAccount_Click(object sender, EventArgs e)
        {
            panel_addUserForm.Visible = false;
            pictureBox2.Visible = false;
            panel_Delete.Visible = false;

            String dbString = "Data Source=DESKTOP-N1AKUG5;Initial Catalog=ProjectE2046609;Integrated Security=True";
            SqlConnection con = new SqlConnection(dbString);
            SqlCommand cmd = new SqlCommand("Select * from TblUserAcc", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView_AllUserAccount.DataSource = dt;

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            String dbString = "Data Source=DESKTOP-N1AKUG5;Initial Catalog=ProjectE2046609;Integrated Security=True";
            SqlConnection con = new SqlConnection(dbString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into TblUserAcc values (@UserName,@UserPassword,@Role,@StaffID)", con);

            cmd.Parameters.AddWithValue("@UserName", textBox_NewUserName.Text);
            cmd.Parameters.AddWithValue("@UserPassword", textBox_NewUserPassord.Text);
            cmd.Parameters.AddWithValue("@Role", comboBox_Role.SelectedItem);
            cmd.Parameters.AddWithValue("@StaffID", textBox_newUserID.Text);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Successfully Added New User");
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            panel_addUserForm.Visible = false;
            pictureBox2.Visible = false;
            panel_Delete.Visible = true;

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            panel_addUserForm.Visible = false;
            pictureBox2.Visible = false;
            panel_Delete.Visible = false;
            /*

            String dbString = "Data Source=DESKTOP-N1AKUG5;Initial Catalog=ProjectE2046609;Integrated Security=True";
            SqlConnection con = new SqlConnection(dbString);
            SqlCommand cmd = new SqlCommand("Update TblUserAcc UserName=@UserName, UserPassword=@UserPassword  ,Role=@Role ", con);

            cmd.Parameters.AddWithValue("@UserName", textBox_NewUserName.Text);
            cmd.Parameters.AddWithValue("@UserPassword", textBox_NewUserPassord.Text);
            cmd.Parameters.AddWithValue("@Role", comboBox_Role.SelectedItem);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Successfully Eddited User");

            */
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_newUserID.Clear();
            textBox_NewUserName.Clear();
            textBox_NewUserPassord.Clear();
            comboBox_Role.Text = string.Empty;
        }

        private void textBox_DeleteID_TextChanged(object sender, EventArgs e)
        {
            String dbString = "Data Source=DESKTOP-N1AKUG5;Initial Catalog=ProjectE2046609;Integrated Security=True";
            SqlConnection con = new SqlConnection(dbString);
            con.Open();

            if (textBox_DeleteID.Text != " ")
            {

                SqlCommand cmd = new SqlCommand("Select UserName from TblUserAcc where StaffID =@StaffID", con);
                cmd.Parameters.AddWithValue("@StaffID", textBox_DeleteID.Text);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    textBox_DeleteName.Text = da.GetValue(0).ToString();


                }
                con.Close();

            }
        }

        private void button_Delete_Acc_Click(object sender, EventArgs e)
        {
            String dbString = "Data Source=DESKTOP-N1AKUG5;Initial Catalog=ProjectE2046609;Integrated Security=True";
            SqlConnection con = new SqlConnection(dbString);
            con.Open();

            if (MessageBox.Show("Are you shure to delete this data???", "Delete Records", MessageBoxButtons.YesNo) == DialogResult.Yes)

            {
                SqlCommand cmd = new SqlCommand("Delete TblUserAcc where StaffID=@StaffID", con);
                cmd.Parameters.AddWithValue("@StaffID", int.Parse(textBox_DeleteID.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Succesfully dleted");


                textBox_DeleteID.Clear();
                textBox_DeleteName.Clear();

            }
        }
    }
}
