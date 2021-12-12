using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataBaseWork_;

namespace Core_
{
    public interface IFacade
    {
        /// <summary>
        /// Gets and sets collection of entities in table "Students".
        /// </summary>
        DbSet<Student> Students { get; set; }

        /// <summary>
        /// Gets and sets collection of entities in table "Groups".
        /// </summary>
        DbSet<Group> Groups { get; set; }

        /// <summary>
        /// Gets and sets collection of entities in table "Curators".
        /// </summary>
        DbSet<Curator> Curators { get; set; }

        /// <summary>
        /// Checks if there is a student in table "Students" with such id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="studentId">Id of student.</param>
        /// <returns>True, if student with such id is in table "Students". 
        /// False, if there is no students with such id in table "Students".</returns>
        bool IsStudentInFacade(Facade facade, int studentId);

        /// <summary>
        /// Checks if there is a group in table "Groups" with such id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="groupId">Id of group.</param>
        /// <returns>True, if group with such id is in table "Groups".
        /// False, if there is no group with such id in table "Groups".</returns>
        bool IsGroupInFacade(Facade facade, int groupId);

        /// <summary>
        /// Checks if there is a curator in table "Cuartors with such id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="curatorId">Id of curator.</param>
        /// <returns>True, if curator with such id is in table "Curators".
        /// False, if there is no curator with such id in table "Curators".</returns>
        bool IsCuratorInFacade(Facade facade, int curatorId);

        /// <summary>
        /// Checks if facade contains group with such name
        /// by changing it's register.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="nameToCompare">Name to compare with.</param>
        /// <returns>True if facade of database contains group with such name.
        /// False if facade of database doesn't contain group with such name.</returns>
        bool IsEqualGroupName(Facade facade, string nameToCompare);

        /// <summary>
        /// Adds student to facade od database.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="student">Student to add.</param>
        /// <exception cref="Exception">Is thrown when student's age is 
        /// less then 16 or mor then 100.</exception>
        /// <exception cref="Exception">Is thrown when there is no group
        /// with such id as student's group id.</exception>
        /// <returns>Facade of database.</returns>
        Facade AddStudent(Facade facade, Student student);

        /// <summary>
        /// Adds group to facade of database.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="group">Group to add.</param>
        /// <exception cref="Exception">Is thrown when facade of database
        /// contains group with such name as group's name.</exception>
        /// <returns>Facade of database.</returns>
        Facade AddGroup(Facade facade, Group group);

        /// <summary>
        /// Adds curator to facade of database.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="curator">Curator to add.</param>
        /// <returns></returns>
        Facade AddCurator(Facade facade, Curator curator);

        /// <summary>
        /// Deletes student from facade of database by his id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="studentId">Id of student.</param>
        /// <returns>Facade of database.</returns>
        Facade DeleteStudent(Facade facade, int studentId);

        /// <summary>
        /// Deletes group from facade of database by it's id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="groupId">Id of group.</param>
        /// <returns>Facade of database.</returns>
        Facade DeleteGroup(Facade facade, int groupId);

        /// <summary>
        /// Dalates curator from facade of database by his id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="curatorId">Id of curator.</param>
        /// <returns>Facade of database.</returns>
        Facade DeleteCurator(Facade facade, int curatorId);

        /// <summary>
        /// Changes name of student by his id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="studentId">Id of student.</param>
        /// <param name="newName">New name of student.</param>
        /// <returns>Facade of database.</returns>
        Facade EditStudentsName(Facade facade, int studentId, string newName);

        /// <summary>
        /// Changes name of group by it's id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="groupId">Id of group.</param>
        /// <param name="newName">New name of group.</param>
        /// <returns>Facade of database.</returns>
        Facade EditGroupName(Facade facade, int groupId, string newName);

        /// <summary>
        /// Changes name of curator by his id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="curatorId">Id of curator.</param>
        /// <param name="newName">New name of curator.</param>
        /// <returns>Facade of database.</returns>
        Facade EditCuratorName(Facade facade, int curatorId, string newName);

        /// <summary>
        /// Changes age of student by his id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="studentId">Id of student.</param>
        /// <param name="newAge">New age of student.</param>
        /// <returns>Facade of database.</returns>
        Facade EditStudentsAge(Facade facade, int studentId, int newAge);

        /// <summary>
        /// Changes creation date of group by it's id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="groupId">Id of group.</param>
        /// <param name="newDate">New creation date of group.</param>
        /// <returns>Facade of database.</returns>
        Facade EditGroupCreationDate(Facade facade, int groupId, DateTime newDate);

        /// <summary>
        /// Changes email of curator by his id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="curatorId">Id of curator.</param>
        /// <param name="newEmail">New email of curator.</param>
        /// <returns>Facade of database.</returns>
        Facade EditCuratorEmail(Facade facade, int curatorId, string newEmail);

        /// <summary>
        /// Changes student's group by his id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="studentId">Id of student.</param>
        /// <param name="newGroupId">Id of new group.</param>
        /// <returns>Facade of database.</returns>
        Facade EditStudentsGroup(Facade facade, int studentId, int newGroupId);

        /// <summary>
        /// Changes curator's group by his id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="curatorId">Id of curator.</param>
        /// <param name="newGroupId">Id of new group.</param>
        /// <returns>Facade of database.</returns>
        Facade EditCuratorsGroup(Facade facade, int curatorId, int newGroupId);

        /// <summary>
        /// Deletes all students from facade of database.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <returns>Facade of database.</returns>
        Facade DeleteAllStudents(Facade facade);

        /// <summary>
        /// Deletes all groups from facade of database.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <returns>Facade of database.</returns>
        Facade DeleteAllGroups(Facade facade);

        /// <summary>
        /// Deletes all curators from facade of database.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <returns>Facade of database.</returns>
        Facade DeleteAllCurators(Facade facade);

        /// <summary>
        /// Gets amount of students in group by it's id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="groupId">Id of group.</param>
        /// <returns>Facade of database.</returns>
        int GetAmountOfStudentsInGroup(Facade facade, int groupId);

        /// <summary>
        /// Gets name of curator of student's group by his id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="studentId">Id of student.</param>
        /// <returns>Facade of database.</returns>
        string GetNameOfGroupCurator(Facade facade, int studentId);

        /// <summary>
        /// Gets middle age of students in curator's group by his id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="curatorId">Id of curator.</param>
        /// <returns>Facade of database.</returns>
        double GetMiddleAgeOfStudentsInGroup(Facade facade, int curatorId);

        /// <summary>
        /// Gets name of student by his id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="studentId">Id of student.</param>
        /// <returns>Facade of database.</returns>
        string GetStudentNameById(Facade facade, int studentId);

        /// <summary>
        /// Gets name of group by it's id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="groupId">Id of group.</param>
        /// <returns>Facade of database.</returns>
        string GetGroupNameById(Facade facade, int groupId);

        /// <summary>
        /// Gets name of curator by his id.
        /// </summary>
        /// <param name="facade">Facade of database.</param>
        /// <param name="curatorId">Id of curator.</param>
        /// <returns>Facade of database.</returns>
        string GetCuratorNameById(Facade facade, int curatorId);
    }
}
