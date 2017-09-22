
//Project:       Project 4
//Filename:      Supermarket.cs
//Description:   Contains methods used to perform the Supermarket Simulation
//Course:        CSCI 2210-001 Data Structures
//Author:        Greer Goodman, goodmang@goldmail.etsu.edu
//Author:        William H. Rochelle, rochellew@goldmail.etsu.edu
//Created:       April 5, 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketSimulation
{
    /// <summary>
    /// Driver program for Project 4 - supermarket simulation
    /// </summary>
    class Supermarket
    {
        #region VariablesUsed
        static int queueNum = 9;                                            //number of queues in the simulation
        static int longQueue;                                               //record longest line, does not decrement
        static int customerNum;                                             //number of customers who will visit today
        static int OpenTime = 8;                                            //time the store opens
        static int CloseTime = 24;                                          //time the store closes
        static int speed;                                                   //speed the simulation runs at
        static int eventsProcessed = 0;                                     //number of exits and arrivals processed
        static int exitsProcessed = 0;                                      //number of exits processed
        static int arrivalsProcessed = 0;                                   //number of arrivals processed
        static TimeSpan serviceTime;                                        //average time spent in line
        static TimeSpan timeTotal = new TimeSpan();                         //amount of time passed
        static TimeSpan shortest = new TimeSpan(99, 99, 99);                //least amount of time spent in a line
        static TimeSpan longest = new TimeSpan();                           //longest time spent in a line
        static Random rand = new Random();
        static List<Customer> customers = new List<Customer>();             //list of customers to arrive today
        static List<Queue<Customer>> queues = new List<Queue<Customer>>();  //list of queues
        static PriorityQueue<Evnt> events = new PriorityQueue<Evnt>();      //handles entry & exit events sorted by time occured
        #endregion

        #region Main(string[] args)
        /// <summary>
        /// main method with a menu interface to activate simulation
        /// </summary>
        static void Main(string[] args)
        {
            customerNum = CustomerNum();
            CreateEntryTimeline();

            #region MenuAndSwitch
            Console.ForegroundColor = ConsoleColor.Green;
            string strMenu = "";            
            strMenu += "\n\nSupermarket Simulation Menu\n";
            strMenu += "--------------------------------------------------\n";
            strMenu += "1) Specify Customer Count           (default: 600 customers)\n";
            strMenu += "2) Specify Time to Open             (default: 8:00 A.M.)\n";
            strMenu += "3) Specify Closing Time             (default: 12:00 A.M.)\n";
            strMenu += "4) Specify Number of Checkout Lanes (default: 9 lanes)\n";
            strMenu += "5) Specify Simulation Speed\n";
            strMenu += "6) Run Simulation\n";
            strMenu += "7) Exit program\n\n";

            while (true)
            {
                Console.Clear();
                Console.Write(strMenu);
                Console.Write("Enter a Selection: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("\n\nEnter number of expected customers: ");
                        input = Console.ReadLine();
                        try
                        {
                            customerNum = Int32.Parse(input);
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.Write("\n\nError: Invalid value entered");
                        }
                        break;//end case 1
                        
                    case "2":
                        Console.Clear();
                        Console.Write("\n\nEnter opening time (1-24): ");
                        input = Console.ReadLine();
                        try
                        {
                            int temp = Int32.Parse(input);
                            if (temp < 0 || temp > 24)
                                throw new Exception("Error: Invalid value entered");
                            OpenTime = temp;
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.Write("\n\nError: Invalid value entered");
                        }
                        break;//end case 2

                    case "3":
                        Console.Clear();
                        Console.Write("\n\nEnter closing time (1-24): ");
                        input = Console.ReadLine();
                        try
                        {
                            int temp = Int32.Parse(input);
                            if (temp < 0 || temp > 24)
                                throw new Exception("Error: Invalid value entered");
                            CloseTime = temp;
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.Write("\n\nError: Invalid value entered");
                        }
                        break;//end case 3

                    case "4":
                        Console.Clear();
                        Console.Write("\n\nEnter the number registers: ");
                        input = Console.ReadLine();
                        try
                        {
                            int temp = Int32.Parse(input);
                            if (temp > 11)          //does not allow line wrapping
                                throw new Exception("Error: Invalid value entered");
                            queueNum = temp;
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.Write("\n\nError: Invalid value entered");
                        }
                        break;//end case 4

                    case "5":
                        Console.Clear();
                        Console.Write("\n\nEnter Simulation Speed: ");
                        Console.Write("\n------------------------------------------------");
                        Console.Write("\n1) Slow");
                        Console.Write("\n2) Medium");
                        Console.Write("\n3) Fast");
                        Console.Write("\n4) Extremely Fast");
                        Console.Write("\n\n");

                        input = Console.ReadLine();
                        try
                        {
                            int temp = Int32.Parse(input);
                            if (temp < 0 || temp > 4)
                                throw new Exception("Error: Invalid value entered");
                            switch (temp)
                            {
                                case 1:
                                    speed = 100;
                                    break;
                                case 2:
                                    speed = 66;
                                    break;
                                case 3:
                                    speed = 33;
                                    break;
                                case 4:
                                    speed = 0;
                                    break;
                            }//end switch
                        }//end try

                        catch (Exception)
                        {
                            Console.Clear();
                            Console.Write("\n\nError: Invalid value entered");
                        }//end catch

                        break;//end case 5

                    case "6":
                        SimRun();
                        Console.ReadLine();

                        customerNum = CustomerNum();    //resets values for multiple uses of simulation
                        CreateEntryTimeline();
                        exitsProcessed = 0;
                        arrivalsProcessed = 0;
                        eventsProcessed = 0;
                        shortest = new TimeSpan(99, 99, 99);
                        longest = new TimeSpan(0, 0, 0);
                        longQueue = 0;
                        timeTotal = new TimeSpan(0, 0, 0);
                        break;//end case 6

                    case "7":
                        Environment.Exit(0);
                        break;

                }//end switch

            }//end while
            #endregion

        }//end Main(String[])
        #endregion

        #region SimRun()
        /// <summary>
        /// Runs the Supermarket simulation itself
        /// </summary>
        private static void SimRun()
        {
            for (int i = 0; i < queueNum; i++)
            {
                queues.Add(new Queue<Customer>());
            }//end for

            while (events.Count > 0)
            {
                if (events.Peek().Type == EVENTTYPE.ENTER)
                {
                    eventsProcessed++;
                    arrivalsProcessed++;

                    //finds the smallest queue
                    int smallest = 0;
                    for (int i = 0; i < queueNum; i++)
                    {
                        if (queues[i].Count < queues[smallest].Count)
                            smallest = i;
                        if (queues[i].Count > longQueue)
                            longQueue = queues[i].Count;
                    }//end for

                    //inserts customer into the smallest queue
                    queues[smallest].Enqueue(events.Peek().Customer);
                   
                    queues[smallest].ElementAt(queues[smallest].Count - 1).LineSpot = smallest;

                    //  if queue only has one person
                    //  enqueue  the exit event using arrival time + queue time
                    if (queues[smallest].Count == 1)   //new arrival is only person in line
                        events.Enqueue(new Evnt(EVENTTYPE.LEAVE, queues[smallest].Peek().Arrive.Add(queues[smallest].Peek().Interval), queues[smallest].Peek()));

                    System.Threading.Thread.Sleep(speed);
                    DrawScreen();                    

                    //dequeues the event
                    events.Dequeue();

                }//end if

                else      //handles the exit
                {
                    eventsProcessed++;
                    exitsProcessed++;

                    int presentQueue = events.Peek().Customer.LineSpot;

                    TimeSpan serviceTime = (events.Peek().Time.Subtract(events.Peek().Customer.Arrive));
                    timeTotal += serviceTime;

                    if (serviceTime < shortest)
                        shortest = serviceTime;
                    if (serviceTime > longest)
                        longest = serviceTime;
                  
                    queues[presentQueue].Dequeue();

                    //if current queue size > 0
                    //Enqueue next customer's exit event using this exit time + next customer's wait time
                    if (queues[presentQueue].Count > 0)
                        events.Enqueue(new Evnt(EVENTTYPE.LEAVE, events.Peek().Time.Add(queues[presentQueue].Peek().Interval), queues[presentQueue].Peek()));

                    System.Threading.Thread.Sleep(speed);
                    DrawScreen();     
                    events.Dequeue();
                }//end else

            }//end while
            
            serviceTime = new TimeSpan(0, 0, (int)(timeTotal.TotalSeconds / customerNum));

            Console.WriteLine("Number of customers: " + customerNum);
            Console.WriteLine("Avg Service Time: " + serviceTime.ToString());
            Console.WriteLine("Shortest wait: " + shortest.ToString());
            Console.WriteLine("Longest wait: " + longest.ToString());
            Console.Write    ("Press Enter to continue...");

        }//end SimRun
        #endregion

        #region AddEntryTimeline()
        /// <summary>
        /// Creates all customers/events
        /// </summary>
        static void CreateEntryTimeline()
        {
            for (int i = 0; i < customerNum; i++)
            {
                //finds the arrival time and date
                DateTime arrival = new DateTime
                (
                    DateTime.Today.Year,
                    DateTime.Today.Month,
                    DateTime.Today.Day,
                    rand.Next(OpenTime, CloseTime),
                    rand.Next(60),
                    rand.Next(60)
                );

                //finds the wait time in minutes and seconds
                double  seconds;
                int     minutes;
                while (true)
                {
                    seconds = -375 * Math.Log(rand.NextDouble(), Math.E); //note: 375 is 6m15s in seconds
                    if (seconds >= 120)   //120 is 2m in seconds
                        break;                  //do not allow queue times of less than two minutes
                }//end while

                minutes = (int)seconds / 60;
                seconds %= 60;
                TimeSpan waitTime = new TimeSpan(0, minutes, (int)seconds);

                customers.Add(new Customer(i + 1, arrival, waitTime));
                events.Enqueue(new Evnt(EVENTTYPE.ENTER, customers[i].Arrive, customers[i]));
            }
        }//end AddEntryTimeline()
        #endregion

        #region DrawScreen()
        /// <summary>
        /// provides a graphic representation of the simulation in the console window
        /// </summary>
        static void DrawScreen()
        {
            //Erases previous simulation
            Console.Clear();

            //Draws the queues in the console window
            for (int n = 0; n < queueNum; n++)
            {
                Console.Write("  CO" + (n + 1));
                Console.Write("  ");
            }//end for

            //Draws each customer in line in the queues in the console window
            for (int n = 0; n < longQueue; n++)
            {
                Console.WriteLine();
                for (int i = 0; i < queueNum; i++)
                {
                    Console.Write("  ");
                    if (queues[i].Count > n)
                    {
                        if (queues[i].ElementAt(n).StoreNumber < 10)
                            Console.Write("  ");
                        else if (queues[i].ElementAt(n).StoreNumber < 100)
                            Console.Write(" ");
                        Console.Write(queues[i].ElementAt(n).StoreNumber.ToString());
                    }
                    else
                        Console.Write("   ");
                    Console.Write("  ");
                }//end for
            }//end for
           
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Longest line thus far: " + longQueue + " customers");
            Console.WriteLine("Events processed: " + eventsProcessed + "\t Customer Arrivals: " + arrivalsProcessed + "\t Customer Exits: " + exitsProcessed);          

        }//end DrawScreen()
        #endregion

        #region CustomerNum()
        /// <summary>
        /// determines the number of customers using poisson distibution, 600 is the company's 
        /// expected number of customers per day
        /// </summary>
        /// <returns>number of customers who arrive </returns>
        public static int CustomerNum()
        {
            Random r = new Random();
            double Limit = -600;    //600 is expected number of customers
            double Sum = Math.Log(r.NextDouble());

            int Count;
            for (Count = 0; Sum > Limit; Count++)
                Sum += Math.Log(r.NextDouble());

            return Count; //# of customer in the store used in simulation

        }//end CustomerNum()
        #endregion

    }//end Supermarket
}