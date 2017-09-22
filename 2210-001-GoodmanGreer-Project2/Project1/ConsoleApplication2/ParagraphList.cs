//Project:       Project 1
//Filename:      ParagraphList.cs
//Description:   Stores a list of Paragraph objects & displays them neatly
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
    /// Stores a list of Paragraph objects & displays them neatly
    /// </summary>
    public class ParagraphList
    {
        public List<Paragraph> Paragraphs = new List<Paragraph>();  //the list of paragraphs
        public double NumParagraphs;                                //number of paragraphs contained
        public double AvgWordCount;                                 //avg word count in each paragraph

        /// <summary>
        /// Default constructor
        /// </summary>
        public ParagraphList()
        { }//ParagraphList()

        /// <summary>
        /// Paramaterized constructor
        /// </summary>
        /// <param name="t">Text object to pull Paragraphs from</param>
        public ParagraphList(Text t)
        {
            List<string> tokens = new List<string>(t.GetTokens());
            int lastToken, firstToken;  //token the search starts from & last token in the paragraph
            int result;                 //location of first \n or \r found
            double total = 0;           //for avg word count

            //add first paragraph -- no need to worry about location
            Paragraphs.Add(new Paragraph(t, 0));
            NumParagraphs = 1;
            firstToken = 0;

            while (true)
            { 
                //determine end of paragraph
                while (true)
                {
                    result = tokens.IndexOf("\n", firstToken);
                    if ((tokens.IndexOf("\r", firstToken) < result && tokens.IndexOf("\r", firstToken) != -1) || result == -1)
                        result = tokens.IndexOf("\r", firstToken);

                    if (result + 1 >= tokens.Count)     //end of file
                    {
                        lastToken = tokens.Count - 1;
                        break;
                    }//if
                    else if (tokens[result].Equals(tokens[result + 1]))     //two consecutive newlines or returns found
                    {
                        lastToken = result;
                        break;
                    }//else if
                    else
                        firstToken = result + 1;
                }//while

                if (lastToken != tokens.Count - 1)
                {
                    Paragraphs.Add(new Paragraph(t, lastToken + 1));    //add the NEXT paragraph to the list
                    NumParagraphs++;
                    firstToken = lastToken +1;
                }//if
                else                       //Paragraph found is last one -- already added on previous loop
                    break; 
            }//while

            //determine avg word count
            for (int i = 0; i<NumParagraphs; i++)
            {
                total += Paragraphs[i].NumWords;
            }//for
            AvgWordCount = total / NumParagraphs;
        }//ParagraphList(Text)

        /// <summary>
        /// Displays ToString() for each Paragraph contained
        /// </summary>
        public void Display()
        {
            Console.WriteLine("Printing ToString() for each Paragraph in ParagraphList\n");
            for (int i=0; i<NumParagraphs; i++)
            {
                Console.WriteLine("Paragraph {0}:", (i+1));
                Console.WriteLine(Paragraphs[i].ToString());
                Console.WriteLine("\n");
            }//for
            Console.WriteLine("Number of paragraphs: {0}\t\tAverage word count:{1}\n\n", NumParagraphs, AvgWordCount);
        }//Display()
    }//ParagraphList
}