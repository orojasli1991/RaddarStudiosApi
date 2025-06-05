﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementInterRapidisimo.Domain.Entities
{
    namespace StudentManagementInterRapidisimo.Domain.Entities
    {
        public class Teacher
        {
            public int Id { get; set; }
            public string FullName { get; set; } 
            public List<Subject> Subjects { get; set; } = new List<Subject>();
            public bool CanTeachMoreSubjects()
            {
                return Subjects.Count < 2;
            }
        }
    }

}
