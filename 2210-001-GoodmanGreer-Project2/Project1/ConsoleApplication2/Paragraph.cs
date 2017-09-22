//Project:       Project 1
//Filename:      Paragraph.cs
//Description:   Generates & stores a paragraph and information about it
//Course:        CSCI2210-001 Data Structures
//Author:        Greer Goodman
//Created:       February 26, 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Project1
{
    /// <summary>
    /// Generates & stores a paragraph and information about it
    /// </summary>
    public class Paragraph
    {
        public int NumSentences { get; private set; }       //number of sentences
        public int NumWords { get; private set; }       //number of words
        public double AvgSentenceWordCount { get; private set; }    //average sentence word count
        public int FirstToken { get; private set; }     //token where paragraph starts
        public int LastToken { get; private set; }      //token where paragraph ends
        public string OriginalParagraph { get; private set; }   //original paragraph stored as string

        /// <summary>
        /// Default constructor
        /// </summary>
        public Paragraph()
        {}//Paragraph()

        /// <summary>
        /// Paramterized constructor
        /// </summary>
        /// <param name="t">Text to pull paragraph from</param>
        /// <param name="location">Location to begin extracting paragraph</param>
        public Paragraph(Text t, int location)
        {
            int result;         //location of \n or \r found
            double total = 0;   //used for average calculation
            List<string> tokens = new List<String>(t.GetTokens());  //token list

            FirstToken = location;

            //determine end of paragraph
            while (true)
            {
                result = tokens.IndexOf("\n", location);
                if ((tokens.IndexOf("\r", location) < result && tokens.IndexOf("\r", location) != -1) || result == -1)
                    result = tokens.IndexOf("\r", location);

                if (result + 1 >= tokens.Count)     //end of file
                {
                    LastToken = tokens.Count - 1;
                    break;
                }//if
                else if (tokens[result].Equals(tokens[result + 1]))     //two consecutive newlines or returns found
                {
                    LastToken = result;
                    break;
                }//else if
                else
                    location = result + 1;
            }//while

            NumWords = LastToken - FirstToken;

            //find sentence locations
            List<Sentence> sentList = new List<Sentence>();
            int nextSent = 0;

            //add first sentence - no need to worry about start location, it's always 0
            sentList.Add(new Sentence(t, FirstToken));
            NumSentences = 1;

            while (true)
            {
                //locate nearest punctuation mark
                location = tokens.IndexOf(".", nextSent);
                if ((location > tokens.IndexOf("?", nextSent) && tokens.IndexOf("?", nextSent) != -1) || location == -1)
                    location = tokens.IndexOf("?", nextSent);
                if ((location > tokens.IndexOf("!", nextSent) && tokens.IndexOf("!", nextSent) != -1) || location == -1)
                    location = tokens.IndexOf("!", nextSent);
                nextSent = location + 1;

                if (location != -1 && nextSent < LastToken)
                {
                    sentList.Add(new Sentence(t, location + 1));
                    NumSentences++;
                }//if
                else
                    break;
            }//while

            foreach (Sentence s in sentList)
            {
                total += s.WordCount;
            }//foreach
            AvgSentenceWordCount = total / NumSentences;

            //generate text paragraph
            OriginalParagraph = Utility.FormatText(tokens, FirstToken, LastToken, 0, 0);
        }//Paragraph(Text)

        /// <summary>
        /// Returns formatted information about the paragraph
        /// </summary>
        /// <returns> string paragraph & information
        public override string ToString()
        {
            string str = "";
            str += OriginalParagraph;
            str += "\n";
            str += "Total sentences: " + NumSentences;
            str += "\t\t";
            str += "Avg sentence length: " + AvgSentenceWordCount;

            return str;
        }//ToString()
    }//Paragraph
}
