//Project:       Project 1
//Filename:      Utility.cs
//Description:   Contains various methods designed to be useful in multiple assignments
//Course:        CSCI2210-001 Data Structures
//Author:        Greer Goodman, goodmang@goldmail.etsu.edu
//Created:       February 26, 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    /// <summary>
    /// Basic utilities to be used in multiple projects
    /// </summary>
    public class Utility
    {
        public Utility()
        {
        }

        #region Tokenize
        /// <summary>
        /// Splits a string into a set of tokens defined by a set of delimiters
        /// </summary>
        /// <param name="line">String to be split</param>
        /// <param name="delims">Delimiters to determine splitting</param>
        /// <returns> terms - all words/characters found as a result of splitting, stored as a List of strings

            
        public static List<String> Tokenize(string line, string delims)
        {
            int location;                   //holds index of first delim found
            int blankLoc;                   //index of first blank space/tab/newline/return found
            string blanks = " \t";      //characters to be trimmed
            List<String> terms = new List<String>();        //list of tokens being generated
            bool blankRemoved;              //was a blank removed this loop?

            if (!String.IsNullOrEmpty(line))
            {
                int i = -1;
                while (true)
                {
                    i += 1;
                    blankRemoved = false;       //no blanks have been removed yet

                    //Remove leading blanks/tabs
                    blankLoc = line.IndexOfAny(blanks.ToCharArray());
                    if (blankLoc == 0)          //first character is a blank
                    {
                        line = line.Trim(' ');
                        line = line.Trim('\t');
                        blankRemoved = true;
                    }//if

                    if (!blankRemoved)  //only runs if no blank was removed -- allows for multiple blanks in a row
                    {
                        location = line.IndexOfAny(delims.ToCharArray()); //find first delim
                        if (location == 0) //first character is a delim (punctuation, if spaces trimmed properly)
                        {

                            terms.Add(line.Substring(0, 1));
                            line = line.Remove(0, 1);
                        }//if
                        else if (location > 0) //line starts with a word, location points to end of word
                        {
                            terms.Add(line.Substring(0, location));
                            line = line.Remove(0, location);
                        }//else if
                        else  //end of the line
                        {
                            if (line != "")
                                terms.Add(line);
                            break;
                        }//else 
                    }//if
                }//while
            }//if
            return terms;
        }//Tokenize (string, string)
        
        #endregion

        /// <summary>
        /// Takes a collection of split tokens and tries to recreate the original string. Allows custom entry 
        /// and exit points. Allows choice of margin ending. Note that there is a minimum of 20 columns allowed
        /// (to provide room for larger words, and prevent an infinite loop) -- any lower number is increased 
        /// to 20 automatically.
        /// </summary>
        /// <param name="tokens">list of tokens in the string</param>
        /// <param name="start">token to begin extraction on</param>
        /// <param name="end">token to end extraction on</param>
        /// <param name="leftCol">column location of leftmost boundary</param>
        /// <param name="rightCol">column location of rightmost boundary</param>
        /// <returns> OriginalText - exactly what it says on the box
        public static String FormatText(List<String> tokens, int start, int end, int leftCol, int rightCol)
        {
            String originalText = "";
            int currentCol = 0;                 //column currently being printed to

            if (rightCol - leftCol < 20)        //prevents garbage inputs -- method would go on forever if a word
                rightCol = 0;                 //too large appeared

            for (int j = 0; j < rightCol; j++)  //add spaces to start at left column for first line
            {
                originalText += " ";
                currentCol++;
            }

            for(int i = start; i <= end; i++)
            {

                if (i != start             //add space if the loop is not on the first token
                    && i != end            //or the last one (., ? or !)
                    && tokens[i] != ","         //and it's not one of these punctuation marks
                    && tokens[i] != "."
                    && tokens[i] != "?"
                    && tokens[i] != "!"
                    && tokens[i] != "-"
                    && tokens[i] != ";"
                    && tokens[i] != ":"
                    && tokens[i] != ")"
                    && tokens[i] != "]"
                    && tokens[i] != "}"
                    && tokens[i] != "/"
                    && tokens[i] != "\\"
                    && tokens[i] != "\n"
                    && tokens[i] != "\r"
                    && tokens[i] != "\t"
                    && tokens[i - 1] != "-"     //and it doesn't follow any of these
                    && tokens[i - 1] != "("
                    && tokens[i - 1] != "["
                    && tokens[i - 1] != "{"
                    && tokens[i - 1] != "$")
                    originalText += " ";

                if (currentCol + tokens[i].Length <= rightCol)  //word doesn't go past right column
                {
                    originalText += tokens[i];
                    if (tokens[i].Equals("\n") || tokens[i].Equals("\r"))
                    {
                        currentCol = 0;                         //reset current column tracker
                        for (int j = 0; j < (leftCol +3); j++)      //set up left column -- adds slight indent for new paragraph
                        {
                            originalText += " ";
                            currentCol++;
                        }//for
                    }//if
                    else
                        currentCol += tokens[i].Length;
                }//if
                else
                {
                    originalText += "\n";                   //next line
                    currentCol = 0;                         //reset current column tracker
                    for (int j = 0; j < leftCol; j++ )      //set up left column
                    {
                        originalText += " ";
                        currentCol++;
                    }//if
                    originalText += tokens[i];
                    if (tokens[i] == ("\n") || tokens[i] == ("\r"))
                    {
                        currentCol = 0;                         //reset current column tracker
                        for (int j = 0; j < leftCol; j++)      //set up left column
                        {
                            originalText += " ";
                            currentCol++;
                        }//for
                    }//if
                    else
                        currentCol += tokens[i].Length;
                }//else
            }//for

            return originalText;

        }//FormatText(List<String>)
    }//Utility
}//Utils
