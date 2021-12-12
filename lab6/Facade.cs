using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseWork_;
using DataBaseContext_;
using Microsoft.EntityFrameworkCore;

namespace Core_
{
    public class Facade : IFacade
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Curator> Curators { get; set; }

        UniversityContext context;

        public Facade(string connectionString)
        {
            if (connectionString == null)
                throw new Exception("Empty connection string");
            var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
            optionsBuilder.UseNpgsql(connectionString);
            context = new UniversityContext(optionsBuilder.Options);
            context.Students.Load();
            Students = context.Students;
            context.Groups.Load();
            Groups = context.Groups;
            context.Curators.Load();
            Curators = context.Curators;
        }

        public bool IsStudentInFacade(Facade facade, int studentId)
        {
            if (Students.Find(studentId) == null)
                return false;
            else 
                return true;
        }

        public bool IsGroupInFacade(Facade facade, int groupId)
        {
            if (Groups.Find(groupId) == null)
                return false;
            else
                return true;
        }

        public bool IsCuratorInFacade(Facade facade, int curatorId)
        {
            if (Curators.Find(curatorId) == null)
                return false;
            else
                return true;
        }

        public bool IsEqualGroupName(Facade facade, string nameToCompare)
        {
            var groups = Groups.Where(g => g.Name == nameToCompare.ToUpper());
            if (groups == null)
                return false;
            else
                return true;
        }

        public Facade AddStudent(Facade facade, Student student)
        {
            if (student.Age < 16 || student.Age > 100)
                throw new Exception("Wrong value of student's age");
            if (Groups.Find(student.GroupId) == null)
                throw new Exception("There is no group in table \"Groups\"");
            student.Group = Groups.Find(student.GroupId);
            Students.Add(student);
            context.Students = Students;
            context.SaveChanges();
            return facade;
        }

        public Facade AddGroup(Facade facade, Group group)
        {
            if (Groups.FirstOrDefault(g => g.Name == group.Name) != null)
                throw new Exception($"Group with name {group.Name} was already recorded");
            if (IsEqualGroupName(facade, group.Name))
                throw new Exception($"Group with name {group.Name} was already recorded");
            Groups.Add(group);
            context.Groups = Groups;
            context.SaveChanges();
            return facade;
        }

        public Facade AddCurator(Facade facade, Curator curator)
        {
            if (Curators.FirstOrDefault(c => c.Email == curator.Email) != null)
                throw new Exception("Curator with such email adress was already recorded");
            if (Groups.Find(curator.GroupId) == null)
                throw new Exception("There is no group in table \"Groups\"");
            curator.Group = Groups.Find(curator.GroupId);
            var anotherCurator = Curators.FirstOrDefault(c => c.GroupId == curator.GroupId);
            if (anotherCurator != null)
                throw new Exception($"Group {curator.Group.Name} already has curator {anotherCurator.Name}");
            Curators.Add(curator);
            context.Curators = Curators;
            context.SaveChanges();
            return facade;
        }

        public Facade DeleteStudent(Facade facade, int studentId)
        {
            var student = Students.Find(studentId);
            if (student == null)
                throw new Exception("There is no student with such id or data of this entity is not full");
            if (student.Name == null || student.Age == 0 || student.GroupId == 0 || student.Group == null)
                throw new Exception($"Invalid data for student with id {studentId}");
            Students.Remove(Students.Find(studentId));
            context.Students = Students;
            context.SaveChanges();
            return facade;
        }

        public Facade DeleteGroup(Facade facade, int groupId)
        {
            var group = Groups.Find(groupId);
            if (group == null)
                throw new Exception("There is no group with such id or data of this entity is not full");
            if (group.Name == null || group.CreationDate.ToString() == null)
                throw new Exception($"Invalid data for group with id {groupId}");
            Groups.Remove(Groups.Find(groupId));
            context.Groups = Groups;
            context.SaveChanges();
            return facade;
        }

        public Facade DeleteCurator(Facade facade, int curatorId)
        {
            var curator = Curators.Find(curatorId);
            if (curator == null)
                throw new Exception("There is no curator with such id or data of this entity is not full");
            if (curator.Name == null || curator.Email == null || curator.GroupId.ToString() == null)
                throw new Exception($"Invalid data for curator with id {curatorId}");
            Curators.Remove(Curators.Find(curatorId));
            context.Curators = Curators;
            context.SaveChanges();
            return facade;
        }

        public Facade EditStudentsName(Facade facade, int studentId, string newName)
        {
            try { Students.Find(studentId).Name = newName; }
            catch { throw new Exception("There is no student with such id"); }
            context.Students = Students;
            context.SaveChanges();
            return facade;
        }

        public Facade EditGroupName(Facade facade, int groupId, string newName)
        {
            try { Groups.Find(groupId).Name = newName; }
            catch { throw new Exception("There is no group with such id"); }
            context.Groups = Groups;
            context.SaveChanges();
            return facade;
        }

        public Facade EditCuratorName(Facade facade, int curatorId, string newName)
        {
            try { Curators.Find(curatorId).Name = newName; }
            catch { throw new Exception("There is no curator with such id"); }
            context.Curators = Curators;
            context.SaveChanges();
            return facade;
        }

        public Facade EditStudentsAge(Facade facade, int studentId, int newAge)
        {
            try { Students.Find(studentId).Age = newAge; }
            catch { throw new Exception("There is no student with such id"); }
            context.Students = Students;
            context.SaveChanges();
            return facade;
        }

        public Facade EditGroupCreationDate(Facade facade, int groupId, DateTime newDate)
        {
            try { Groups.Find(groupId).CreationDate = newDate; }
            catch { throw new Exception("There is no group with such id"); }
            context.Groups = Groups;
            context.SaveChanges();
            return facade;
        }

        public Facade EditCuratorEmail(Facade facade, int curatorId, string newEmail)
        {
            try { Curators.Find(curatorId).Email = newEmail; }
            catch { throw new Exception("There is no curator with such id"); }
            context.Curators = Curators;
            context.SaveChanges();
            return facade;
        }

        public Facade EditStudentsGroup(Facade facade, int studentId, int newGroupId)
        {
            try { Students.Find(studentId).Group = Groups.Find(newGroupId); }
            catch { throw new Exception("There is no student or group with such id"); }
            context.Students = Students;
            context.SaveChanges();
            return facade;
        }

        public Facade EditCuratorsGroup(Facade facade, int curatorId, int newGroupId)
        {
            try { Curators.Find(curatorId).Group = Groups.Find(newGroupId); }
            catch { throw new Exception("There is no curator or group with such id"); }
            context.Curators = Curators;
            context.SaveChanges();
            return facade;
        }

        public Facade DeleteAllStudents(Facade facade)
        {
            foreach (var s in Students)
                Students.Remove(s);
            context.Students = Students;
            context.SaveChanges();
            return facade;
        }

        public Facade DeleteAllGroups(Facade facade)
        {
            foreach (var g in Groups)
                Groups.Remove(g);
            context.Groups = Groups;
            context.SaveChanges();
            return facade;
        }

        public Facade DeleteAllCurators(Facade facade)
        {
            foreach (var c in Curators)
                Curators.Remove(c);
            context.Curators = Curators;
            context.SaveChanges();
            return facade;
        }

        public int GetAmountOfStudentsInGroup(Facade facade, int groupId)
        {
            if (Groups.Find(groupId) == null)
                throw new Exception("There is no group with such id");
            return Students.Where(s => s.GroupId == groupId).Count();
        }

        public string GetNameOfGroupCurator(Facade facade, int studentId)
        {
            if (Students.Find(studentId) == null)
                throw new Exception("There is no student with such id");
            return Curators.Find(Curators
                .FirstOrDefault(c => c.GroupId == Groups
                .Find(Students.Find(studentId).GroupId).Id).Id).Name;
        }

        public double GetMiddleAgeOfStudentsInGroup(Facade facade, int curatorId)
        {
            if (Curators.Find(curatorId) == null)
                throw new Exception("There is no curator with such index");
            return Students.Where(s => s.GroupId == Curators
            .Find(curatorId).GroupId).Average(s => s.Age);
        }

        public string GetStudentNameById(Facade facade, int studentId)
        {
            var student = Students.Find(studentId);
            if (student == null)
                throw new Exception("There is no student with such id");
            return student.Name;
        }

        public string GetGroupNameById(Facade facade, int groupId)
        {
            var group = Groups.Find(groupId);
            if (group == null)
                throw new Exception("There is no group with such id");
            return group.Name;
        }

        public string GetCuratorNameById(Facade facade, int curatorId)
        {
            var curator = Curators.Find(curatorId);
            if (curator == null)
                throw new Exception("There is no curator with such id");
            return curator.Name;
        }
    }
}
