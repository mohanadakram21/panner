using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace panner
{
    public partial class Form2 : Form
    {
        SqlConnection cn = new SqlConnection(@"server=LAPTOP-JMR0Q040\SQLEXPRESS; initial catalog = Charity ; Integrated Security=True");

        // SqlConnection cn = new SqlConnection("Data Source=./SQLEXPRESS;Initial Catalog=login_test1;Integrated Security=True");
        SqlCommand cmd;
        
        public Form2()
        {
            InitializeComponent();
        }

        public static string datafromform1 { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into login_test(user_id,password) values ('" + txtname.Text+"','"+txtpass.Text+"'" +
                ")",cn);
            try
            {
                cn.Open();
                cmd.BeginExecuteNonQuery();
                MessageBox.Show("add sucesfull", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch 
            {
                MessageBox.Show("error");

            }
            finally
            {
                cn.Close();
                this.Close();
                Form2 form = new Form2();
                form.Show();

            }
            
            //string user, pass , email;
            //user = txtname.Text;
            //pass = txtpass.Text;
            

            //if (user == "alaa" && pass == "Alaa" && email == "@alaa")
            //{
            //    MessageBox.Show("welcome");
            //}
            //else
            //{
            //    MessageBox.Show("error");
            //}

            //panel form1 = new panel();
            //Form2.datafromform1 = "hllo a";
            //form1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtpass.Clear();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            panel form1 = new panel();
            form1.Show();
             
        }
    }
}
