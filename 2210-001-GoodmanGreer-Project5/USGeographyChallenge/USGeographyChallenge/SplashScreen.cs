//Project:       Project 5
//Filename:      SplashScreen.cs
//Description:   Contains information and methods for the SplashScreen event handlers
//Course:        CSCI2210-001 Data Structures
//Author:        Greer Goodman, goodmang@goldmail.etsu.edu
//Created:       April 19, 2016
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USGeographyChallenge
{
    /// <summary>
    /// Partial class for that houses event handlers for the SplashScreen Form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class SplashScreen : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SplashScreen"/> class.
        /// </summary>
        public SplashScreen()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
