using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWork
{
    public class Curator
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GroupId { get; set; }

        public string Email { get; set; }

        public Group Group { get; set; }

        public Curator(int id, string name, int groupId, string email)
        {
            if (id < 1)
                throw new Exception("Wrong value of curator's id");
            Id = id;
            if (name == null)
                throw new Exception("Empty name of curator");
            Name = name;
            if (groupId < 1)
                throw new Exception("Wrong value of group's id");
            GroupId = groupId;
            if (email == null)
                throw new Exception("Empty email");
            Email = email;
        }
    }
}
