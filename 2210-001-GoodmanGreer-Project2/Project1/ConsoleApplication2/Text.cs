//Project:       Project 1
//Filename:      Text.cs
//Description:   Stores a text string, splits it into tokens and stores that as well
//Course:        CSCI2210-001 Data Structures
//Author:        Greer Goodman, goodmang@goldmail.etsu.edu
//Created:       February 26, 2016

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Project1
{
    
    /// <summary>
    /// Stores a text string, splits it into tokens and stores that as well
    /// </summary>
    public class Text
    {
        static string OriginalText = "";       //original text
        static List<String> tokens;            //text split into tokens

        /// <summary>
        /// Default constructor
        /// </summary>
        public Text()
        {}//Text()

        /// <summary>
        /// Paramaterized constructor
        /// </summary>
        /// <param name="filename">location of text file to input text from</param>
        public Text(string filename)
        {
            StreamReader rdr = null;
            string delims = " \",.?!-;:{}()[]$/\\\t\n\r";

            try
            {
                rdr = new StreamReader(filename);

                while (rdr.Peek() != -1)
                {
                    OriginalText += rdr.ReadLine();
                    OriginalText += "\n";
                }//while
            }//try
            catch (Exception e)
            {
              
            }//catch
            finally
            {
                rdr.Close();
            }//finally

            tokens = Utility.Tokenize(OriginalText, delims);

        }//Text(string)

        /// <summary>
        /// setter for OriginalText variable
        /// </summary>
        /// <param name="text">Incoming original text</param>
        public void setOriginalText(string text)
        {
            OriginalText = text;
            
            string delims = @",.?!-;:'{}()[]$/\\\n\t\r";
            tokens = Utility.Tokenize(OriginalText, delims);

        }//setOriginalText(string)

        /// <summary>
        /// Getter for Tokens list
        /// </summary>
        /// <returns> tokens
        public List<String> GetTokens()
        {
            return tokens;
        }//GetTokens()

        /// <summary>
        /// Prints the original text straight to the console
        /// </summary>
        public void PrintOriginalText()
        {
            Console.WriteLine(OriginalText);
        }//PrintOriginalText()

        /// <summary>
        /// Prints a formatted list of tokens straight to the console
        /// </summary>
        public void PrintTokens()
        {
            Console.WriteLine("The list of tokens is as follows:");
            foreach(string token in tokens)
                Console.WriteLine(token);
            Console.WriteLine("\n");
        }//PrintTokens()
    }//Text
}
