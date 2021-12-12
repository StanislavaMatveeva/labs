using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWork
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        public Student(int id, string name, int age, int groupId)
        {
            if (id < 1)
                throw new Exception("Wrong value of student's id");
            Id = id;
            if (name == null)
                throw new Exception("Empty name of student");
            Name = name;
            /*if (age < 16 || age > 100)
                throw new Exception("Wrong value of student's age");*/
            Age = age;
            if (groupId < 1)
                throw new Exception("Wrong value of student's group id");
            GroupId = groupId;
        }
    }
}
