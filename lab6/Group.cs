using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWork
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public Group(int id, string name, DateTime creationDate)
        {
            if (id < 1)
                throw new Exception("Wrong value of group's id");
            Id = id;
            if (name == null)
                throw new Exception("Empty name of group");
            Name = name;
            CreationDate = creationDate;
        }
    }
}
