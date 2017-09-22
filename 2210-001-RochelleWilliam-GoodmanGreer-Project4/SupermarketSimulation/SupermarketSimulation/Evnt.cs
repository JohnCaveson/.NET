//Project:       Project 4
//Filename:      Evnt.cs
//Description:   Contains information and methods for the Events
//Course:        CSCI 2210-001 Data Structures
//Author:        William H. Rochelle, rochellew@goldmail.etsu.edu
//Author:        Greer Goodman, goodmang@goldmail.etsu.edu
//Created:       April 5, 2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketSimulation
{
    enum EVENTTYPE { ENTER, LEAVE };
    class Evnt : IComparable
    {
        public EVENTTYPE Type { get; set; }
        public DateTime Time { get; set; }
        public Customer Customer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Evnt"/> class.
        /// </summary>
        public Evnt()
        {
            Type = EVENTTYPE.ENTER;
            Time = DateTime.Now;
            Customer = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Evnt"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="time">The time.</param>
        /// <param name="customer">The customer.</param>
        public Evnt(EVENTTYPE type, DateTime time, Customer customer)
        {
            Type = type;
            Time = time;
            Customer = customer;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            String str = "";

            str += String.Format("{0} ", Customer.ToString().PadLeft(3));

            return str;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj" /> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj" />. Greater than zero This instance follows <paramref name="obj" /> in the sort order.
        /// </returns>
        /// <exception cref="ArgumentException">The argument is not an Event object.</exception>
        public int CompareTo(Object obj)
        {
            if (!(obj is Evnt))
            {
                throw new ArgumentException("The argument is not an Event object.");
            }

            Evnt e = (Evnt)obj;
            return (e.Time.CompareTo(Time));
        }
    }
}
