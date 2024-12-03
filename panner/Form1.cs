using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace panner
{
    public partial class panel : Form
    {
           
        // SqlConnection cn = new SqlConnection("Data Source=./SQLEXPRESS;Initial Catalog=login_test1;Integrated Security=True");
       // SqlConnection cn = new SqlConnection(@"server=LAPTOP-JMR0Q040\SQLEXPRESS; initial catalog = Charity ; Integrated Security=True");
        //SqlCommand cmd;
        //SqlDataReader dr;

        public panel()
        {

            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"server=LAPTOP-JMR0Q040\SQLEXPRESS; initial catalog = Charity ; Integrated Security=True");


        // string connectionString = "Data Source=LAPTOP-JMR0Q040/SQLEXPRESS;Initial Catalog=Charity;Integrated Security=True";

        private void panel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 form2 = new Form2();
            form2.Show();
            
        }
        public void recivedatafromfrom2(string data)
        {

        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void clear_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
        }




        // Connection string to your SQL Server database

        private void login_Click(object sender, EventArgs e)
        {


            string user_id , password;

            user_id = txtusername.Text;
            password = txtpassword.Text;

            try
            {
                string querry = "select * from login_test where user_id = '"+txtusername.Text+"' and password = '"+txtpassword.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, cn);

                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    user_id = txtusername.Text;
                    password = txtpassword.Text;

                    var form4 = new Form4();
                    form4.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("invidol login " , "error" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                    txtusername.Clear();
                    txtpassword.Clear();

                    txtusername.Focus();
                }

                
            }
            catch 
            {

                MessageBox.Show("error");
            }
            finally
            {
                cn.Close();
            }
           

            //password = "Alaa123";
            //user = "alAa";

            

            if (txtusername.Text.ToUpper().Trim() != user_id.ToUpper())
            {
               // MessageBox.Show("User");
                return;
            }

            if (txtpassword.Text.ToUpper().Trim() != password.ToUpper() || txtpassword.Text.ToLower().Trim() != password.ToLower()) 
            {
                ///MessageBox.Show("Pass");
                return;
            }

            MessageBox.Show("Done");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            var form3 = new Form3();
           form3.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form4 = new Form4();
            form4.Show();
        }
    }
    }







