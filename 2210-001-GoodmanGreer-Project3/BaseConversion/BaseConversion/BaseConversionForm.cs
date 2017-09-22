//Project:       Project 3
//Filename:      Form1.cs
//Description:   Event handlers for the Form1
//Course:        CSCI2210-001 Data Structures
//Author:        Greer Goodman, goodmang@goldmail.etsu.edu
//Created:       March 27, 2016
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseConversion
{
    /// <summary>
    /// Class for the event handlers of Form1
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }//end
        /// <summary>
        /// Button for Decimal > Base conversion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //textBox2.Text = BaseConverter.ResultsPlace((int)numericUpDown2.Value - BaseConverter.FromDecimal(int.Parse(textBox1.Text), (int)numericUpDown1.Value).Length);
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Please consider inputting a number before pressing that button.");
            }
            else
            {
                 textBox2.Text = BaseConverter.ResultsPlace((int)numericUpDown2.Value - BaseConverter.FromDecimal(int.Parse(textBox1.Text), (int)numericUpDown1.Value).Length, (int)numericUpDown1.Value) + BaseConverter.FromDecimal(int.Parse(textBox1.Text), (int)numericUpDown1.Value);
            }
            textBox1.ForeColor = Color.Blue;
            textBox2.ForeColor = Color.Red;
        }//end
        /// <summary>
        /// Event handler for changing the the label for which base you are converting to/from
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = "Integer Value in Base " + numericUpDown1.Value;
            textBox2.Text = "";
        }//end
        /// <summary>
        /// Event handler for when the form is closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult DLR = MessageBox.Show("Are you sure you would like to exit this amazing program?", "Exit Dialogue", MessageBoxButtons.YesNo);
            if(DLR == DialogResult.No)
            {
                e.Cancel = true;    //cancel the closing of the Form
            }//end if
        }//end
        /// <summary>
        /// Event handler for what happens when the Form closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Thank you for using " + ProductName + " " + ProductVersion + " written by " + CompanyName);
        }//end
        /// <summary>
        /// Event handler for the Conversion > Base conversion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Please consider inputting a number before pressing that button.");
            }//end if
            else
            {
                textBox1.Text = BaseConverter.ToDecimal(textBox2.Text, (int)numericUpDown1.Value).ToString();
            }//end else
            //Set ForeColors
            textBox1.ForeColor = Color.Red;
            textBox2.ForeColor = Color.Blue;
        }//end
        /// <summary>
        /// event handler for the Exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }//end
        /// <summary>
        /// Event handler for what is supposed to happen when the Form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = ProductName;
        }//end
        /// <summary>
        /// Event handler for keypress events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //switch to determine what to accept from the user
            switch(e.KeyChar)
            {
                case '0':
                     if(numericUpDown1.Value < 17)
                     {
                            e.Handled = false;
                     }
                     break;
                case '1':
                    if (numericUpDown1.Value < 17)
                    {
                        e.Handled = false;
                    }
                    break;
                case '2':
                    if (numericUpDown1.Value > 2)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case '3':
                    if (numericUpDown1.Value > 3)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case '4':
                    if (numericUpDown1.Value > 4)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case '5':
                    if (numericUpDown1.Value > 5)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case '6':
                    if (numericUpDown1.Value > 6)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case '7':
                    if (numericUpDown1.Value > 7)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case '8':
                    if (numericUpDown1.Value > 8)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case '9':
                    if (numericUpDown1.Value > 9)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case 'A':
                    if (numericUpDown1.Value > 10 && numericUpDown1.Value < 17)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case 'B':
                    if (numericUpDown1.Value > 11 && numericUpDown1.Value < 17)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case 'C':
                    if (numericUpDown1.Value > 12 && numericUpDown1.Value < 17)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case 'D':
                    if (numericUpDown1.Value > 13 && numericUpDown1.Value < 17)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case 'E':
                    if (numericUpDown1.Value > 14 && numericUpDown1.Value < 17)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case 'F':
                    if (numericUpDown1.Value == 16)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case 'a':
                    if (numericUpDown1.Value > 10 && numericUpDown1.Value < 17)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case 'b':
                    if (numericUpDown1.Value > 11 && numericUpDown1.Value < 17)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case 'c':
                    if (numericUpDown1.Value > 12 && numericUpDown1.Value < 17)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case 'd':
                    if (numericUpDown1.Value > 13 && numericUpDown1.Value < 17)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case 'e':
                    if (numericUpDown1.Value > 14 && numericUpDown1.Value < 17)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case 'f':
                    if (numericUpDown1.Value == 16)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        MessageBox.Show(e.KeyChar + " is not a valid input.");
                    }
                    break;
                case (char)Keys.Back: break;

                default:
                    MessageBox.Show(e.KeyChar + " is not a valid input.");
                    e.Handled = true;
                    break;
            }

        }
        /// <summary>
        /// KeyPress event handler for the decimal side
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //switch that allows input in base 10
            switch(e.KeyChar)
            {
                case '0':
                    break;
                case '1':
                    break;
                case '2':
                    break;
                case '3':
                    break;
                case '4':
                    break;
                case '5':
                    break;
                case '6':
                    break;
                case '7':
                    break;
                case '8':
                    break;
                case '9':
                    break;
                case (char)Keys.Back:
                    break;
                default:
                    MessageBox.Show("That is an invalid character, please keep it numerical.");
                    e.Handled = true;
                    break;
            }
        }
    }//end
}//end
