//Project:       Project 4
//Filename:      Customer.cs
//Description:   Contains information and methods for the customers
//Course:        CSCI 2210-001 Data Structures
//Author:        William H. Rochelle, rochellew@goldmail.etsu.edu
//Author:        Greer Goodman, goodmang@goldmail.etsu.edu
//Created:       April 4, 2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketSimulation
{
    
    class Customer
    {
        public int StoreNumber { get; set; }//where in the line the customer is standing
        public int LineSpot { get; set; }//which line the customer is in
        public DateTime Arrive { get; set; }//when the customer get to the line
        public TimeSpan Interval { get; set; }//amount of time a customer spends in line
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="PlaceInLine">The place in line.</param>
        /// <param name="ThisTime">The this time.</param>
        /// <param name="ThisInterval">The this interval.</param>
        public Customer(int PlaceInLine, DateTime ThisTime, TimeSpan ThisInterval)
        {
            StoreNumber = PlaceInLine;
            Arrive = ThisTime;
            Interval = ThisInterval;
        }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return StoreNumber.ToString();
        }
        
    }
}
