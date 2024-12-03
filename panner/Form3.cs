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
    public partial class Form3 : Form
    {
        SqlConnection cn = new SqlConnection(@"server=LAPTOP-JMR0Q040\SQLEXPRESS; initial catalog = Charity ; Integrated Security=True");
       // SqlConnection cn = new SqlConnection("Data Source=LAPTOP-JMR0Q040;Initial Database=Charity;Integrated Security=True");
        //SqlDataAdapter da;
        //DataSet ds = new DataSet();
        SqlCommand cmd;
        SqlDataReader dr;

        public Form3()
        {
            InitializeComponent();


          


            //while (dr.Read())
            //{

            // listBox1.Items.Add(dr["user_id"].ToString());
            // listBox1.Items.Add(dr["password"].ToString());
            //dr.Close();
            //cn.Close();
            //}
            // dr.Close();
            //cn.Close();
        }
        //private void comboBox1()
        // {
        //string querry = "select * user_id from login_test";
        //    SqlDataAdapter sda = new SqlDataAdapter(querry, cn);
        //    cn.Open();

        //    DataTable dataTable = new DataTable();
        //    sda.Fill(dataTable);
        //    cn.Close();
      
        //}

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'charityDataSet.login_test' table. You can move, or remove it, as needed.
            this.login_testTableAdapter.Fill(this.charityDataSet.login_test);


        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("update login_test set password= '" + textBox1.Text + "' where user_id='" + comboBox1.Text + "' ", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("update done" ,"update" ,MessageBoxButtons.OK , MessageBoxIcon.Information);
               
                
            }
            catch
            {

                MessageBox.Show("no update", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                cn.Close();
                this.Close();
                Form3 form = new Form3();
                form.Show();

            }



        }

        private void remove_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("delete from login_test where user_id='" + comboBox1.Text + "' ", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("delete done", "delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

                MessageBox.Show("no delete", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                cn.Close();
                this.Close();
                Form3 form = new Form3();
                form.Show();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cmd = new SqlCommand("select * from login_test", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            
          //  da = new SqlDataAdapter("select * from table_1", cn);
          //  da.Fill(ds, "dataveiw");
           // DataGridView.datasource = ds.Tables["dataveiw"];
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            try
            {
                cmd = new SqlCommand("select password from login_test where user_id='" + comboBox1.Text + "' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                textBox1.Text = dr["password"].ToString();
               
            }
            catch 
            {

                MessageBox.Show("error");//, MessageBoxButtons.OK, //MessageBoxIcon.Error);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            panel form1 = new panel();
            form1.Show();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

          


        }

        private void button3_Click(object sender, EventArgs e)
        {
             comboBox1.Items.Clear();
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select user_id from login_test";
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
            {
                comboBox1.Items.Add(dr["user_id"].ToString());
            }
            cn.Close();
        }
    }
}
