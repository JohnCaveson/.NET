///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  MenuDemo/MenuDemo
//	File Name:         MenuDemoDriver.cs
//	Description:       Demonstrate simple use of the Menu class
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Don Bailes, bailes@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Monday, February 23, 2015
//	Copyright:         Don Bailes, 2015
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using UtilityNamespace;

namespace MenuClassDemo
{
    class MenuDemoDriver
    {
        static void Main (string [ ] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Title = "Menu Demonstration Application";

            Menu menu = new Menu ("Menu Demo");
            menu = menu + "Open a file" + "Edit the file" + "Close the file" + "Quit";

            Choices choice = (Choices) menu.GetChoice ( );
            while (choice != Choices.QUIT)
            {
                switch (choice)
                {
                    case Choices.OPEN:
                        Console.WriteLine ("You selected Open");
                        Console.ReadKey ( );
                        break;

                    case Choices.EDIT:
                        Console.WriteLine ("You selected Edit");
                        Console.ReadKey ( );
                        break;

                    case Choices.CLOSE:
                        Console.WriteLine ("You selected Close");
                        Console.ReadKey ( );
                        break;
                }  // end of switch

                choice = (Choices) menu.GetChoice ( );
            }  // end of while

        }  // end of main
    }
}
