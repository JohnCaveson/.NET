//Project:       Project 1
//Filename:      Sentence.cs
//Description:   Stores a sentence and related information
//Course:        CSCI2210-001 Data Structures
//Author:        Greer Goodman, goodmang@goldmail.etsu.edu
//Created:       February 26, 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utils;

namespace Project1
{
    /// <summary>
    /// Stores a sentence and related information
    /// </summary>
    public class Sentence
    {
        public string FullSentence { get; private set; }        //original sentence
        public double WordCount { get; private set; }         //number of words
        public double AvgWordLength { get; private set; }     //average word length in sentence
        public int FirstToken { get; private set; }          //token where sentence begins
        public int LastToken { get; private set; }          //token where sentence ends

        /// <summary>
        /// Default constructor
        /// </summary>
        public Sentence()
        {}//Sentence()

        /// <summary>
        /// Paramaterized constructor
        /// </summary>
        /// <param name="t">Text to pull sentence from</param>
        /// <param name="location">token index where sentence begins</param>
        #region SentCon
            
            public Sentence(Text t, int location)
            {
                Regex r = new Regex(@"(\W)");
                //find end location
                List<string> tokens = new List<string>(t.GetTokens());
                int end = tokens.IndexOf(".", location);  //assume the first . is the end of the sentence
                if ((tokens.IndexOf("?", location) < end && tokens.IndexOf("?", location) != -1) || end == -1) //if there is a ? and it's before the first .
                    end = tokens.IndexOf("?", location);  //first ? is the end of the sentence
                if ((tokens.IndexOf("!", location) < end && tokens.IndexOf("!", location) != -1) || end == -1) //if there is a ! and it's before the first ./?
                    end = tokens.IndexOf("!", location);  //first ! is the end of the sentence

                FirstToken = location;
                if (end != -1)
                    LastToken = end;
                else                      //sentence ends without punctuation
                    LastToken = tokens.Count() - 1;

                //generate sentence
                FullSentence = Utility.FormatText(tokens, FirstToken, LastToken, 0, 0);

                //find word count
                
                WordCount = (LastToken - FirstToken);
                
                for (int i = FirstToken; i < LastToken; i++)
                {
                    if(r.IsMatch(tokens[i]))
                     {
                         WordCount--;
                     }
                }//for

                //find avg word length
                double total = 0;
                for (int i = FirstToken; i < LastToken; i++)
                {
                    total += tokens[i].Length;
                }//for
                AvgWordLength = total / WordCount;

            }//Sentence(Text, int)
            #endregion

            /// <summary>
            /// Returns the sentence, plus word count and avg word length, neatly formatted
            /// </summary>
            /// <returns> string of sentence, word count, avg length
        public override string ToString()
        {
            string sentence = "";
            sentence += this.FullSentence;
            sentence += "\n\n";
            sentence += "Word count: " + WordCount;
            sentence += "\t\t";
            sentence += "Avg word length: " + AvgWordLength;

            return sentence;
        }//ToString()
    }//Sentence
}
