//Project:       Project 1
//Filename:      DistinctWord.cs
//Description:   Stores a single word, and the number of times it appears in a text string.
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
    /// Stores a single word, and the number of times it appears in a text string.
    /// </summary>
    public class DistinctWord : IEquatable<DistinctWord>, IComparable<DistinctWord>
    {
        public string word { get; set; }       //word being held
        public int count { get; set; }         //number of times the word appears in a text string

        /// <summary>
        /// Default constructor
        /// </summary>
        public DistinctWord()
        {
            this.count = 1; //default
        }//DistinctWord

        /// <summary>
        /// Paramaterized constructor
        /// </summary>
        /// <param name="word">Word to be held</param>
        public DistinctWord(string word)
        {
            this.word = word.ToLower();
            this.count = 1; //default
        }//DistinctWord(string)

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="d">DistinctWord to copy</param>
        public DistinctWord(DistinctWord d)
        {
            this.word = d.word;
            this.count = d.count;
        }//DistinctWord(DistinctWord)

        /// <summary>
        /// returns nicely formatted string containing the word & count variables
        /// </summary>
        /// <returns>word - the string being returned
        public override string ToString()
        {
            string word = "";
            int length;

            if (this.word != "\n" && this.word != "\r")
            {
                word += this.word;
                length = word.Length;
            }//if
            else
            { 
                word += "[new line]";
                length = 10;
            }//else
            
            for (int i = 0; i < (30 - length); i++)
            {
                word += " ";
            }//for
            word += count;

            return word;
        }//ToString()

        /// <summary>
        /// Determines whether the word values of two DistinctWords are equal
        /// </summary>
        /// <param name="d">DistinctWord to be compared</param>
        /// <returns>true if equal, false if not
        bool IEquatable<DistinctWord>.Equals (DistinctWord d)
        {
            return word == d.word;
        }//Equals(DistinctWord)

        /// <summary>
        /// Determines whether an object sent is a DistinctWord, and if so compares the two
        /// </summary>
        /// <param name="obj">Object being compared</param>
        /// <returns>true or false, "is the object equal?"
        public override bool Equals(object obj)
        {
            if (obj == null)
                return base.Equals(obj);
            if (!(obj is DistinctWord))
                throw new Exception("Parameter is not a DistinctWord");
            else
                return word == (obj as DistinctWord).word;
        }//Equals(object)

        /// <summary>
        /// Returns hashcode of word variable
        /// </summary>
        /// <returns>hascode of word
        public override int GetHashCode()
        {
            return word.GetHashCode();
        }//GetHashCode()

        /// <summary>
        /// compares the word variables in two DistinctWords
        /// </summary>
        /// <param name="other">DistinctWord being compared to</param>
        /// <returns>0 if equal, -1 if less than, 1 if greater than (alphabetically)
        public int CompareTo(DistinctWord other)
        {
            return word.CompareTo(other.word);
        }//CompareTo(DistinctWord)
    }//DistinctWord
}
