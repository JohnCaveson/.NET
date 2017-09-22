/*
Solution/Project: Project1/Project1
Filename:         Utils.cs
Description:      Utility class for quality of life
Course:           CSCI 2210 - Data Structures
Author:           Greer Goodman, goodmang@goldmail.etsu.edu
Created:          February 17, 2016
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utils
{
    /// <summary>
    /// Driver so that the program can be used
    /// </summary>
    class Driver
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {

        }
    }

    /// <summary>
    /// User class for determining whether or not an Email or Phone number is valid
    /// </summary>
    public class User
    {
        public static string Name { get; set; }//hold the name of the user
        public static string Email { get; set; }//hold the Email of the user
        public static string Phone { get; set; }//hold the phone number of the user
        /// <summary>
        /// Checks the email
        /// </summary>
        /// <returns>True if the email is valid, else returns false</returns>
        public static bool TestEmail()
        {
            Regex pattern = new Regex(@"([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})");
            Match emailMatch = pattern.Match(Email);
            bool mail = false;
            if (emailMatch.Success)
            {
                mail = true;
                return mail;
            }//end if
            else
            {
                return mail;
            }//end else
        }//end TestEmail()

        /// <summary>
        /// Checks to see if the phone number is valid
        /// </summary>
        /// <returns>True if the phone number is valid, else returns false</returns>
        public static bool TestPhone()
        {
            Regex pat = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
            Match phoneMatch = pat.Match(Phone);
            bool phone = false;
            if (phoneMatch.Success)
            {
                phone = true;
                return phone;
            }//end if
            else
            {
                return phone;
            }//end else
        }//end TestPhone()
    }//end User

    /// <summary>
    /// Houses the quality of life methods
    /// </summary>
    public static class Utility
    {
        ///<summary>
        /// Tokenize method which will split up a string input into separate tokens (i.e. words and symbols)
        /// Will not, however include spaces
        /// </summary>
        /// <param name="input">String to be split up</param>
        /// <returns>A list of strings for manipulation</returns>
        public static List<string> Tokenize(string strIn)
        {
            int var = 0;
            var = strIn.IndexOfAny(@"(`~!@#$%^&*()-_+[{]}|\':;?/>.<, )".ToCharArray());

            string temp = strIn.Substring(0);
            string token;
            List<string> tempList = new List<string>();

            if (var == -1)
            {
                tempList.Add(temp);
                return tempList;
            }//end if
            else
            {
                while (temp.Length > 0 && var >= 0)
                {
                    if (var == 0)
                    {
                        var = 1;
                    }//end if

                    token = temp.Substring(0, var);
                    if (!(token.Contains(" ")))
                    {
                        tempList.Add(token);
                    }//end if
                    else
                    {

                    }//end else
                    temp = temp.Substring(var);
                    var = temp.IndexOfAny(@"(`~!@#$%^&*()-_+[{]}|\':;?/>.<, )".ToCharArray());
                    temp.Trim();
                }//end while
                return tempList;
            }//end else
        }//end Tokenize(string)
    }//end Utility
}//end Utils

