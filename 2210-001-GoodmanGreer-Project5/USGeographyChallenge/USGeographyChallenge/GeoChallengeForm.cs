//Project:       Project 5
//Filename:      GeoChallengeForm.cs
//Description:   Contains information and methods for the GeoChallengeForm event handlers
//Course:        CSCI2210-001 Data Structures
//Author:        Greer Goodman, goodmang@goldmail.etsu.edu
//Created:       April 19, 2016
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USGeographyChallenge
{
    /// <summary>
    /// Class that houses the event handlers for the GeoChallengeForm form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class GeoChallengeForm : Form
    {
        SortedDictionary<string, string> States;//SortedDictionary for key/value pairs
        List<string> Cities;
        List<string> State;
        string randomKey;
        Random r = new Random();
        int count = 15;//time the user has to make a selection
        int attempted = 0;
        int correct = 0;
        /// <summary>
        /// Initializes a new instance of the <see cref="GeoChallengeForm"/> class.
        /// </summary>
        public GeoChallengeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the button3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            count = 15;
            r = new Random();
            //make each control in the form visible
            foreach (Control match in Controls)
            {
                match.Visible = true;
            }
            button3.Visible = false;
            //get a key
            randomKey = State[r.Next(States.Count-1)];
            textBox1.Text = randomKey;
            //populate the listBox
            foreach (string str in Cities)
            {
                listBox1.Items.Add(str);
            }
            textBox2.Text = count.ToString();
            timer1.Start();
        }
        /// <summary>
        /// Handles the Load event of the GeoChallengeForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void GeoChallengeForm_Load(object sender, EventArgs e)
        {
            string city;
            string state;
            string strIn;
            StreamReader rdr = null;
            States = new SortedDictionary<string, string>();
            Cities = new List<string>();
            State = new List<string>();
            MessageBox.Show("\n1) Match the state on the left with it's capital on the right.\n2) Press the 'Next Question' button to process your choice.\n3) You have 15 seconds, make it count!", "Rules");
            //read and split the text file provided
            try
            {
                rdr = new StreamReader("../debug/states.txt");
                while (rdr.Peek() != -1)
                {
                    strIn = rdr.ReadLine();
                    string[] fields = strIn.Split(',');
                    city = fields[0];
                    state = fields[1].Trim();
                    States.Add(state, city);
                    Cities.Add(city);
                    State.Add(state);
                }
                rdr.Close();
                Cities.Sort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease make sure you have the text file.", "Error");
            }
        }
        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            count--;
            textBox2.ForeColor = Color.Red;
            textBox2.Text = count.ToString();
            if (count == 0)
            {
                timer1.Stop();
                listBox1.Enabled = false;
            }
        }
        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Enabled = true;
            //increment the attempted tries if the answer is wrong
            if (!(States[randomKey].Equals(listBox1.Text)))
            {
                attempted++;
                textBox3.Text = attempted.ToString();
                textBox4.Text = correct.ToString();
            }
            //increment attempted tries and correct number if the answer is correct
            else
            {
                attempted++;
                correct++;
                textBox3.Text = attempted.ToString();
                textBox4.Text = correct.ToString();
                State.Remove(textBox1.Text);
            }
            timer1.Stop();
            randomKey = State[r.Next(States.Count-1)];
            textBox1.Text = randomKey;
            count = 15;
            textBox2.Text = count.ToString();
            timer1.Start();
        }
        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Handles the FormClosing event of the GeoChallengeForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void GeoChallengeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            double correctPercent;
            try
            {
                correctPercent = ((correct * 100) / attempted);
            }
            catch (Exception)
            {
                correctPercent = 0;
            }
            timer1.Stop();
            MessageBox.Show("Thank you for playing US Geography Challenge created by Greer Goodman for Data Structures 2210-001. You got " + correctPercent + "% correct out of " + attempted + ". Have a great day!","Thank you");
        }
    }
}
