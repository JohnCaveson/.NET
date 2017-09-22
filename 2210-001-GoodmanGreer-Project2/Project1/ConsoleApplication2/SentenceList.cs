//Project:       Project 1
//Filename:      SentenceList.cs
//Description:   Creates & stores a list of sentences based on a text object
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
    ///  Creates & stores a list of sentences based on a text object
    /// </summary>
    public class SentenceList
    {
        public List<Sentence> Sentences { get; private set; }   //list of sentences
        public int NumSentences { get; private set; }           //number of sentences contained
        public double AvgWordCount { get; private set; }        //average word count in sentence list

        /// <summary>
        /// Default constructor
        /// </summary>
        public SentenceList()
        {}//SentenceList()

        /// <summary>
        /// Paramaterized constructor
        /// </summary>
        /// <param name="t">Text to be split into sentences</param>
        public SentenceList(Text t)
        {
            int location;                           //stores location of punctuation mark
            List<string> tokens = t.GetTokens();    //tokens
            Sentences = new List<Sentence>();       //initialize sentence list
            int nextSent = 0;                       //location of start of next sentence
            double total = 0;                       //combined amount of words in list, used for avg

            //add first sentence - no need to worry about start location, it's always 0
            Sentences.Add(new Sentence(t, 0));
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

                if (location != -1 
                        && nextSent < tokens.Count())
                {
                    Sentences.Add(new Sentence(t, (location + 1)));
                    NumSentences++;
                }//if
                else
                    break;
            }//while

            //find avg word count
            foreach (Sentence s in Sentences)
            {
                total += s.WordCount;
            }//foreach
            AvgWordCount = total / NumSentences;
        }//SentenceList(Text)

        /// <summary>
        /// Display info about all sentences contained in the list
        /// </summary>
        public void Display()
        {
            Console.WriteLine("Printing ToString() for each sentence in SentenceList:\n");
            for (int i = 0; i < NumSentences; i++)
            {
                Console.Write("Sentence " + (i+1) + ": ");
                Console.WriteLine(Sentences[i].ToString());
                Console.WriteLine("\n");
            }//for
            Console.WriteLine("There are {0} sentences in the list, averaging {1} words. \n", NumSentences, AvgWordCount);
        }//Display()
    }//SentenceList
}
