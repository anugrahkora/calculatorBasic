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

        
        private void printNumber(object sender, EventArgs e)//when a number is pressed this meathod is used 
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
        
        private void printOperator(object sender,EventArgs e)//when an operator is pressed, this meathod is used
        {
            try
            {
                Button b = sender as Button;
                value = double.Parse(textBox.Text);
                soperator = b.Text;   //soperator is initialised
                if (soperator == "x²")                   //
                    textBox.Text += b.Text.Remove(0, 1); //
                else if (soperator == "x³")              //these conditinal checking is used only to polish the output in the textbox
                    textBox.Text += b.Text.Remove(0, 1);//
                else if (soperator == "√")              //
                    textBox.Text = textBox.Text.Insert(0, "√");
                else
                    textBox.Text += b.Text;//the operator is is inserted to the textbox
                check = true;
            }catch(Exception exc)
            {
                MessageBox.Show("type a number first,no actions can be performed");
            }
           
        }
        
        
        private void clearButton_Click(object sender, EventArgs e)//this meathod is used when CE button is clicked

        {
            textBox.Text = "0";//clears textbox and set value as 0
            value = 0;

        }
        private void deleteButton_Click(object sender, EventArgs e)
            
        {
            if (textBox.Text.Length > 1)

                textBox.Text = textBox.Text.Remove(textBox.TextLength - 1);//decrements by 1 from the end of the value string
            else
                textBox.Text = "0";

        }

        private void equalsButton_Click(object sender, EventArgs e)//when equal button is pressed
        {
            try
            {
                switch(soperator)
                {
                    case "+":
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
