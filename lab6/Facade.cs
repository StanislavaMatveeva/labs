using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseWork;
using DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class Facade : IFacade
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Curator> Curators { get; set; }

        public UniversityContext Context { get; set; }

        public Facade(UniversityContext context)
        {
            Context = context;
            Students = context.Students;
            Groups = context.Groups;
            Curators = context.Curators;
        }

        public bool IsStudentInFacade(int studentId)
        {
            if (Students.Find(studentId) == null)
                return false;
            else
                return true;
        }

        public bool IsGroupInFacade(int groupId)
        {
            if (Groups.Find(groupId) == null)
                return false;
            else
                return true;
        }

        public bool IsCuratorInFacade(int curatorId)
        {
            if (Curators.Find(curatorId) == null)
                return false;
            else
                return true;
        }

        public bool IsEqualGroupName(Group group, string nameToCompare)
        {
            var check = false;
            var groups = Groups.Where(g => g.Name.ToUpper() == nameToCompare.ToUpper());
            if (groups.Any())
                check = true;
            else if (group.Name.ToUpper() == nameToCompare.ToUpper())
                check = false;
            else
                check = false;
            return check;
        }

        public bool IsEqualCuratorEmail(Curator curator, string emailToCompare)
        {
            if (curator.Email.ToLower() == emailToCompare.ToLower())
                return false;
            var curators = Curators.Where(c => c.Email.ToLower() == emailToCompare.ToLower());
            if (curators.Any())
                return true;
            else
                return false;
        }

        public bool IsValidCuratorEmail(string email)
        {
            if (!email.Contains("@") || !email.Contains(".") || email[0] == '@' || email.Contains(" "))
                return false;
            else
                return true;
        }

        public string MakeValidFormatOfName(string name)
        {
            if (name == null)
                throw new Exception("Empty name");
            var charArray = name.ToLower().ToCharArray();
            charArray[0] = char.ToUpper(charArray[0]);
            return new string(charArray);
        }

        public Facade AddStudent(Facade facade, Student student, string groupName)
        {
            int maxId = 0;
            try { maxId = Students.Max(s => s.Id); }
            catch { maxId = 0; }
            student.Id = maxId + 1;
            student.Name = MakeValidFormatOfName(student.Name);
            if (student.Age < 16 || student.Age > 100)
                throw new Exception("Wrong value of student's age");
            var group = Groups.FirstOrDefault(g => g.Name == groupName);
            if (group == null) 
                throw new Exception("There is no group in table \"Groups\"");
            student.Group = group;
            Students.Add(student);
            Context.Students = Students;
            Context.SaveChanges();
            return facade;
        }

        public Facade AddGroup(Facade facade, Group group)
        {
            int maxId = 0;
            try { maxId = Groups.Max(g => g.Id); }
            catch { maxId = 0; }
            group.Id = maxId + 1;
            if (IsEqualGroupName(group, group.Name))
                throw new Exception($"Group with name {group.Name} was already recorded");
            group.Name = group.Name.ToUpper();
            Groups.Add(group);
            Context.Groups = Groups;
            Context.SaveChanges();
            return facade;
        }

        public Facade AddCurator(Facade facade, Curator curator, string groupName)
        {
            int maxId = 0;
            try { maxId = Curators.Max(c => c.Id); }
            catch { maxId = 0; }
            curator.Id = maxId + 1;
            curator.Name = MakeValidFormatOfName(curator.Name);
            if (IsEqualCuratorEmail(curator, curator.Email))
                throw new Exception("Curator with such email adress was already recorded");
            if (!IsValidCuratorEmail(curator.Email))
                throw new Exception("Wrong format of email");
            curator.Email = curator.Email.ToLower();
            var group = Groups.FirstOrDefault(g => g.Name == groupName);
            if (group == null)
                throw new Exception("There is no group in table \"Groups\"");
            var anotherCurator = Curators.FirstOrDefault(c => c.GroupId == group.Id);
            if (anotherCurator != null)
                throw new Exception($"Group {anotherCurator.Group.Name} already has curator {anotherCurator.Name}");
            curator.Group = group;
            Curators.Add(curator);
            Context.Curators = Curators;
            Context.SaveChanges();
            return facade;
        }

        public Facade DeleteStudent(Facade facade, int studentId)
        {
            var student = Students.Find(studentId);
            if (student == null)
                throw new Exception("There is no student with such id or data of this entity is not full");
            Students.Remove(student);
            Context.Students = Students;
            Context.SaveChanges();
            return facade;
        }

        public Facade DeleteGroup(Facade facade, int groupId)
        {
            var group = Groups.Find(groupId);
            if (group == null)
                throw new Exception("There is no group with such id or data of this entity is not full");
            Groups.Remove(group);
            Context.Groups = Groups;
            Context.SaveChanges();
            return facade;
        }

        public Facade DeleteCurator(Facade facade, int curatorId)
        {
            var curator = Curators.Find(curatorId);
            if (curator == null)
                throw new Exception("There is no curator with such id or data of this entity is not full");
            Curators.Remove(curator);
            Context.Curators = Curators;
            Context.SaveChanges();
            return facade;
        }

        public Facade EditStudentsName(Facade facade, int studentId, string newName)
        {
            var student = Students.Find(studentId);
            if (student == null)
                throw new Exception("There is no student with such id");
            student.Name = MakeValidFormatOfName(newName);
            Context.Students = Students;
            Context.SaveChanges();
            return facade;
        }

        public Facade EditGroupName(Facade facade, int groupId, string newName)
        {
            var group = Groups.Find(groupId);
            if (group == null)
                throw new Exception("There is no group with such id");
            if (IsEqualGroupName(group, newName))
                throw new Exception($"Group with name {newName} was already recorded");
            group.Name = newName.ToUpper();
            Context.Groups = Groups;
            Context.SaveChanges();
            return facade;
        }

        public Facade EditCuratorName(Facade facade, int curatorId, string newName)
        {
            var curator = Curators.Find(curatorId);
            if (curator == null)
                throw new Exception("There is no curator with such id");
            curator.Name = MakeValidFormatOfName(newName);
            Context.Curators = Curators;
            Context.SaveChanges();
            return facade;
        }

        public Facade EditStudentsAge(Facade facade, int studentId, int newAge)
        {
            var student = Students.Find(studentId);
            if (student == null)
                throw new Exception("There is no student with such id");
            if (newAge < 16 || newAge > 100)
                throw new Exception("Wrong value of student's age");
            student.Age = newAge;
            Context.Students = Students;
            Context.SaveChanges();
            return facade;
        }

        public Facade EditGroupCreationDate(Facade facade, int groupId, DateTime newDate)
        {
            var group = Groups.Find(groupId);
            if (group == null)
                throw new Exception("There is no group with such id");
            group.CreationDate = newDate;
            Context.Groups = Groups;
            Context.SaveChanges();
            return facade;
        }

        public Facade EditCuratorEmail(Facade facade, int curatorId, string newEmail)
        {
            var curator = Curators.Find(curatorId);
            if (curator == null)
                throw new Exception("There is no curator with such id");
            if (!IsValidCuratorEmail(newEmail))
                throw new Exception("Wrong format of email");
            if (IsEqualCuratorEmail(curator, newEmail))
                throw new Exception("Curator with such email adress was already recorded");
            curator.Email = newEmail.ToLower();
            Context.Curators = Curators;
            Context.SaveChanges();
            return facade;
        }

        public Facade EditStudentsGroup(Facade facade, int studentId, string newGroupName)
        {
            var group = Groups.FirstOrDefault(g => g.Name == newGroupName);
            if (group == null)
                throw new Exception("There is no group with such id");
            var student = Students.Find(studentId);
            if (student == null)
                throw new Exception("There is no student with such id");
            student.Group = group;
            Context.Students = Students;
            Context.SaveChanges();
            return facade;
        }

        public Facade EditCuratorsGroup(Facade facade, int curatorId, string newGroupName)
        {
            var curator = Curators.Find(curatorId);
            if (curator == null)
                throw new Exception("There is no curator with such id");
            var group = Groups.FirstOrDefault(g => g.Name == newGroupName);
            if (group == null)
                throw new Exception("There is no group with such id");
            curator.Group = group;
            Context.Curators = Curators;
            Context.SaveChanges();
            return facade;
        }

        public Facade DeleteAllStudents(Facade facade)
        {
            foreach (var s in Students)
                Students.Remove(s);
            Context.Students = Students;
            Context.SaveChanges();
            return facade;
        }

        public Facade DeleteAllGroups(Facade facade)
        {
            foreach (var g in Groups)
                Groups.Remove(g);
            Context.Groups = Groups;
            Context.SaveChanges();
            return facade;
        }

        public Facade DeleteAllCurators(Facade facade)
        {
            foreach (var c in Curators)
                Curators.Remove(c);
            Context.Curators = Curators;
            Context.SaveChanges();
            return facade;
        }

        public int GetAmountOfStudentsInGroup(int groupId)
        {
            if (Groups.Find(groupId) == null)
                throw new Exception("There is no group with such id");
            return Students.Where(s => s.GroupId == groupId).Count();
        }

        public string GetNameOfGroupCurator(int studentId)
        {
            if (Students.Find(studentId) == null)
                throw new Exception("There is no student with such id");
            return Curators.Find(Curators
                .FirstOrDefault(c => c.GroupId == Groups
                .Find(Students.Find(studentId).GroupId).Id).Id).Name;
        }

        public double GetMiddleAgeOfStudentsInGroup(int curatorId)
        {
            if (Curators.Find(curatorId) == null)
                throw new Exception("There is no curator with such index");
            return Students.Where(s => s.GroupId == Curators
            .Find(curatorId).GroupId).Average(s => s.Age);
        }

        public string GetStudentNameById(int studentId)
        {
            var student = Students.Find(studentId);
            if (student == null)
                throw new Exception("There is no student with such id");
            return student.Name;
        }

        public string GetGroupNameById(int groupId)
        {
            var group = Groups.Find(groupId);
            if (group == null)
                throw new Exception("There is no group with such id");
            return group.Name;
        }

        public string GetCuratorNameById(int curatorId)
        {
            var curator = Curators.Find(curatorId);
            if (curator == null)
                throw new Exception("There is no curator with such id");
            return curator.Name;
        }
    }
}
