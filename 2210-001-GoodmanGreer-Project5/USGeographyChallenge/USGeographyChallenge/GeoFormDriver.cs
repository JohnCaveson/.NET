//Project:       Project 5
//Filename:      GeoFormDriver.cs
//Description:   Runs the program
//Course:        CSCI2210-001 Data Structures
//Author:        Greer Goodman, goodmang@goldmail.etsu.edu
//Created:       April 19, 2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USGeographyChallenge
{
    /// <summary>
    /// The driver class for the USGeographyChallenge namespace
    /// </summary>
    static class GeoFormDriver
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());
            Application.Run(new GeoChallengeForm());
        }
    }
}
