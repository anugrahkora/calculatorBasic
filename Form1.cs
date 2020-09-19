using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace calculatorBasic
{
  
    public partial class Calculator : Form
    {
        double value;
        String soperator;
        Boolean check;
        public Calculator()
        {
            InitializeComponent();
        }


        private void printNumber(object sender, EventArgs e)
        { 
            //for getting the bellow special characters
            //÷: ALT 0247,x²:x+ALT 253,x³:x+ALT 0179,√: ALT 251
            if ((soperator == "+") || (soperator == "-") || (soperator == "x") || (soperator == "÷") || (soperator == "x²") || (soperator == "x³") || (soperator == "000") || (soperator == "√"))
            {
                if(check)
                {
                    check = false;
                    textBox.Text = "0";
                }
                
            }Button b = sender as Button;
            if (textBox.Text == "0")
            {
                textBox.Text = b.Text;

            }
            else
                textBox.Text += b.Text;
           

         
        }
        private void printOperator(object sender,EventArgs e)
        {
            Button b = sender as Button;
            value = double.Parse(textBox.Text);
            soperator = b.Text;
            textBox.Text += b.Text;
            check = true;
        }

        private void clearButton_Click(object sender, EventArgs e)
            //clears textbox and set value as 0
        {
            textBox.Text = "0";
            value = 0;

        }

        private void deleteButton_Click(object sender, EventArgs e)
            //removes each digit from the end of the value string
        {
            if (textBox.Text.Length > 1)


                textBox.Text = textBox.Text.Remove(textBox.TextLength - 1);

            else
                textBox.Text = "0";

        }

        private void equalsButton_Click(object sender, EventArgs e)
        {//÷: ALT 0247,x²:x + ALT 253,x³:x + ALT 0179,√: ALT 251
            try
            {
                switch(soperator)
                {
                    case "+":solut
                        textBox.Text = (value + double.Parse(textBox.Text)).ToString();
                        break;
                    case "-":
                        textBox.Text = (value - double.Parse(textBox.Text)).ToString();
                        break;
                    case "÷":
                        textBox.Text = (value / double.Parse(textBox.Text)).ToString();
                        break;
                    case "x":
                        textBox.Text = (value * double.Parse(textBox.Text)).ToString();
                        break;
                    case "x²":
                        textBox.Text = (value * value).ToString();
                        break;
                    case "x³":
                        textBox.Text = (value * value * value).ToString();
                        break;
                    case "√":
                        textBox.Text = (Math.Sqrt(value)).ToString();
                        break;
                    case "000":
                        textBox.Text = (value * 1000).ToString();
                        break;
                   
                }



            }catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);   

            }
        }
    }
            
      

}
