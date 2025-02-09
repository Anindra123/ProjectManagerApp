﻿using ProjectManagement.ClassFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagement
{
    //delegate signatures 
    public delegate bool UpdateGroups(string gName, int memCount);
    public delegate bool RemoveGroup();
    public delegate bool RemoveProjects();
    public partial class UpdateGroupInfo : Form
    {
        ProjectManager pM;
        ProjectGroup pG = new ProjectGroup();
        ProjectMember pMember = new ProjectMember();
        ProjectTask pT = new ProjectTask();
        Validations validations = new Validations();
        Project project = new Project();
        BackLog backLog = new BackLog();
        public UpdateGroupInfo()
        {
            InitializeComponent();
        }
        public UpdateGroupInfo(ProjectManager pM)
        {
            InitializeComponent();
            this.pM = pM;
        }
        void ShowPreviousMenu()
        {
            //Goes to the previous control
            var form = (updatePManagerInfo)Tag;
            form.IntializeForm();
            form.Show();
        }
        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            ShowPreviousMenu();
            this.Close();
        }

        private void AddMemberBtn_Click(object sender, EventArgs e)
        {
            int numOfMembers = 0;
            Project proj = pM.GetProject(pG.PGroup_ID);


            if (!int.TryParse(memberCountTextBox.Text.Trim(), out numOfMembers))
            {
                validations.ShowAlert("Invalid Member Count");
            }
            else if (numOfMembers <= 0)
            {
                validations.ShowAlert("Invalid Member Count");

            }
            else
            {

                SearchAndAddMember addMember = new SearchAndAddMember(pG, proj, numOfMembers);
                if (addMember.ShowDialog() == DialogResult.Cancel)
                {
                    currentMembersGridView.DataSource = pG.FillMemberList();
                    currentMembersGridView.Update();
                    currentMembersGridView.Refresh();
                }
            }

        }

        private void RemoveMemberBtn_Click(object sender, EventArgs e)
        {
            if (currentMembersGridView.SelectedRows.Count > 0)
            {
                //selecting row from a data grid view
                DataGridViewRow row = currentMembersGridView.SelectedRows[0];
                string mail = (string)row.Cells["Email"].Value;
                pMember.SearchMember(mail);
                if (pT.CheckTaskAssingedToMember(pMember.UserID) != null)
                {
                    DialogResult r = MessageBox.Show("Member has some work progress.If you remove his/her progress will be lost.Continue ?",
                        "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        //looping through rows of datatable
                        DataTable dt = pT.CheckTaskAssingedToMember(pMember.UserID);
                        foreach (DataRow taskRow in dt.Rows)
                        {
                            int id = (int)taskRow["Task_ID"];
                            pMember.RemoveAllAssignedTask(id);

                        }
                        int pMember_ID = pMember.UserID;
                        if (pMember.DeleteMemberGroupInfoTable(pMember_ID) &&
                        pMember.DeleteMemberProjInfoTable(pMember_ID))
                        {
                            DialogResult result = validations.ShowInfo("Member removed Sucessfully");
                            if (result == DialogResult.OK)
                            {
                                currentMembersGridView.DataSource = pG.FillMemberList();
                                currentMembersGridView.Update();
                                currentMembersGridView.Refresh();
                            }
                        }
                    }
                }
                else
                {
                    DialogResult r = MessageBox.Show("Confirm Remove ?",
                       "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        int pMember_ID = pMember.UserID;
                        if (pMember.DeleteMemberGroupInfoTable(pMember_ID) &&
                       pMember.DeleteMemberProjInfoTable(pMember_ID))
                        {
                            DialogResult result = validations.ShowInfo("Member removed Sucessfully");
                            if (result == DialogResult.OK)
                            {
                                currentMembersGridView.DataSource = pG.FillMemberList();
                                currentMembersGridView.Update();
                                currentMembersGridView.Refresh();
                            }
                        }
                    }
                }
            }
            else
            {
                validations.ShowAlert("Please select a member to remove");
            }
        }
        private void ResetForm()
        {
            //resets form feilds with default value or
            //updated value
            currentPManagerGroupsComboBox.DataSource = null;
            pM.GetProjectGroups();
            currentPManagerGroupsComboBox.DisplayMember = "PGroup_name";
            currentPManagerGroupsComboBox.ValueMember = "PGroup_ID";
            currentPManagerGroupsComboBox.DataSource = pM.ProjectGroups;
            currentPManagerGroupsComboBox.SelectedIndex = -1;
            discardGroupBtn.Enabled = false;
            RemoveMemberBtn.Enabled = false;
            memberCountTextBox.Enabled = false;
            groupNameTxtBox.Enabled = false;
            UpdateBtn.Enabled = false;
            AddMemberBtn.Enabled = false;
            groupNameTxtBox.Text = null;
            memberCountTextBox.Text = null;
            currentMembersGridView.DataSource = null;

        }
        private void UpdateGroupInfo_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void UpdateGroupInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShowPreviousMenu();
        }

        private void currentPManagerGroupsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //will update members list based on the current group
            //being selected from drop down list
            if (currentPManagerGroupsComboBox.SelectedIndex >= 0)
            {
                AddMemberBtn.Enabled = true;
                memberCountTextBox.Enabled = true;
                groupNameTxtBox.Enabled = true;
                UpdateBtn.Enabled = true;
                pG = (ProjectGroup)currentPManagerGroupsComboBox.SelectedItem;
                groupNameTxtBox.Text = pG.PGroup_Name;
                memberCountTextBox.Text = $"{pG.MembersCount}";
                discardGroupBtn.Enabled = true;
                if (pG.FillMemberList() != null)
                {
                    currentMembersGridView.DataSource = pG.FillMemberList();
                    currentMembersGridView.ClearSelection();
                    RemoveMemberBtn.Enabled = true;
                }
                else
                {
                    currentMembersGridView.DataSource = null;
                    RemoveMemberBtn.Enabled = false;
                }

            }
            else
            {
                currentPManagerGroupsComboBox.SelectedIndex = -1;
                groupNameTxtBox.Text = null;
                memberCountTextBox.Text = null;
                currentMembersGridView.DataSource = null;
                discardGroupBtn.Enabled = false;
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            int numOfMembers = 0;
            if (string.IsNullOrWhiteSpace(groupNameTxtBox.Text.Trim()) ||
                string.IsNullOrWhiteSpace(memberCountTextBox.Text.Trim()))
            {
                validations.ShowAlert("Text feilds cannot be empty");
            }
            else if (!int.TryParse(memberCountTextBox.Text.Trim(), out numOfMembers))
            {
                validations.ShowAlert("Invalid Member Count");
            }
            else if (numOfMembers <= 0)
            {
                validations.ShowAlert("Invalid Member Count");

            }
            else if (groupNameTxtBox.Text.Trim() != pG.PGroup_Name &&
               pG.SearchGroup(groupNameTxtBox.Text.Trim()))
            {
                validations.ShowAlert("A group with the same name already exists");

            }
            else if (pG.FillMemberList() != null && pG.FillMemberList().Rows.Count > numOfMembers)
            {
                validations.ShowAlert("Number of members added exceeds member count");
            }
            else
            {
                string gName = groupNameTxtBox.Text.Trim();
                //int memCount = Convert.ToInt32(memberCountTextBox.Text.Trim());
                UpdateGroups updateGroups = pG.UpdateGroupContainsProjectTable;
                updateGroups += pG.UpdatePManagerGroupInfoTable;
                updateGroups += pG.UpdatePGroupTable;
                if (updateGroups(gName, numOfMembers))
                {
                    DialogResult r = validations.ShowInfo("Updated Sucessfully");
                    if (r == DialogResult.OK)
                    {
                        ResetForm();
                    }
                }
            }
        }
        private void RemoveTasksAndPlaceInBackLog()
        {
            //will remove each task for current project 
            // on the current group if the group is discarded
            int projId = project.Project_ID;
            foreach (DataRow row in pT.GetTaskListFromProject(projId).Rows)
            {
                pT.Task_ID = (int)row["ID"];
                pT.Task_Title = (string)row["Title"];
                string status = (string)row["Status"];
                pG.GetProjectGroupFromTask(pT.Task_ID);
                project.GetProjectInfoFromTask(pT.Task_ID);
                pMember.GetProjectMemberFromTask(pT.Task_ID);
                backLog.BackLog_GroupName = pG.PGroup_Name;
                backLog.BackLog_ProjectTitle = project.Project_Title;
                if (status == "Pending")
                {
                    backLog.BackLog_TaskCompleted = "None";
                }
                if (status == "Completed")
                {
                    backLog.BackLog_TaskCompleted = $"{pMember.FirstName} {pMember.LastName}";
                }
                backLog.BackLog_TaskTitle = pT.Task_Title;
                backLog.PManager_ID = pM.UserID;
                backLog.InsertBackLogData();
                //RemoveTaskFromTables multicasted deligate 
                //intance created
                RemoveTaskFromTables removeTask = pT.DeleteFromAssignTaskTable;
                removeTask += pT.DeleteFromPerformTaskTable;
                removeTask += pT.DeleteFromTaskTable;
                removeTask();
            }
        }
        private void RemoveMembersFromGroup()
        {
            //removes all members from current group if 
            //group is discarded
            int g_id = pG.PGroup_ID;
            DataTable members = pG.FillMemberList(g_id);
            if (members != null)
            {
                foreach (DataRow row in members.Rows)
                {
                    int mem_id = (int)row["PMember_ID"];
                    pMember.DeleteMemberGroupInfoTable(mem_id);
                    pMember.DeleteMemberProjInfoTable(mem_id);
                }
            }
        }
        private void discardGroupBtn_Click(object sender, EventArgs e)
        {
            project = pM.GetProject(pG.PGroup_ID);
            DataTable tasks = pT.GetTaskListFromProject(project.Project_ID);
            if (tasks != null)
            {
                DialogResult r = MessageBox.Show("Confirm discard ? All the project progress will be lost", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    //if some tasks exist which means the project 
                    //was not completed those task will be discarded
                    //and then members are removed form group
                    RemoveTasksAndPlaceInBackLog();
                    RemoveMembersFromGroup();
                    //RemoveGroup multicasted deligate instance created
                    RemoveGroup removeGroups = pG.RemoveGroupContainsProject;
                    removeGroups += pG.RemovePManagerGroupInfo;
                    removeGroups += pG.RemovePGroup;
                    //RemoveProjects multicasted deligate instance created
                    RemoveProjects removeProjects = project.RemoveManagerProject_TBL;
                    removeProjects += project.RemoveProject_TBL;
                    if (removeGroups() && removeProjects())
                    {
                        DialogResult res = validations.ShowInfo("Group Discarded Sucessfully");
                        if (res == DialogResult.OK)
                        {
                            currentPManagerGroupsComboBox.SelectedIndex = 0;
                            ResetForm();
                        }
                    }
                }
            }
            else
            {
                //else if no task currently active and all are completed
                //which meanse project is completed so the group will be 
                //discarded
                DialogResult r = MessageBox.Show("Confirm discard ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    RemoveMembersFromGroup();
                    RemoveGroup removeGroups = pG.RemoveGroupContainsProject;
                    removeGroups += pG.RemovePManagerGroupInfo;
                    removeGroups += pG.RemovePGroup;
                    RemoveProjects removeProjects = project.RemoveManagerProject_TBL;
                    removeProjects += project.RemoveProject_TBL;
                    if (removeGroups() && removeProjects())
                    {
                        DialogResult res = validations.ShowInfo("Group Discarded Sucessfully");
                        if (res == DialogResult.OK)
                        {
                            currentPManagerGroupsComboBox.SelectedIndex = 0;

                            ResetForm();
                        }
                    }
                }
            }

        }
    }
}
