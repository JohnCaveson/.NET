//Project:       Project 1
//Filename:      Words.cs
//Description:   Stores a collection of DistinctWords and alphabetizes them
//Course:        CSCI2210-001 Data Structures
//Author:        Greer Goodman, goodmang@goldmail.etsu.edu
//Created:       February 26, 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    /// <summary>
    /// Stores a collection of DistinctWords and alphabetizes them
    /// </summary>
    public class Words
    {
        public static List<DistinctWord> words { get; private set; }    //list of DistinctWords
        public int count { get; set; }                          //number of items in above list

        /// <summary>
        /// Default constructor
        /// </summary>
        public Words()
        {
            words = new List<DistinctWord>();
        }//Words()

        /// <summary>
        /// Paramaterized constructor
        /// </summary>
        /// <param name="t">Text file to be split into DistinctWords</param>
        public Words(Text t)
        {
            words = new List<DistinctWord>();
            List<String> tokens = new List<String>();
            tokens = t.GetTokens();

            foreach (string token in tokens)
            {
                words.Add(new DistinctWord(token));
            }//foreach

            Alphabetize();
        }//Words(Text)

        /// <summary>
        /// Alphabetizes all the DistinctWords in words
        /// </summary>
        private static void Alphabetize()
        {
            DistinctWord temp;      //holds latest (alphabetically) distinctword found
            int prevIndex;          //holds index location of the above

            //remove dupes
            for (int j = words.Count; j > 0; j--)
            {
                temp = new DistinctWord(words[j-1]);
                for (int i = 0; i < j; i++)
                {
                    if (temp.Equals(words[i]) && words.IndexOf(temp) != j-1) //Word found is the same word, different indexes
                    {
                        words[j-1].count++;           //DistinctWord now has count of 2
                        words.Remove(words[i]);     //Duplicate word removed
                        i--;                        //i searches this index again next loop (since a new word has moved here)
                        j--;                        //j searches one less index total
                    }//else if
                }//for
            }//for

            //aplhabetize tokens
            for (int j = words.Count; j > 0; j--)
            {
                temp = new DistinctWord(words[0]);
                prevIndex = 0;
                for (int i = 0; i < j; i++)
                {
                    if (temp.CompareTo(words[i]) > 0)
                    {
                        temp = new DistinctWord(words[i]);
                        prevIndex = i;
                    }//if
                }//for
                words.Remove(words[prevIndex]);
                words.Add(temp);
            }//for
        }//Alphabetize()

        /// <summary>
        /// Displays all the DistinctWords in words, neatly formatted
        /// </summary>
        public void Display()
        {
            Console.WriteLine("\nWord:                       Count:");
            Console.WriteLine("-----                       ------");
            foreach (DistinctWord d in words)
            {
                Console.WriteLine(d.ToString());
            }//foreach
            Console.WriteLine();
        }//Display()

        /// <summary>
        /// Returns a list of words to be put into a textBox
        /// </summary>
        /// <returns> a list of DistinctWords</returns>
        public List<DistinctWord> GetWords()
        {
            return words;
        }//GetWords()

    }//Words
}
