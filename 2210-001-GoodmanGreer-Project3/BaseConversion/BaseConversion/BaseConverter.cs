//Project:       Project 3
//Filename:      BaseConverter.cs
//Description:   Contains various methods for changing from and to Decimal with places of precision.
//Course:        CSCI2210-001 Data Structures
//Author:        Greer Goodman, goodmang@goldmail.etsu.edu
//Created:       March 27, 2016
using System.Collections.Generic;

namespace BaseConversion
{
    /// <summary>
    /// Class used in the conversion to/from decimal
    /// </summary>
    class BaseConverter
    {
        public static Stack<object> StkI { get; set; } 
        /// <summary>
        /// Method to Change a number to a decimal
        /// </summary>
        /// <param name="ToDecimal">String to be parsed</param>
        /// <returns></returns>
        public static int ToDecimal(string ToDecimal, int BaseValue)
        {
            int result = 0;             //converted int
            int i = 0;                 //temporary loop int for conversion
            int remDigits;            //number of digits remaining to be checked
            int baseExp;             //exponent, such as, for 16^2 will hold 256
            char[] digits = ToDecimal.ToCharArray();

            remDigits = digits.Length;
            for (int j = 0; j < digits.Length; j++)
            {
                if (remDigits == 1)
                    baseExp = 1;
                else
                {
                    baseExp = BaseValue;
                    for (int k = 2; k < remDigits; k++)
                    {
                        baseExp *= BaseValue;
                    }//for
                }//if

                try
                {
                    i = int.Parse(digits[j].ToString());
                }//try
                catch (System.FormatException)
                {
                    switch (digits[j])
                    {
                        case 'A':
                            i = 10;
                            break;
                        case 'B':
                            i = 11;
                            break;
                        case 'C':
                            i = 12;
                            break;
                        case 'D':
                            i = 13;
                            break;
                        case 'E':
                            i = 14;
                            break;
                        case 'F':
                            i = 15;
                            break;
                        case 'a':
                            i = 10;
                            break;
                        case 'b':
                            i = 11;
                            break;
                        case 'c':
                            i = 12;
                            break;
                        case 'd':
                            i = 13;
                            break;
                        case 'e':
                            i = 14;
                            break;
                        case 'f':
                            i = 15;
                            break;
                        default:
                            i = 0;
                            break;
                    }//switch
                }//catch
                finally
                {
                    result += i * baseExp;
                    remDigits--;
                }

            }//for

            return result; //testing
        }
        /// <summary>
        /// Method used to convert from a decimal
        /// </summary>
        /// <param name="Value">Decimal value</param>
        /// <param name="BaseValue">To what base it is being converted to</param>
        /// <returns></returns>
        public static string FromDecimal(int Value, int BaseValue)
        {
            //initialize variables
            StkI = new Stack<object>();
            string BaseAny = "";//string to be output
            int Mod = 0;//declare a variable to hold the remainder

            //for loop to obtain the mod of Value and BaseValue and to push the Mod onto the stack
            for (int i = 0; i < Value; )
            {
                Mod = Value % BaseValue;

                if (Mod == 10)
                {
                    StkI.Push("A");
                }//end if
                else if(Mod == 11)
                {
                    StkI.Push("B");
                }//end if
                else if(Mod == 12)
                {
                    StkI.Push("C");
                }//end if
                else if(Mod == 13)
                {
                    StkI.Push("D");
                }//end if
                else if(Mod == 14)
                {
                    StkI.Push("E");
                }//end if
                else if(Mod == 15)
                {
                    StkI.Push("F");
                }//end if
                else
                {
                    StkI.Push(Mod);
                }//end else
                Value = Value / BaseValue;
            }//end for

            //While loop used to pop each item on the stack and put it into a string
            while (StkI.Count > 0)
            {
                BaseAny += StkI.Pop(); 
            }//end while
            return BaseAny;
        }
        /// <summary>
        /// Method for determining precision of a number in the right-hand box
        /// </summary>
        /// <param name="places">precision</param>
        /// <returns></returns>
        public static string ResultsPlace(int places, int Base)
        {
            StkI = new Stack<object>();
            string BaseAny = "";
           //checks to see if the base is in binary
            if (Base == 2)
            {
                //for loop to push and pop 0s into and off the stack
                for (int i = 0; i < places; i++)
                {
                    StkI.Push("0");
                    BaseAny += StkI.Pop();
                }//end for 
            }
            else
            {
                BaseAny = "";
            }
            return BaseAny;
        }
    }
}
