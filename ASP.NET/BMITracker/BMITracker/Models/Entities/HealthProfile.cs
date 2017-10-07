using BMITracker.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BMITracker.Models.Entities
{
    public partial class HealthProfile
    { 
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfBirth { get; set; }
        public int Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        /// <summary>
        /// Calculates and returns a string value of body type
        /// </summary>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public String BMI(double height, double weight)
        {
            double BmiNum = (weight / (height * height)) * 703;
            String Bmi;
            if (BmiNum < 18.5)
            {
                Bmi = "Underweight";
            }
            else if (BmiNum > 18.5 && BmiNum < 24.9)
            {
                Bmi = "Normal";
            }
            else if (BmiNum > 25 && BmiNum < 29.9)
            {
                Bmi = "Overweight";
            }
            else
            {
                Bmi = "Obese";
            }
            return Bmi;
        }
    }
}
