using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

namespace panner
{
    public partial class Form4 : Form
    {

        double firstNumber = 0;
        //double secondNumber = 0;
        //string operation = "";
        List<double> numbers = new List<double>();
        //bool isFirstNumberEntered = false;
        //double result = 0;

        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;


        public Form4()
        {
            InitializeComponent();
        }



        private void button10_Click(object sender, EventArgs e)
        {

            //Button button = (Button)sender;

            //if (isFirstNumberEntered)
            //{
            //    textBox1.Text += button.Text;
            //}
            //else
            //{
            //    textBox1.Text = button.Text;
            //    isFirstNumberEntered = true;
            //}







            if ((textBox1.Text == "0") || (isOperationPerformed))
                textBox1.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBox1.Text.Contains("."))
                    textBox1.Text = textBox1.Text + button.Text;

            }
            else
                textBox1.Text = textBox1.Text + button.Text;


        }

        private void button15_Click(object sender, EventArgs e)
        {
            //Button button = (Button)sender;
            //if (textBox1.Text == "")
            //{
            //    MessageBox.Show("plz insert num");
            //    return;
            //}
            //operationPerformed = button.Text;
            //isOperationPerformed = true;

            //numbers.Add(double.Parse(textBox1.Text));
            //firstNumber = double.Parse(textBox1.Text);
            //label2.Text = textBox1.Text + " " + operationPerformed;



            Button button = (Button)sender;


            try
            {


                if (resultValue != 0)
                {
                    button11.PerformClick();
                    operationPerformed = button.Text;
                    label2.Text = resultValue.ToString() + " " + operationPerformed;                 
                    //if (resultValue < 0)
                    //{
                    //    label2.Text = "(" + Math.Abs(resultValue) + ") " + operationPerformed;
                    //}
                    //else
                    //{
                    //    label2.Text = resultValue.ToString() + " " + operationPerformed;
                    //}
                    isOperationPerformed = true;
                    //label2.Text = resultValue.ToString() + " " + operationPerformed;

                   
                }
                else
                {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("الرجاء إدخال رقم");
                        return;
                    }
                    operationPerformed = button.Text;
                    resultValue = Double.Parse(textBox1.Text);
                    //if (resultValue < 0)
                    //{
                    //    label2.Text = "(" + Math.Abs(resultValue) + ") " + operationPerformed;
                    //}
                    //else
                    //{
                    //    label2.Text = resultValue.ToString() + " " + operationPerformed;
                    //}
                    label2.Text = resultValue.ToString() + " " + operationPerformed;
                    //resultValue = Double.Parse(textBox1.Text);

                    isOperationPerformed = true;
                    return;
                }

            numbers.Add(resultValue);
            firstNumber = double.Parse(textBox1.Text);
            resultValue = Double.Parse(textBox1.Text);

            }
            catch (Exception x)
            {
                Console.WriteLine("err", x.Message);
               // MessageBox.Show("error num");
            }










        }



        private void button11_Click(object sender, EventArgs e)
        {



            if (textBox1.Text == "")
            {
                MessageBox.Show("plz insert num");
                return;
            }


          

            if (operationPerformed != "")
            {

                switch (operationPerformed)
                {
                    case "+":
                        textBox1.Text = (resultValue + Double.Parse(textBox1.Text)).ToString();
                        break;
                    case "-":
                        textBox1.Text = (resultValue - Double.Parse(textBox1.Text)).ToString();
                        break;
                    case "*":
                        textBox1.Text = (resultValue * Double.Parse(textBox1.Text)).ToString();
                        break;
                    case "/":
                        textBox1.Text = (resultValue / Double.Parse(textBox1.Text)).ToString();
                        break;
                    default:
                        break;
                }
            }
                resultValue = Double.Parse(textBox1.Text);
                label2.Text = "";



                isOperationPerformed = false;
                operationPerformed = "";





            

        }


        private void button16_Click(object sender, EventArgs e)
            {


            //textBox1.Clear();
            //isFirstNumberEntered = false;
            //operation = "";
            //firstNumber = 0;
            //secondNumber = 0;
            //label2.Text = " ";
            //numbers.Clear();
            label2.Text = " ";
            textBox1.Clear();
            resultValue = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Hide();
            panel form1 = new panel();
            form1.Show();
        }

       
    }
}
