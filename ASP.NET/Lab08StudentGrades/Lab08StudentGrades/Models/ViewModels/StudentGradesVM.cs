﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab08StudentGrades.Models.ViewModels
{
    public class StudentGradesVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseCode { get; set; }
        public string CourseNumber { get; set; }
        public string LetterGrade { get; set; }
    }
}
