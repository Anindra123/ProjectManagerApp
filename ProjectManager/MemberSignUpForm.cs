﻿using ProjectManagement.ClassFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagement
{
    public partial class MemberSignUpForm : Form
    {
        //defined a regular expression for mail validation
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        ProjectMember projectMember = new ProjectMember();
        ProjectGroup projectGroup = new ProjectGroup();
        ProjectManager projectManager = new ProjectManager();
        Project project = new Project();
        public MemberSignUpForm()
        {
            InitializeComponent();
            memberOfGroupNoRadioBtn.Checked = true;
            ValidateMemberOfGroup();
        }
        void BackToHomeMenu()
        {
            //Close the current form and the form before it
            //And show homepage
            var form1 = (ContinueAsProjectMemberForm)Tag;
            var form2 = (ProjectManagementStartForm)form1.Tag;
            form1.Close();
            form2.Show();

        }
        void DisableGroupInfoForm(bool en)
        {
            //disables/enables all the fields in group info
            if (en == true)
            {
                enterGroupNameTextBox.Enabled = false;
                groupConfirmBtn.Enabled = false;
                groupInfoBox.Enabled = false;
            }
            else
            {
                enterGroupNameTextBox.Enabled = true;
                groupConfirmBtn.Enabled = true;
                groupInfoBox.Enabled = true;

            }

        }
        void ResetGroupFeilds()
        {
            enterGroupNameTextBox.Text = null;
            projGroupNameLabel.Text = "none";
            projNameLabel.Text = "none";
            projectManagerLabel.Text = "none";
        }
        void ResetSignUpFeilds()
        {
            projectMemberEmailTextBox.Text = null;
            projMemFirstNameTextBox.Text = null;
            projMLastNameTextBox.Text = null;
            projMemberPasswordTextBox.Text = null;
            memberOfGroupNoRadioBtn.Checked = true;
            ResetGroupFeilds();

        }
        void ValidateMemberOfGroup()
        {
            //Checks which radio button has been clicked
            //disable or enables form based on it
            if (memberOfGroupNoRadioBtn.Checked == true)
            {
                DisableGroupInfoForm(true);
            }
            if (memberOfGroupYesRadioBtn.Checked == true)
            {
                DisableGroupInfoForm(false);
            }
        }
        void ShowPreviousMenu()
        {
            //Goes to the previous control
            var form = (ContinueAsProjectMemberForm)Tag;
            form.Show();
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ShowPreviousMenu();
            this.Close();
        }

        private void MemberSignUpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShowPreviousMenu();
        }

        private void goBackHomePageBtn_Click(object sender, EventArgs e)
        {
            BackToHomeMenu();
            this.Close();
        }
        bool validateGroupInfoForm()
        {
            //Check whether user has been added to a project group
            if ((memberOfGroupYesRadioBtn.Checked &&
                     !projNameLabel.Text.Equals("none") &&
                     !String.IsNullOrWhiteSpace(projNameLabel.Text)
                   && !projGroupNameLabel.Text.Equals("none")
                   && !String.IsNullOrWhiteSpace(projGroupNameLabel.Text)
                   && !projectManagerLabel.Text.Equals("none")
                   && !String.IsNullOrWhiteSpace(projectManagerLabel.Text)
                   )
                   || memberOfGroupNoRadioBtn.Checked == true)
            {
                return true;
            }
            return false;
        }
        bool validateMatchingMailAndPass()
        {
            if (!projectMember.CheckDuplicateMailAndPass(projectMemberEmailTextBox.Text.Trim(),
                projMemberPasswordTextBox.Text.Trim()))
            {
                return true;
            }
            return false;
        }
        private void projMemberSignUpBtn_Click(object sender, EventArgs e)
        {
            //Check the main fields
            if (!string.IsNullOrWhiteSpace(projMemFirstNameTextBox.Text.Trim())
                && !string.IsNullOrWhiteSpace(projMLastNameTextBox.Text.Trim())
                && !string.IsNullOrWhiteSpace(projMemberPasswordTextBox.Text.Trim())
                && !string.IsNullOrWhiteSpace(projectMemberEmailTextBox.Text.Trim())
                )
            {
                //Email validation
                if (Regex.IsMatch(projectMemberEmailTextBox.Text.Trim(), pattern))
                {
                    if (projMemberPasswordTextBox.Text.Trim().Length <= 8)
                    {
                        //Validate the group info feild
                        if (validateGroupInfoForm())
                        {

                            if (validateMatchingMailAndPass())
                            {
                                bool val = projectMember.SignUPProjectMember(
                                projMemFirstNameTextBox.Text.Trim(),
                                projMLastNameTextBox.Text.Trim(),
                                projectMemberEmailTextBox.Text.Trim(),
                                projMemberPasswordTextBox.Text.Trim()
                                );


                                if (memberOfGroupYesRadioBtn.Checked == true)
                                {
                                    projectMember.SaveGroupInfo(projectGroup.PGroup_ID);
                                    projectMember.SaveProjectInfo(project.Project_ID);
                                }
                                if (val == true)
                                {

                                    DialogResult result = MessageBox.Show("Sign Up Sucessful", "Sucess",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (result == DialogResult.OK)
                                    {
                                        ResetSignUpFeilds();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("An Entry with same name/email or password already exist. Try something different", "Alert",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Not enough information given", "Alert",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password can be 8 characters long", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Email Is Invalid", "Alert",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Text fields Cannot Be Empty", "Alert",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void memberOfGroupYesRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            ValidateMemberOfGroup();
        }

        private void memberOfGroupNoRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            ValidateMemberOfGroup();
            ResetGroupFeilds();
        }

        private void groupConfirmBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(enterGroupNameTextBox.Text))
            {
                if (projectGroup.SearchGroup(enterGroupNameTextBox.Text.Trim()))
                {
                    DialogResult result = MessageBox.Show($"Found {projectGroup.PGroup_Name}", "Sucess",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        projGroupNameLabel.Text = projectGroup.PGroup_Name;
                        project.GetProjectTitleForMember(projectGroup.Project_ID);
                        projNameLabel.Text = project.Project_Title;
                        projectManager.GetProjectManagerTitleForMember(project.Project_ID);
                        projectManagerLabel.Text = $"{projectManager.FirstName} {projectManager.LastName}";
                    }
                }
                else
                {
                    MessageBox.Show("Group not found or Invalid Group Name", "Alert",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Entered Invalid Email", "Alert",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void projMemFirstNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
