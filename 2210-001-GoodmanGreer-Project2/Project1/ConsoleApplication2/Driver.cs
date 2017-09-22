//Project:       Project 1
//Filename:      Driver.cs
//Description:   Demonstrates all the classes involved for Project 1
//Course:        CSCI2210-001 Data Structures
//Author:        Jon Hamrick, hamrickj@goldmail.etsu.edu
//Created:       February 20, 2015

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace Project1
{

    /// <summary>
    /// Driver class for Project 1
    /// </summary>
    class Driver
    {
        private static User user = new User();

        [STAThread]
        static void Main(string[] args)
        {
            
            String response;     //holds user's responses
            Text input = new Text();   //holds text input from the keyboard or text file
            bool loop;           //should the program loop again? true if yes, false if no
            
            Welcome();
            CreateUser();

            //Get text, either from keyboard or file
            while (true)
            {
                Console.WriteLine("[1]Enter text from keyboard\n[2]Open a text file to be analyzed\n");
                response = Console.ReadLine();
                if (response == "1") //entering text from keyboard
                {
                    Console.WriteLine("Input the text to be analyzed. Press enter when you have finished typing.\n");
                    response = Console.ReadLine();
                    input.setOriginalText(response);
                    break;
                }//if
                else if (response == "2") //opening text file
                {
                    loop = false;           //valid until proven otherwise
                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.Filter = "text files|*.txt;*.text|all files|*.*";
                    dlg.InitialDirectory = Application.StartupPath;
                    dlg.Title = "Select a text file to import";
                    if (DialogResult.Cancel != dlg.ShowDialog())
                    {
                        try
                        {
                            input = new Text(dlg.FileName);
                        }//try
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            loop=true;      //invalid input, loop again
                        }//catch
                    }
                    else
                        loop = true;    //user cancelled, loop again
                    
                    if(!loop)   //if input was valid
                        break;
                }//else if
                else                   //garbage input
                {
                    Console.WriteLine("You must enter either 1 or 2\n");
                }//else 
            }//while

            loop = true;           //true when the user wants to quit
            while (loop)
            {
                //menu allowing usage of other classes
                Console.WriteLine("What would you like to do with the text entered?");
                Console.WriteLine("[1] Return a list of tokens (Text class)");
                Console.WriteLine("[2] Return an alphabetized list of tokens (Words class)");
                Console.WriteLine("[3] Return the ToString() for the first sentence (Sentence class)");
                Console.WriteLine("[4] Return the ToString() for all sentences (SentenceList class)");
                Console.WriteLine("[5] Return the ToString() for the first paragraph (Paragraph class)");
                Console.WriteLine("[6] Return the ToString() for all paragraphs (ParagraphList class)");
                Console.WriteLine("[7] Tokenize & reconstruct the input with FormatText() (Utility class)");
                Console.WriteLine("[8] Exit program");

                response = Console.ReadLine();

                switch (response)
                {
                    case "1":                   //Print token list
                        input.PrintTokens();
                        break;
                    case "2":                   //Print alphabetized token list
                        Words w = new Words(input);
                        w.Display();
                        break;
                    case "3":                   //Sentence ToString()
                        Sentence s = new Sentence(input, 0);
                        Console.WriteLine("\n" + s.ToString() + "\n");
                        break;
                    case "4":                   //SentenceList
                        SentenceList sl = new SentenceList(input);
                        sl.Display();
                        break;
                    case "5":                   //Paragraph ToString()
                        Paragraph p = new Paragraph(input, 0);
                        Console.WriteLine("\n" + p.ToString() + "\n");
                        break;
                    case "6":                   //ParagraphList
                        ParagraphList pl = new ParagraphList(input);
                        pl.Display();
                        break;
                    case "7":                   //Reformatted input
                        Console.WriteLine(Utility.FormatText(input.GetTokens(), 0, (input.GetTokens().Count - 1), 5, 65));
                        break;
                    case "8":                   //Quit
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again");
                        break;
                }//switch
            }//while

            GoodbyeMessage();
            
        }//Main(string[])
        
        /// <summary>
        /// Displays a brief welcome message
        /// </summary>
        static void Welcome()
        {
            Console.WriteLine("Welcome to Jon Hamrick's CSCI 2200 Project 1.\n");
        }//Welcome()

        /// <summary>
        /// Takes information from the user to create a User object
        /// </summary>
        static void CreateUser()
        {
            string name,    //user's name
                   email,   //user's email address
                   phone;   //user's phone number
            bool valid,
                 loop = true;

            while (loop)
            {
                valid = true;
                Console.WriteLine("What is the name of the user? (first and last)");
                name = Console.ReadLine();

                try
                {
                    user._name = name;
                }//try
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    valid = false;
                }//catch

                if (valid)
                {
                    name = user._name; //re-accepts name after being formatted

                    Console.WriteLine("\nWhat is " + name + "'s phone number? Use the format \"(xxx) xxx-xxxx\"");
                    phone = Console.ReadLine();

                    Console.WriteLine("\nWhat is " + name + "'s email address? ");
                    email = Console.ReadLine();

                    try
                    {
                        user.email = email;
                        user.phone = phone;
                        loop = false;
                    }//try
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message + "\n");
                    }//catch

                    if (!loop)
                        Console.WriteLine("\n\n" + user.ToString());
                }//if
            }//while
        }//CreateUser()    

        /// <summary>
        /// Displays a brief goodbye message
        /// </summary>
        static void GoodbyeMessage()
        {
            Console.WriteLine("Ending session for the following user:\n");
            Console.WriteLine(user.ToString());
            Console.WriteLine("Thanks for using my program!");
            Console.ReadLine();
        }//GoodbyeMessage()
    }//Driver
}//Project1