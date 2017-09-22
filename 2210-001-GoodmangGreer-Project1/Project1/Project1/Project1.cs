/*
Solution/Project: Project1/Project1
Filename:         Project1.cs
Description:      Create a list of sentences and distinct words for manipulation
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
using Utils;
using UtilityNamespace;
using System.Windows.Forms;

namespace Project1
{
    /// <summary>
    /// Driver class used in the Project1 namespace
    /// </summary>
    public class Driver
    {
        public static string FileName;
        [STAThread]
        public static void Main(string[] args)
        {
            //user input for name, email address, and phone number as well as validation
            Console.WriteLine("Hello! Welcome to my first project for my Data Structures Class.");
            Console.WriteLine("My name is Greer Goodman.");
            Console.WriteLine("What is your name?\n");
            User.Name = Console.ReadLine();
            Console.WriteLine("What is your email address?\n");
            User.Email = Console.ReadLine();
            Console.WriteLine("And last but not least, what is your phone number?\n");
            User.Phone = Console.ReadLine();
            bool check = false;//checks to see if the user input valid information
            while (check == false)
            {
                if (User.TestEmail() == true && User.TestPhone() == true)
                {
                    check = true;
                }//end if
                else if (User.TestEmail() == false || User.TestPhone() == false)
                {
                    Console.WriteLine("One of the fields you entered is incorrect. Please fix it.");
                    Console.WriteLine("What is your email address?\n");
                    User.Email = Console.ReadLine();
                    Console.WriteLine("And last but not least, what is your phone number?\n");
                    User.Phone = Console.ReadLine();
                }//end if
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine(); 
            }//end while

            //Menu creation and implementation
            UtilityNamespace.Menu NewMenu = new UtilityNamespace.Menu("Data Structures Project 1 Menu");
            NewMenu += "1. Open a file and tokenize it";
            NewMenu += "2. Get Distinct Words";
            NewMenu += "3. Get a list of Distinct Words";
            NewMenu += "4. Get a Sentence";
            NewMenu += "5. Get a list of Sentences";
            NewMenu += "6. Get a Paragraph";
            NewMenu += "7. Get a list of Paragraphs";
            NewMenu += "8. Exit";

            int choice = 0;//used for switch choosing.
            Text NewText; //varibale created here so other switches can use it
            bool OneFirst = false; // checks to see if option one has been chosen yet

            while (choice != 8)
            {
                NewMenu.Display();
                choice = NewMenu.GetChoice();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Please select a text file to work with.");
                        OpenFileDialog OpenDlg = new OpenFileDialog();
                        OpenDlg.Filter = "text files|*.txt;*.text|all files|*.*";
                        OpenDlg.InitialDirectory = "Project1/TextFiles";
                        OpenDlg.Title = "Select a file with which you would like to work with.";
                        if (DialogResult.Cancel != OpenDlg.ShowDialog())
                        {
                            FileName = OpenDlg.FileName;
                        }
                        NewText = new Text();
                        OneFirst = true;
                        break;
                    case 2:
                        if (OneFirst != false)
                        {
                            DistinctWord dw = new DistinctWord();
                            Console.WriteLine(dw.ToString());
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please press enter and choose option one to continue.");
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        if (OneFirst != false)
                        {
                            Words NewWord = new Words();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please press enter and choose option one to continue.");
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        if (OneFirst != false)
                        {
                            Sentence Sent = new Sentence();
                            Console.WriteLine(Sent.ToString());
                            break; 
                        }
                        else
                        {
                            Console.WriteLine("Please press enter and choose option one to continue.");
                            Console.ReadLine();
                            break;
                        }
                    case 5:
                        if (OneFirst != false)
                        {
                            SentenceList SentList = new SentenceList();
                            SentenceList.Display();
                            break; 
                        }
                        else
                        {
                            Console.WriteLine("Please press enter and choose option one to continue.");
                            Console.ReadLine();
                            break;
                        }
                    case 6:
                        if (OneFirst != false)
                        {
                            Paragraph Para = new Paragraph();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please press enter and choose option one to continue.");
                            Console.ReadLine();
                            break;
                        }
                    case 7:
                        if (OneFirst != false)
                        {
                            ParagraphList ParaList = new ParagraphList();
                            ParagraphList.Display();
                            break; 
                        }
                        else
                        {
                            Console.WriteLine("Please press enter and choose option one to continue.");
                            Console.ReadLine();
                            break;
                        }
                    case 8:
                        Console.WriteLine("Thank{0} ({1}, {2}) for using my program. I was completely unprepared to turn this project in. Have a nice day. ",User.Name, User.Email, User.Phone);
                        Console.ReadLine();
                        Environment.Exit(0);
                        break;
                }//end switch         
            }//end while
        }//end main(string[])
    }//end Driver
    /// <summary>
    /// Text class used for reading the text file
    /// </summary>
    public class Text
    {
        public string TextHold { get; set; }//public property for holding lines of the text file
        public List<string> TokenList { get; set; }//list used to hold the divided up lines
        /// <summary>
        /// Default constructor
        /// </summary>
        public Text()
        {
            StreamReader rdr = new StreamReader(Driver.FileName);
            while (rdr.Peek() != -1)
            {
                TextHold += rdr.ReadLine();

            }//end while
            TokenList = Utility.Tokenize(TextHold);
            rdr.Close();
        }//end Text()   
                       
        /// <summary>
        /// parameterized constructor
        /// </summary>
        /// <param name="PathName">Path of the file of text to be manipulated</param>
        public Text(string PathName)
        {
            StreamReader rdr = new StreamReader(PathName);
            while (rdr.Peek() != -1)
            {
                TextHold += rdr.ReadLine();
            }//end while
            TokenList = Utility.Tokenize(TextHold);
            rdr.Close();
        }//end Text(string)
    }//end Text

    /// <summary>
    /// Class used for determining whether a distinct word occurs in the text file
    /// </summary>
    class DistinctWord : IEquatable<string>, IComparable<string>
    {
        public int Counter { get; set; }//counts how many times a word appears in the text file
        public string WordToMatch { get; set; }//signifies the word to be matched 
        /// <summary>
        /// default constructor
        /// </summary>
        public DistinctWord()
        {
            Text PathText = new Text();
            List<DistinctWord> WordList = new List<DistinctWord>();
            foreach (string StrS in PathText.TokenList)
            {
                WordToMatch = StrS;
                foreach (string match in PathText.TokenList)
                {
                    if(WordToMatch.ToLower().CompareTo(match.ToLower()) == 0)
                    {
                        Counter++; 
                    }//end if
                }//end foreach
            }//end foreach
        }//end DistinctWord()
        /// <summary>
        /// parameterized constructor
        /// </summary>
        /// <param name="ToMatch">string to be matched against</param>
        public DistinctWord(string ToMatch)
        {
            WordToMatch = ToMatch.ToLower();
            Text PathText = new Text();
            foreach (string match in PathText.TokenList)
            {
                if(WordToMatch.CompareTo(match.ToLower()) == 0)
                {
                    Counter++;
                }//end if
            }//end foreach
        }//end DistinctWord(string)
        /// <summary>
        /// overridden ToString method for the DistinctWord class
        /// </summary>
        /// <returns>Formatted DistinctWord with the count </returns>
        public override string ToString()
        {
            string temp = "";
            temp = WordToMatch + "\t\t" + Counter;
            return temp;
        }//end ToString()
        /// <summary>
        /// implemented Equals method
        /// </summary>
        /// <param name="other">String to be compared</param>
        /// <returns>Capability to be called</returns>
        public bool Equals(string other)
        {
            throw new NotImplementedException();
        }//end Equals(string)
        /// <summary>
        /// implemented CompareTo method
        /// </summary>
        /// <param name="other">String to be compared</param>
        /// <returns>Capability to be called</returns>
        public int CompareTo(string other)
        {
            throw new NotImplementedException();
        }//end CompareTo(string)
    }//end DistinctWord

    /// <summary>
    /// Class for holding the formatted distinct words in a list
    /// </summary>
    class Words
    {
        public static List<DistinctWord> DistinctList { get; private set; }//list for the DistinctWord objects
        readonly int Count;//Count for each word
        /// <summary>
        /// default constructor
        /// </summary>
        public Words()
        {
            DistinctWord dw;
            DistinctList = new List<DistinctWord>();
            Text PathText = new Text();

            for (int i = 0; i < PathText.TokenList.Count; i++)
            {
                if (PathText.TokenList[i].Contains("\\w"))
                {
                    dw = new DistinctWord(PathText.TokenList[i]);
                    DistinctList.Add(dw);
                    Count = dw.Counter;
                }//end if
            }//end for
            Display();
         }//end Words()
        /// <summary>
        /// paramterized constructor
        /// </summary>
        /// <param name="obj">Text object to be manipulated</param>
        public Words(Text obj)
        {
            DistinctWord dw;
            for (int i = 0; i < obj.TokenList.Count; i++)
            {
                dw = new DistinctWord(obj.TokenList[i]);
                DistinctList.Add(dw);
            }
        }//end Words(Text)
        /// <summary>
        /// Method used to display a formatted list of words
        /// </summary>
        public static void Display()
        {
            foreach (DistinctWord match in DistinctList)
            {
                Console.WriteLine(match.ToString());
            }
            
        }//end Display
    }//end Words

    /// <summary>
    /// Class used to tokenize the text file into individual sentences.
    /// </summary>
    class Sentence
    {
        public int SentLength { get; private set; }//Length of a sentence
        public decimal AvgWordLength { get; private set; }//Average length of a sentence based on the words in it
        public int FirstToken { get; private set; }//First index at which the extraction should start
        public int FinalToken { get; private set; }//Final index of the extraction
      
        /// <summary>
        /// Default constructor
        /// </summary>
        public Sentence()
        {
            Text PathText = new Text();
            FirstToken = 0;
            Regex r = new Regex(@"(\W)");
            try
            {
                for(int i = 0; i < PathText.TokenList.Count; i++)
                {
                    if (PathText.TokenList[i].Equals(".") || PathText.TokenList[i].Equals("?") || PathText.TokenList[i].Equals("!"))
                    {
                        FinalToken = i;
                        break;
                    }//end if
                    else if (!(r.IsMatch(PathText.TokenList[i])))
                    {
                        AvgWordLength += PathText.TokenList[i].Length;
                        SentLength++;
                    }//end if
                    else if (r.IsMatch(PathText.TokenList[i]))
                    {

                    }//end if
                }//end for
            }//end try
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("An error has occurred.");
            }//end catch
            AvgWordLength = AvgWordLength / SentLength;
        }//end Sentence()

        public Sentence(Text List, int Extract)
        {
            Text PathText = new Text();
            FirstToken = Extract;
            Regex r = new Regex(@"(\W)");
            try
            {
                for (int i = FirstToken; i < PathText.TokenList.Count; i++)
                {
                    if (List.TokenList[i].Contains(".") || List.TokenList[i].Contains("?") || List.TokenList[i].Contains("!"))
                    {
                        FinalToken = i;
                        break;
                    }//end if
                    else if (!(r.IsMatch(List.TokenList[i])))
                    {
                        AvgWordLength += List.TokenList[i].Length;
                        SentLength++;
                    }//end if
                    else if (r.IsMatch(List.TokenList[i]))
                    {

                    }//end if
                }//end for
                AvgWordLength = AvgWordLength / SentLength;
            }//end try
            catch (Exception e)
            {
                
                Console.WriteLine("This class is unfinished. ");
            }//end catch
             
        }//end Sentence(Text,int)
        /// <summary>
        /// Overridden ToString method for the Sentence Class
        /// </summary>
        /// <returns>Formatted sentence with count and average word length</returns>
        public override string ToString()
        {
            Text PathText = new Text();
            string temp = "";
            Regex r = new Regex(@"(\W)");
            for (int i = 0; i < PathText.TokenList.Count; i++)
            {
                if (PathText.TokenList[i].Equals(".") || PathText.TokenList[i].Equals("?") || PathText.TokenList[i].Equals("!"))
                {
                    temp += PathText.TokenList[i];
                    break;
                }//end if
                else if (!(r.IsMatch(PathText.TokenList[i])))
                {
                    if (r.IsMatch(PathText.TokenList[i+1]))
                    {
                        temp += PathText.TokenList[i];
                    }//end if
                    else
                    {
                        temp += PathText.TokenList[i] + " ";
                    }//end else
                }
                else if (r.IsMatch(PathText.TokenList[i]))
                {
                    temp += PathText.TokenList[i]+" ";
                }//end if
            }//end for
            temp += "\nAverage Word Length: " + AvgWordLength + "\t\tSentence Length: " + SentLength;
            return temp;
        } //end for  

    }//end ToString()
    /// <summary>
    /// SentenceClass used for formatting sentences into a list for manipulation
    /// </summary>
    class SentenceList
    {
        public static List<Sentence> SentList { get; private set; }//List for holding Sentence Objects
        public static int SentNum { get; private set; }// Number of sentences in the list
        public static decimal AvgWordInSent { get; private set; }// Avg number of words in each sentence in the list
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SentenceList()
        {
            try
            {
                Text PathText = new Text();
                SentList = new List<Sentence>();
                Sentence Sent;
                int Count = 0;
                int i = 0;
                while (i == 0)
                {
                    Sent = new Sentence(PathText, Count);
                    SentList.Add(Sent);
                    SentNum++;
                    AvgWordInSent += Sent.AvgWordLength;
                    Count = Sent.FinalToken;
                    i = 1;//ends the loop
                }//end while
                AvgWordInSent = AvgWordInSent / SentNum;
            }
            catch (Exception e)
            {
                Console.WriteLine("This class is unfinished. ");
            }
        }//end SentenceList()
        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="obj">Text object used when putting sentences into a list</param>
        public SentenceList(Text obj)
        {

        }//end SentenceList(Text)
        /// <summary>
        /// Method used to display a formatted list with List length and average sentence length 
        /// </summary>
        public static void Display()
        {
            string Display = "";
            foreach (Sentence match in SentList)
            {

                Display += match.ToString();
            }
            Display += "\nAverage number of words in all sentences: " + AvgWordInSent + "\t\tNumber of sentences in the list: " + SentNum;
            Console.WriteLine(Display);
        }//end Display()
    }//end SentenceList

    /// <summary>
    /// Class for tokenizing the Paragraphs into a list
    /// </summary>
    class Paragraph
    {
        public int SentNumber { get; private set; }//number of sentences in the paragraph
        public int WordNumber { get; private set; }//number of words in the paragraph
        public int AvgWordLengthInPara { get; private set; }//average sentence length in the paragraph
        public int FirstToken { get; private set; }//index of first token in paragraph
        public int FinalToken { get; private set; }//index of the final token in the paragraph
        /// <summary>
        /// default constructor
        /// </summary>
        public Paragraph()
        {
            
        }//end Paragraph()
        /// <summary>
        /// parameterized constructor
        /// </summary>
        /// <param name="obj">The text obj to be worked with</param>
        /// <param name="Extract">starting extraction point in the paragraph</param>
        public Paragraph(Text obj, string Extract)
        {

        }
    }//end Paragraph
    /// <summary>
    /// Class used to put the tokenized paragraphs into a list
    /// </summary>
    class ParagraphList
    {
        public List<Paragraph> ParaList { get; private set; }//list of paragraphs
        public int SentInAllPara { get; private set; }//number of words in all paragraphs
        public decimal AvgWordInAllPara { get; private set; }//Average number of words in all paragraphs
        /// <summary>
        /// Default constructor
        /// </summary>
        public ParagraphList()
        {

        }//end Paragraph()
        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="obj">Text object to be worked with</param>
        public ParagraphList(Text obj)
        {

        }//end ParagraphList(Text)
        /// <summary>
        /// Displays the contents of the paragraph list
        /// </summary>
        public static void Display()
        {
            Console.WriteLine("This class doesn't do anything.");
        }//end Display()
    }//end ParagraphList
    /// <summary>
    /// Enumerated class for choices
    /// </summary>
    enum Choices
    {
         OPEN = 1, DisinctWord, Words, Sentence, SentenceList, Paragraph, ParagraphList
    }
}
