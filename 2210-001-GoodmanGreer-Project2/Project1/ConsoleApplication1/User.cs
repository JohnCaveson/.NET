//Project:       Project 1
//Filename:      User.cs
//Description:   Holds information about a user, formats and ensures correct formatting of information
//Course:        CSCI2210-001 Data Structures
//Author:        Greer Goodman, goodmang@goldmail.etsu.edu
//Created:       February 26, 2016


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Utils
{
    /// <summary>
    /// Holds info on a User, and formats it
    /// </summary>
    public class User
    {
        Regex phonePattern = new Regex(@"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$");
        Regex emailPattern = new Regex(@"([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})");

        public string _name;   //alternate strings used to avoid infinite loops with properties/getters/setters
        public string _phone;  //holds the actual name, phone and email data
        public string _email;

        public string phone         //user's phone number
        {
            get
            {
                return this._phone;
            }//get
            set
            {
                Match match = phonePattern.Match(value);

                if (match.Success)
                {
                    _phone = value;
                }//if
                else
                {
                    
                }//else
            }//set
        }//phone

        public string email             //user's email address
        {
            get
            {
                return this._email;
            }//get
            set
            {
                Match match = emailPattern.Match(value);
                if (match.Success)
                {
                    _email = value;
                }//if
                else
                {
                    
                }//else
            }//set
        }//email

        /// <summary>
        /// constructor
        /// </summary>
        public User()
        {
        }//User()

        /// <summary>
        /// paramaterized constructor
        /// </summary>
        /// <param name="name">user's name</param>
        /// <param name="phone">user's phone number</param>
        /// <param name="email">user's email</param>
        public User(string name, string phone, string email)
        {
            this._name = name;
            this.phone = phone;
            this.email = email;
        }//User(string, string, string)
        
        /// <summary>
        /// To String method to return neatly formatted information
        /// </summary>
        /// <returns>info - string of information</returns>
        public override string ToString()
        {
            string info = "";
            info += "The user's information follows:\n";
            info += "Name: " + this._name + "\n";
            info += "Email: " + this._email + "\n";
            info += "Phone: " + this._phone + "\n";
            return info;
        }//ToString()

        /// <summary>
        /// NameFormat - formats name string from First Last to Last, First
        /// </summary>
        /// <param name="name">name - name to be formatted</param>
        public void NameFormat(string name)
        {
            try
            {
                string[] names = new string[2]; //[0] = first name, [1] = last
                name = name.Trim(' ');
                string delim = (" ");
                names = name.Split(delim.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                this._name = name[1] + " " + name[0];
            }//try
            catch (Exception)
            {
                throw new Exception("Invalid name entered");
            }//catch
        }//NameFormat(string)
    }//User
}
