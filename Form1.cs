using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/**
 * This is a simple calculator project
 * This project is of two folds: 
 * i. Standard calculator and ii. Scientific calculator
 * This project provides you the interface for for both of them
 * From file menue, you can select either of the two options
 * For standard calculator, it performs standard addition, multiplication,
 * subtraction and division.
 * This standard calculator provides the basic feature of clearing the whole field
 * and delete element by element as well
 * In the scientific  calculator it does the following operations
 * square of a number, power of 3 of a number, inverse of a number
 * Basic logarithm operations on a number
 * Sin, Cos, tan operations of a number
 * Modulus and percent operation
 * Decimal to binary, octal and hexa conversion
 */
namespace CalculatorProject
{
    public partial class Form1 : Form
    {
        Double results = 0.0;
        Double convert = 0.0;
        String operation = "";
        bool enter_value = false;
        bool plus_minus = true;
        bool isDecimal=false;
        bool isBinary = false;
        bool isHex = false;


        public Form1()
        {
            InitializeComponent();
        }
        /**
         * This sets the initial window size
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 250;
            txtDisplay.Width = 212;
        }
        // Standard calculator window
        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 250;
            txtDisplay.Width = 212;
        }
        // Scientific calculator window
        private void scientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 480;
            txtDisplay.Width = 443;
        }
        /**
         * This method is for taking input from button click
         * This also displays the number in the text field or labels
         */ 
        private void button_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "0" || enter_value)
            {
                txtDisplay.Text = "";
            }
            else
            {
                enter_value = false;
            }

            Button num = (Button)sender;
            // Fractional numbers are taken care of here
            if (num.Text == ".")
            {
                if (!txtDisplay.Text.Contains("."))
                {
                    txtDisplay.Text = txtDisplay.Text + num.Text;
                }
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + num.Text;
            }
        }
        /**
         * This button performs the clearing operation
         */ 
        private void button2_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            labelInput.Text = "";
        }
        /**
         * This button performs the clearing operation
         */
        private void button3_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            labelInput.Text = "";
        }
        /**
         * This button clears each character after clicking operation
         */ 
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
            if(txtDisplay.Text == "")
            {
                txtDisplay.Text = "0";
            }
        }
        /**
         * This group of buttons are responsible for 
         * some arithmatic operation
         * Addition, subtraction, multiplication, division and modulus 
         * operation
         */ 
        private void arithmatic_operation(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            operation = num.Text; 
            results = Double.Parse(txtDisplay.Text);
            txtDisplay.Text = "";
            labelInput.Text = System.Convert.ToString(results) + " " + operation;
        }
        /**
         * After pressing the = button, based on the arithmatic
         * operator, it does the job accordingly
         * Later, it displays the result in the text field
         */ 
        private void button18_Click(object sender, EventArgs e)
        {
            labelInput.Text = "";
            switch(operation)
            {
                case "+":
                    txtDisplay.Text = (results + Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (results - Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (results * Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    txtDisplay.Text = (results / Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "Mod":
                    txtDisplay.Text = (results % Double.Parse(txtDisplay.Text)).ToString();
                    Console.Write(txtDisplay.Text);
                    break;
            }
            results = Double.Parse(txtDisplay.Text);

        }
        /**
         * This button performs the sign change for a number
         * For example, after pressing this button, a positive number becomes 
         * negative and vice versa. 
         */ 
        private void button4_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            if (plus_minus)
            {
                txtDisplay.Text = "-" + (txtDisplay.Text); // Negation is done
                plus_minus = false;
            }
            else {
                convert = Double.Parse(txtDisplay.Text);
                double xx = -convert;// double negation
                txtDisplay.Text =System.Convert.ToString(xx);
                plus_minus = true;
            }
        }
        /**
         * This button is responsible for generating PI
         * for the scientific calculator
         */ 
        private void button40_Click(object sender, EventArgs e)
        {
            double Pi = 3.1416;
            txtDisplay.Text = System.Convert.ToString(Pi);
        }
        /**
         * This is button is responsible for calculating
         * logarithm value which has a base of 10
         */ 
        private void button39_Click(object sender, EventArgs e)
        {
            double logVal = Double.Parse(txtDisplay.Text);
            labelInput.Text = System.Convert.ToString("log" + "(" + (txtDisplay.Text) + ")");
            logVal = Math.Log10(logVal);
            txtDisplay.Text = System.Convert.ToString(logVal);
                
        }
        /**
         * This button is responsible for generating square root of a number
         */ 
        private void button38_Click(object sender, EventArgs e)
        {
            double value = Double.Parse(txtDisplay.Text);
            value = Math.Sqrt(value);
            labelInput.Text = System.Convert.ToString("Sqrt of "+(txtDisplay.Text)+" ");
            txtDisplay.Text = System.Convert.ToString(value);
        }
        /**
         * This is responsible for squaring a number
         */ 
        private void button37_Click(object sender, EventArgs e)
        {
            double value = Double.Parse(txtDisplay.Text);
            value = Math.Pow(value,2);
            labelInput.Text = System.Convert.ToString("Square of " + (txtDisplay.Text) + " ");
            txtDisplay.Text = System.Convert.ToString(value); 
        }
        /**
         * This buttton is responsible for calculating the value from sinh operation
         */ 
        private void button36_Click(object sender, EventArgs e)
        {
            double value = Double.Parse(txtDisplay.Text);
            value = Math.Sinh(value);
            labelInput.Text = System.Convert.ToString("Sinh of " + (txtDisplay.Text) + " ");
            txtDisplay.Text = System.Convert.ToString(value);
        }
        /**
         * This buttton is responsible for calculating the value from sin operation
         */
        private void button35_Click(object sender, EventArgs e)
        {
            double value = Double.Parse(txtDisplay.Text);
            value = Math.Sin(value);
            labelInput.Text = System.Convert.ToString("Sin of " + (txtDisplay.Text) + " ");
            txtDisplay.Text = System.Convert.ToString(value); 
        }
        /**
         * This button is responsible for generating decimal value from binary
         */ 
        private void button34_Click(object sender, EventArgs e)
        {
            isDecimal = true;
            if (isDecimal && isBinary)
            { 
            decimal d = Convert.ToInt32(txtDisplay.Text, 2);
            labelInput.Text = System.Convert.ToString("Decimal of " + (txtDisplay.Text) + " ");
            txtDisplay.Text = d.ToString();
            }
        }
        /**
         * This button is responsible for calculating power of 3
         */ 
        private void button33_Click(object sender, EventArgs e)
        {
            double value = Double.Parse(txtDisplay.Text);
            value = Math.Pow(value, 3);
            labelInput.Text = System.Convert.ToString("Square of " + (txtDisplay.Text) + " ");
            txtDisplay.Text = System.Convert.ToString(value);
        }
        /**
         * This buttton is responsible for calculating the value from cosh operation
         */
        private void button32_Click(object sender, EventArgs e)
        {
            double value = Double.Parse(txtDisplay.Text);
            value = Math.Cosh(value);
            labelInput.Text = System.Convert.ToString("Cosh of " + (txtDisplay.Text) + " ");
            txtDisplay.Text = System.Convert.ToString(value);
        }
        /**
         * This buttton is responsible for calculating the value from Cos operation
         */
        private void button31_Click(object sender, EventArgs e)
        {
            double value = Double.Parse(txtDisplay.Text);
            value = Math.Cos(value);
            labelInput.Text = System.Convert.ToString("Cos of " + (txtDisplay.Text) + " ");
            txtDisplay.Text = System.Convert.ToString(value);
        }
        /**
         * This button is responsible for generating binary value from decimal
         */ 
        private void button30_Click(object sender, EventArgs e)
        {
            isBinary = true;
            int remainder = 0;
            String res = string.Empty;
            int d = int.Parse(txtDisplay.Text);
            while (d>0) {
                remainder = d % 2;
                res = remainder.ToString() + res;
                
                d = d / 2;
            }
            labelInput.Text = System.Convert.ToString("Binary of " + (txtDisplay.Text) + " ");
            txtDisplay.Text = res;
        }
        /**
         * This button is responsible for calculating 1/x 
         */ 
        private void button29_Click(object sender, EventArgs e)
        {
            double x = 1 / Double.Parse(txtDisplay.Text);
            txtDisplay.Text = System.Convert.ToString(x);
        }
        /**
         * This buttton is responsible for calculating the value from Tanh operation
         */
        private void button28_Click(object sender, EventArgs e)
        {
            double value = Double.Parse(txtDisplay.Text);
            value = Math.Tanh(value);
            labelInput.Text = System.Convert.ToString("Tanh of " + (txtDisplay.Text) + " ");
            txtDisplay.Text = System.Convert.ToString(value);
        }
        /**
         * This buttton is responsible for calculating the value from Tan operation
         */
        private void button27_Click(object sender, EventArgs e)
        {
            double value = Double.Parse(txtDisplay.Text);
            value = Math.Tan(value);
            labelInput.Text = System.Convert.ToString("Tan of " + (txtDisplay.Text) + " ");
            txtDisplay.Text = System.Convert.ToString(value);
        }
        /**
         * This button performs decimal to hex conversion
         */ 
        private void button26_Click(object sender, EventArgs e)
        {
            int hexValue = int.Parse(txtDisplay.Text);
            //string myHex = hexValue.ToString("X");  // Gives you hexadecimal
            //txtDisplay.Text = myHex;
            txtDisplay.Text = System.Convert.ToString(hexValue,16);
        }
        /**
         * This button performs natural ln operation of a number
         */ 
        private void button25_Click(object sender, EventArgs e)
        {
            double lnValue = Double.Parse(txtDisplay.Text);
            lnValue = Math.Log(lnValue);
            //lnValue = Math.Log(lnValue, 2.0);
            labelInput.Text=System.Convert.ToString(" ln of " + txtDisplay.Text + " is");
            txtDisplay.Text = System.Convert.ToString(lnValue);
        }
        /**
         * This button performs operation on logarithm which has a base of 2
         */ 
        private void button24_Click(object sender, EventArgs e)
        {
            double lnValue = Double.Parse(txtDisplay.Text);
            lnValue = Math.Log(lnValue, 2.0);
            labelInput.Text = System.Convert.ToString(" log2 of " + txtDisplay.Text + " is");
            txtDisplay.Text = System.Convert.ToString(lnValue);

        }
        /**
         * This button perfroms the mudulus operation
         */ 
        private void button23_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            operation = num.Text;
            results = Double.Parse(txtDisplay.Text);
            labelInput.Text= System.Convert.ToString(results) + " " + operation;
            txtDisplay.Text = "";
        }
        /**
         * This button performs the conversion from decimal to octal number
         */ 
        private void button22_Click(object sender, EventArgs e)
        {
            int octValue = int.Parse(txtDisplay.Text);
            txtDisplay.Text = System.Convert.ToString(octValue, 8);
        }
        /**
         * This button perfoms the percent operation.
         */ 
        private void button21_Click(object sender, EventArgs e)
        {
            double perValue = Double.Parse(txtDisplay.Text);
            perValue = perValue / 100;
            txtDisplay.Text = perValue.ToString();
        }
    }
}
