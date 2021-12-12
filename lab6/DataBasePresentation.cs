using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBaseWork;
using DataBaseContext;
using Core;

namespace Presentation
{

    public partial class DataBasePresentation : Form
    {
        private IFacade facade;
        private DataGridViewComboBoxColumn comboBoxForStudentsGroupNames;
        private DataGridViewComboBoxColumn comboBoxForCuratorsGroupNames;
        const int studentIdColumn = 0;
        const int studentNameColumn = 1;
        const int studentAgeColumn = 2;
        const int studentGroupIdColumn = 3;
        const int groupIdColumn = 0;
        const int groupNameColumn = 1;
        const int groupCreationDateColumn = 2;
        const int curatorIdColumn = 0;
        const int curatorNameColumn = 1;
        const int curatorEmailColumn = 2;
        const int curatorGroupNameColumn = 3;
        const int comboBoxFirstActionIndex = 0;
        const int comboBoxSecondActionIndex = 1;
        const int comboBoxThirdActionIndex = 2;
        const int newIdByDefault = 1;

        public DataBasePresentation(IFacade newFacade)
        {
            InitializeComponent();
            facade = newFacade;
            comboBoxForCuratorsGroupNames = new DataGridViewComboBoxColumn();
            comboBoxForStudentsGroupNames = new DataGridViewComboBoxColumn();
            InitComboBoxForGroupNames();
            CreateStartStudentsTable();
            CreateStartGroupsTable();
            CreateStartCuratorsTable();
            InitComboBoxWithActions();
            dataGridViewStudents.Columns[studentIdColumn].ReadOnly = true;
            dataGridViewGroups.Columns[groupIdColumn].ReadOnly = true;
            dataGridViewGroups.Columns[curatorIdColumn].ReadOnly = true;
            comboBoxChooseAction.DropDownStyle = ComboBoxStyle.DropDownList;
            richTextBoxEnterIdText.ReadOnly = true;
            richTextBoxEnterIdValue.Multiline = false;
            richTextBoxAnswer.ReadOnly = true;
            richTextBoxStudentsTableTitle.ReadOnly = true;
            richTextBoxGroupsTableTitle.ReadOnly = true;
            richTextBoxCuratorsTableTitle.ReadOnly = true;
        }

        /// <summary>
        /// Initiakize combo box with texts of possible actions.
        /// </summary>
        private void InitComboBoxWithActions()
        {
            comboBoxChooseAction.Items.Add("Get an amount of students in group");
            comboBoxChooseAction.Items.Add("Get a name of group's curator");
            comboBoxChooseAction.Items.Add("Get a middle age of student's from curator's group");
        }

        private void InitComboBoxForGroupNames()
        {
            foreach (var g in facade.Groups)
            {
                comboBoxForStudentsGroupNames.Items.Add(g.Name);
                comboBoxForCuratorsGroupNames.Items.Add(g.Name);
            }
        }

        /// <summary>
        /// Shows message box with text of error.
        /// </summary>
        /// <param name="message"></param>
        private void TellAboutError(string message)
        {
            MessageBox.Show(message, "DataBasePresentation", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Checks if row's culls are full.
        /// </summary>
        /// <param name="row">Row.</param>
        /// <returns>True if cells are full.
        /// False if cells are empty.</returns>
        private bool IsFullRow(DataGridViewRow row)
        {
            var check = true;
            for (int i = 0; i < row.Cells.Count; i++)
                if (row.Cells[i].Value == null)
                    check = false;
            return check;
        }

        private void CheckTable(DataGridView table, int rowIndex)
        {
            var tableName = table.Name.Substring(12);
            for (int i = 0; i < rowIndex; i++)
            {
                if (!IsFullRow(table.Rows[i]) && table.Rows[i].Index != table.RowCount - 2)
                { TellAboutError($"Empty value in row {table.Rows[i].Index + 1} of table {tableName}"); return; }
            }
        }

        /// <summary>
        /// Creates table with data from table "Students" before changings.
        /// </summary>
        private void CreateStartStudentsTable()
        {
            dataGridViewStudents.Columns.Add("id", "ID");
            dataGridViewStudents.Columns.Add("name", "Name");
            dataGridViewStudents.Columns.Add("age", "Age");
            dataGridViewStudents.Columns.Add(comboBoxForStudentsGroupNames);
            dataGridViewStudents.Columns[studentGroupIdColumn].Name = "Group";
            foreach (var s in facade.Students)
            {
                dataGridViewStudents.Rows.Add(s.Id, s.Name, s.Age, s.Group.Name);
            }
        }

        /// <summary>
        /// Creates table with data from table "Groups" before changings.
        /// </summary>
        private void CreateStartGroupsTable()
        {
            dataGridViewGroups.Columns.Add("id", "ID");
            dataGridViewGroups.Columns.Add("name", "Name");
            dataGridViewGroups.Columns.Add("creationDate", "Creation date");
            foreach (var g in facade.Groups)
                dataGridViewGroups.Rows.Add(g.Id, g.Name, g.CreationDate);
        }

        /// <summary>
        /// Creates table with data from table "Curators" before changings.
        /// </summary>
        private void CreateStartCuratorsTable()
        {
            dataGridViewCurators.ClearSelection();
            dataGridViewCurators.Columns.Add("id", "ID");
            dataGridViewCurators.Columns.Add("name", "Name");
            dataGridViewCurators.Columns.Add("email", "Email");
            dataGridViewCurators.Columns.Add(comboBoxForCuratorsGroupNames);
            dataGridViewCurators.Columns[curatorGroupNameColumn].Name = "Group";
            foreach (var c in facade.Curators)
                dataGridViewCurators.Rows.Add(c.Id, c.Name, c.Email, c.Group.Name);
        }

        /// <summary>
        /// Creates table with new data from table "Students".
        /// </summary>
        private void UpdateStudentsTable()
        {
            dataGridViewStudents.Rows.Clear();
            foreach (var s in facade.Students)
                dataGridViewStudents.Rows.Add(s.Id, s.Name, s.Age, s.Group.Name);
        }

        /// <summary>
        /// Creates table with new data from table "Groups".
        /// </summary>
        private void UpdateGroupsTable()
        {
            dataGridViewGroups.Rows.Clear();
            dataGridViewStudents.Columns.Remove(comboBoxForStudentsGroupNames);
            dataGridViewCurators.Columns.Remove(comboBoxForCuratorsGroupNames);
            comboBoxForStudentsGroupNames = new DataGridViewComboBoxColumn();
            comboBoxForCuratorsGroupNames = new DataGridViewComboBoxColumn();
            foreach (var g in facade.Groups)
            {
                dataGridViewGroups.Rows.Add(g.Id, g.Name, g.CreationDate);
                comboBoxForStudentsGroupNames.Items.Add(g.Name);
                comboBoxForCuratorsGroupNames.Items.Add(g.Name);
            }
            dataGridViewStudents.Columns.Add(comboBoxForStudentsGroupNames);
            dataGridViewCurators.Columns.Add(comboBoxForCuratorsGroupNames);
        }

        /// <summary>
        /// Creates table with new data from table "Curators".
        /// </summary>
        private void UpdateCuratorsTable()
        {
            dataGridViewCurators.Rows.Clear();
            foreach (var c in facade.Curators)
                dataGridViewCurators.Rows.Add(c.Id, c.Name, c.Email, c.Group.Name);
        }

        private void UpdateAllTables()
        {
            UpdateGroupsTable();
            UpdateStudentsTable();
            UpdateCuratorsTable();
        }

        /// <summary>
        /// Sets new id for entity from table "Students" 
        /// if entered row is a row for new records.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewStudents_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewStudents.Rows[e.RowIndex].IsNewRow)
            {
                if (!facade.Students.Any())
                    dataGridViewStudents.Rows[e.RowIndex].Cells[studentIdColumn].Value = 1;
                else
                    dataGridViewStudents.Rows[e.RowIndex].Cells[studentIdColumn].Value = facade.Students.Max(s => s.Id) + 1;
            }
        }

        /// <summary>
        /// Sets new id for entity from table "Groups" 
        /// if entered row is a row for new records.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewGroups_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewGroups.Rows[e.RowIndex].IsNewRow)
            {
                if (!facade.Groups.Any())
                    dataGridViewGroups.Rows[e.RowIndex].Cells[groupIdColumn].Value = 1;
                else
                    dataGridViewGroups.Rows[e.RowIndex].Cells[groupIdColumn].Value = facade.Groups.Max(g => g.Id) + 1;
            }
        }

        /// <summary>
        /// Sets new id for entity from table "Curators" 
        /// if entered row is a row for new records.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewCurators_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCurators.Rows[e.RowIndex].IsNewRow)
            {
                if (!facade.Curators.Any())
                    dataGridViewCurators.Rows[e.RowIndex].Cells[curatorIdColumn].Value = 1;
                else
                    dataGridViewCurators.Rows[e.RowIndex].Cells[curatorIdColumn].Value = facade.Curators.Max(c => c.Id) + 1;
            }
        }

        /// <summary>
        /// Calls method for adding new entity of table "Students" if it is new.
        /// Calls method for changing enityt of table "Students" if it isn't new.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewStudents_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CheckTable(dataGridViewStudents, e.RowIndex);
            if (IsFullRow(dataGridViewStudents.Rows[e.RowIndex]))
            {
                var id = (int)dataGridViewStudents.Rows[e.RowIndex].Cells[studentIdColumn].Value;
                if (!facade.IsStudentInFacade(id))
                    AddStudentToTable(e.RowIndex);
                else
                    EditStudentsTable(e.RowIndex, e.ColumnIndex, id);
            }
        }

        /// <summary>
        /// Calls method for adding new entity of table "Groups" if it is new.
        /// Calls method for changing enityt of table "Groups" if it isn't new.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewGroups_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CheckTable(dataGridViewGroups, e.RowIndex);
            if (IsFullRow(dataGridViewGroups.Rows[e.RowIndex]))
            {
                var id = (int)dataGridViewGroups.Rows[e.RowIndex].Cells[groupIdColumn].Value;
                if (!facade.IsGroupInFacade(id))
                    AddGroupToTable(e.RowIndex);
                else
                    EditGroupsTable(e.RowIndex, e.ColumnIndex, id);
            }
        }

        /// <summary>
        /// Calls method for adding new entity of table "Curators" if it is new.
        /// Calls method for changing enityt of table "Curators" if it isn't new.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewCurators_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CheckTable(dataGridViewCurators, e.RowIndex);
            if (IsFullRow(dataGridViewCurators.Rows[e.RowIndex]))
            {
                var id = (int)dataGridViewCurators.Rows[e.RowIndex].Cells[curatorIdColumn].Value;
                if (!facade.IsCuratorInFacade(id))
                    AddCuratorToTable(e.RowIndex);
                else
                    EditCuratorsTable(e.RowIndex, e.ColumnIndex, id);
            }
        }

        /// <summary>
        /// Gets data grom row that is deleting by user from table "Students".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewStudents_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!facade.IsStudentInFacade((int)e.Row.Cells[studentIdColumn].Value))
            { dataGridViewStudents.Rows.Remove(e.Row); return; }
            try { facade = facade.DeleteStudent((Facade)facade, (int)e.Row.Cells[studentIdColumn].Value); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
        }

        /// <summary>
        /// Gets data from row that is deleting by user from table "Groups".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewGroups_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!facade.IsGroupInFacade((int)e.Row.Cells[groupIdColumn].Value))
            { dataGridViewGroups.Rows.Remove(e.Row); return; }
            try { facade = facade.DeleteGroup((Facade)facade, (int)e.Row.Cells[groupIdColumn].Value); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
            UpdateAllTables();
        }

        /// <summary>
        /// Gets data from row that is deleting by user from table "Curators".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewCurators_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!facade.IsCuratorInFacade((int)e.Row.Cells[curatorIdColumn].Value))
            { dataGridViewCurators.Rows.Remove(e.Row); return; }
            try { facade = facade.DeleteCurator((Facade)facade, (int)e.Row.Cells[curatorIdColumn].Value); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
        }

        /// <summary>
        /// Calls method that creates table with new data from table "Groups".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveGroupsTable_Click(object sender, EventArgs e)
        {
            UpdateAllTables();
        }

        /// <summary>
        /// Gets data of new entity from table "Students".
        /// </summary>
        /// <param name="rowIndex"></param>
        private void AddStudentToTable(int rowIndex)
        {
            var name = dataGridViewStudents.Rows[rowIndex].Cells[studentNameColumn].Value.ToString();
            if (name == null)
            { TellAboutError("Empty name of student"); return; }
            if (!int.TryParse(dataGridViewStudents.Rows[rowIndex].Cells[studentAgeColumn].Value.ToString(), out int age) && age < 16 || age > 100)
            { TellAboutError("Wrong value of student's age"); return; }
            var groupName = dataGridViewStudents.Rows[rowIndex].Cells[studentGroupIdColumn].Value.ToString();
            if (groupName == null)
            { TellAboutError("Empry name of group"); return; }
            try { facade = facade.AddStudent((Facade)facade, new Student(newIdByDefault, name, age, newIdByDefault), groupName); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
        }

        /// <summary>
        /// Gets data of new entity from table "Groups".
        /// </summary>
        /// <param name="rowIndex"></param>
        private void AddGroupToTable(int rowIndex)
        {
            var name = dataGridViewGroups.Rows[rowIndex].Cells[groupNameColumn].Value.ToString();
            if (name == null)
            { TellAboutError("Empty name of group"); return; }
            var creationDate = dataGridViewGroups.Rows[rowIndex].Cells[groupCreationDateColumn].Value.ToString();
            if (creationDate == null)
            { TellAboutError("Empty creation date of group"); return; }
            DateTime date;
            try { date = Convert.ToDateTime(creationDate); }
            catch { TellAboutError("Wrong value of creation date"); return; }
            try { facade = facade.AddGroup((Facade)facade, new Group(newIdByDefault, name, date)); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
            UpdateAllTables();
        }

        /// <summary>
        /// Gets data of new entity from table "Curators".
        /// </summary>
        /// <param name="rowIndex"></param>
        private void AddCuratorToTable(int rowIndex)
        {
            var name = dataGridViewCurators.Rows[rowIndex].Cells[curatorNameColumn].Value.ToString();
            if (name == null)
            { TellAboutError("Empty curator's name"); return; }
            var email = dataGridViewCurators.Rows[rowIndex].Cells[curatorEmailColumn].Value.ToString();
            if (email == null)
            { TellAboutError("Empty curator's email adress"); return; }
            var groupName = dataGridViewCurators.Rows[rowIndex].Cells[curatorGroupNameColumn].Value.ToString();
            if (groupName == null)
            { TellAboutError("Empty name of group"); return; }
            try { facade = facade.AddCurator((Facade)facade, new Curator(newIdByDefault, name, newIdByDefault, email), groupName); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
        }

        /// <summary>
        /// Calls methos od ghanging data of entity from table "Students".
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <param name="id"></param>
        private void EditStudentsTable(int rowIndex, int columnIndex, int id)
        {
            switch (columnIndex)
            {
                case studentNameColumn:
                    var name = dataGridViewStudents.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                    if (name == null)
                    { TellAboutError("Empty name of student"); return; }
                    try { facade = facade.EditStudentsName((Facade)facade, id, name); }
                    catch (Exception ex) { TellAboutError(ex.Message); return; }
                    break;
                case studentAgeColumn:
                    if (!int.TryParse(dataGridViewStudents.Rows[rowIndex].Cells[columnIndex].Value.ToString(), out int age))
                    { TellAboutError("Wrong value of student's age"); return; }
                    try { facade = facade.EditStudentsAge((Facade)facade, id, age); }
                    catch (Exception ex) { TellAboutError(ex.Message); return; }
                    break;
                case studentGroupIdColumn:
                    var groupName = dataGridViewStudents.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                    if (groupName == null)
                    { TellAboutError("Empty name of group"); return; }
                    try { facade = facade.EditStudentsGroup((Facade)facade, id, groupName); }
                    catch (Exception ex) { TellAboutError(ex.Message); return; }
                    break;
            }
        }

        /// <summary>
        /// Calls method of changing data of entity from table "Groups".
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <param name="id"></param>
        private void EditGroupsTable(int rowIndex, int columnIndex, int id)
        {
            switch (columnIndex)
            {
                case groupNameColumn:
                    var name = dataGridViewGroups.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                    if (name == null)
                    { TellAboutError("Empty name of group"); return; }
                    try { facade = facade.EditGroupName((Facade)facade, id, name); }
                    catch (Exception ex) { TellAboutError(ex.Message); return; }
                    UpdateAllTables();
                    break;
                case groupCreationDateColumn:
                    var creationDate = dataGridViewGroups.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                    if (creationDate == null)
                    { TellAboutError("Empty creation date of group"); return; }
                    DateTime date;
                    try { date = Convert.ToDateTime(creationDate); }
                    catch { TellAboutError("Wrong value of creation date"); return; }
                    try { facade = facade.EditGroupCreationDate((Facade)facade, id, date); }
                    catch (Exception ex) { TellAboutError(ex.Message); return; }
                    UpdateGroupsTable();
                    break;
            }
        }

        /// <summary>
        /// Calls method of changing data of entity from table "Curators".
        /// </summary>
        /// <param name="rowINdex"></param>
        /// <param name="columnIndex"></param>
        /// <param name="id"></param>
        private void EditCuratorsTable(int rowINdex, int columnIndex, int id)
        {
            switch (columnIndex)
            {
                case curatorNameColumn:
                    var name = dataGridViewCurators.Rows[rowINdex].Cells[columnIndex].Value.ToString();
                    if (name == null)
                    { TellAboutError("Empty curator's name"); return; }
                    try { facade = facade.EditCuratorName((Facade)facade, id, name); }
                    catch (Exception ex) { TellAboutError(ex.Message); return; }
                    break;
                case curatorEmailColumn:
                    var email = dataGridViewCurators.Rows[rowINdex].Cells[columnIndex].Value.ToString();
                    if (email == null)
                    { TellAboutError("Empty email adress"); return; }
                    try { facade = facade.EditCuratorEmail((Facade)facade, id, email); }
                    catch (Exception ex) { TellAboutError(ex.Message); return; }
                    break;
                case curatorGroupNameColumn:
                    var groupName = dataGridViewCurators.Rows[rowINdex].Cells[columnIndex].Value.ToString();
                    if (groupName == null)
                    { TellAboutError("Empry name of group"); return; }
                    try { facade = facade.EditCuratorsGroup((Facade)facade, id, groupName); }
                    catch (Exception ex) { TellAboutError(ex.Message); return; }
                    break;
            }
        }

        /// <summary>
        /// Gets group's id from text box.
        /// Sets amount of students of group by it's id to text box.
        /// </summary>
        private void DoFirstAction()
        {
            if (!int.TryParse(richTextBoxEnterIdValue.Text, out int id))
            { TellAboutError("Wrong value of group's id"); return; }
            int amount;
            try { amount = facade.GetAmountOfStudentsInGroup(id); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
            string name;
            try { name = facade.GetGroupNameById(id); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
            richTextBoxAnswer.Text = $"{amount} students was found in group {name}";
        }

        /// <summary>
        /// Gets student's id from text box.
        /// Sets curator's name of student's group by student's id to text box.
        /// </summary>
        private void DoSecondAction()
        {
            if (!int.TryParse(richTextBoxEnterIdValue.Text, out int id))
            { TellAboutError("Wrong value of student's id"); return; }
            string curatorName;
            try { curatorName = facade.GetNameOfGroupCurator(id); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
            string studentName;
            try { studentName = facade.GetStudentNameById(id); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
            richTextBoxAnswer.Text = $"{curatorName} is curator of {studentName}'s group";
        }

        /// <summary>
        /// Gets curator's id from text box.
        /// Sets middle age of students from curator's group by his id to text box.
        /// </summary>
        private void DoThirdAction()
        {
            if (!int.TryParse(richTextBoxEnterIdValue.Text, out int id))
            { TellAboutError("Wrong value of curator's id"); return; }
            double middleAge;
            try { middleAge = facade.GetMiddleAgeOfStudentsInGroup(id); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
            string curatorName;
            try { curatorName = facade.GetCuratorNameById(id); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
            richTextBoxAnswer.Text = $"The middle age of students from {curatorName}'s " +
                $"group is {Math.Round(middleAge, 0)}";
        }

        /// <summary>
        /// Write text to text box, depending on selected item of combo box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxChooseAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxChooseAction.SelectedIndex)
            {
                case comboBoxFirstActionIndex:
                    richTextBoxEnterIdText.Text = "Id of group";
                    break;
                case comboBoxSecondActionIndex:
                    richTextBoxEnterIdText.Text = "Id of student";
                    break;
                case comboBoxThirdActionIndex:
                    richTextBoxEnterIdText.Text = "Id of curator";
                    break;
            }
        }

        /// <summary>
        /// Deletes all students from table "Students".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCleanStudentsTable_Click(object sender, EventArgs e)
        {
            try { facade = facade.DeleteAllStudents((Facade)facade); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
        }

        /// <summary>
        /// Deletes all groups from table "Groups.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCleanGroupsTable_Click(object sender, EventArgs e)
        {
            try { facade = facade.DeleteAllGroups((Facade)facade); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
        }

        /// <summary>
        /// Deletes all curators from table "Curators".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCleanCuratorsTable_Click(object sender, EventArgs e)
        {
            try { facade = facade.DeleteAllCurators((Facade)facade); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
        }

        private void richTextBoxEnterIdValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                richTextBoxAnswer.Clear();
                switch (comboBoxChooseAction.SelectedIndex)
                {
                    case comboBoxFirstActionIndex:
                        DoFirstAction();
                        break;
                    case comboBoxSecondActionIndex:
                        DoSecondAction();
                        break;
                    case comboBoxThirdActionIndex:
                        DoThirdAction();
                        break;
                }
            }
        }
    }
}
