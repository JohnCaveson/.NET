//Project:       Project 3
//Filename:      BaseConversionDriver.cs
//Description:   Driver for the windows form
//Course:        CSCI2210-001 Data Structures
//Author:        Greer Goodman, goodmang@goldmail.etsu.edu
//Created:       March 27, 2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseConversion
{
    static class BaseConversionDriver
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
