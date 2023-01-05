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
    public partial class logIn_Form : Form
    {

       
        


        public logIn_Form()
        {
            InitializeComponent();
        }

        private void button_LogIn_Click(object sender, EventArgs e)
        {
            String conString = "Data Source=DESKTOP-N1AKUG5;Initial Catalog=ProjectE2046609;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter da;
            SqlCommand cmd; 

    
            con.Open();
            cmd = new SqlCommand("Select * from  TblUserAcc where UserName = '" + textBox_Username.Text.Trim() + "' and  UserPassword = '" + textBox_UserPassword.Text.Trim() + "'",con);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet(); 
           da.SelectCommand = cmd;
            da.Fill(ds);
            int i = ds.Tables[0].Rows.Count;
            if (i == 1)
            {
               

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr[2].ToString() == "Admin")   
                {
                      ClassUL.type = "A";
                   
                } 
                else if (dr[2].ToString() == "Cashier")
                {

                    ClassUL.type = "C";
                }
                else if (dr[2].ToString() == "Trainner")
                {
                      ClassUL.type = "T";
                }


                

                Dashboad dashboad = new Dashboad();
                this.Hide();
                dashboad.Show();



            }

            else
            {
                MessageBox.Show("Check your Username and Password");
            }
        }

        private void textBox_Username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
