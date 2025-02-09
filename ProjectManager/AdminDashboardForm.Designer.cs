﻿
namespace ProjectManagement
{
    partial class AdminDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboardForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.searchUserNameTxtBox = new System.Windows.Forms.TextBox();
            this.deleteAccountBtn = new System.Windows.Forms.Button();
            this.updateStatusBtn = new System.Windows.Forms.Button();
            this.blockRadioBtn = new System.Windows.Forms.RadioButton();
            this.unVerifiedRadioBtn = new System.Windows.Forms.RadioButton();
            this.verifiedRadioBtn = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.emailTexbox = new System.Windows.Forms.TextBox();
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.currentUsersGridView = new System.Windows.Forms.DataGridView();
            this.notifyUsersBtn = new System.Windows.Forms.Button();
            this.logOutBtn = new System.Windows.Forms.Button();
            this.notificationsBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentUsersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.notificationsBtn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.searchUserNameTxtBox);
            this.groupBox1.Controls.Add(this.deleteAccountBtn);
            this.groupBox1.Controls.Add(this.updateStatusBtn);
            this.groupBox1.Controls.Add(this.blockRadioBtn);
            this.groupBox1.Controls.Add(this.unVerifiedRadioBtn);
            this.groupBox1.Controls.Add(this.verifiedRadioBtn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.emailTexbox);
            this.groupBox1.Controls.Add(this.fullNameTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.currentUsersGridView);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(13, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1048, 635);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Search by name ";
            // 
            // searchUserNameTxtBox
            // 
            this.searchUserNameTxtBox.Location = new System.Drawing.Point(169, 52);
            this.searchUserNameTxtBox.Name = "searchUserNameTxtBox";
            this.searchUserNameTxtBox.Size = new System.Drawing.Size(357, 30);
            this.searchUserNameTxtBox.TabIndex = 13;
            this.searchUserNameTxtBox.TextChanged += new System.EventHandler(this.searchUserNameTxtBox_TextChanged);
            // 
            // deleteAccountBtn
            // 
            this.deleteAccountBtn.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAccountBtn.ForeColor = System.Drawing.Color.Black;
            this.deleteAccountBtn.Location = new System.Drawing.Point(490, 547);
            this.deleteAccountBtn.Name = "deleteAccountBtn";
            this.deleteAccountBtn.Size = new System.Drawing.Size(113, 43);
            this.deleteAccountBtn.TabIndex = 12;
            this.deleteAccountBtn.Text = "Delete Account";
            this.deleteAccountBtn.UseVisualStyleBackColor = true;
            this.deleteAccountBtn.Click += new System.EventHandler(this.deleteAccountBtn_Click);
            // 
            // updateStatusBtn
            // 
            this.updateStatusBtn.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateStatusBtn.ForeColor = System.Drawing.Color.Black;
            this.updateStatusBtn.Location = new System.Drawing.Point(490, 468);
            this.updateStatusBtn.Name = "updateStatusBtn";
            this.updateStatusBtn.Size = new System.Drawing.Size(113, 45);
            this.updateStatusBtn.TabIndex = 11;
            this.updateStatusBtn.Text = "Update Status";
            this.updateStatusBtn.UseVisualStyleBackColor = true;
            this.updateStatusBtn.Click += new System.EventHandler(this.updateStatusBtn_Click);
            // 
            // blockRadioBtn
            // 
            this.blockRadioBtn.AutoSize = true;
            this.blockRadioBtn.Location = new System.Drawing.Point(271, 585);
            this.blockRadioBtn.Name = "blockRadioBtn";
            this.blockRadioBtn.Size = new System.Drawing.Size(71, 27);
            this.blockRadioBtn.TabIndex = 10;
            this.blockRadioBtn.TabStop = true;
            this.blockRadioBtn.Text = "Block";
            this.blockRadioBtn.UseVisualStyleBackColor = true;
            this.blockRadioBtn.CheckedChanged += new System.EventHandler(this.blockRadioBtn_CheckedChanged);
            // 
            // unVerifiedRadioBtn
            // 
            this.unVerifiedRadioBtn.AutoSize = true;
            this.unVerifiedRadioBtn.Location = new System.Drawing.Point(141, 585);
            this.unVerifiedRadioBtn.Name = "unVerifiedRadioBtn";
            this.unVerifiedRadioBtn.Size = new System.Drawing.Size(108, 27);
            this.unVerifiedRadioBtn.TabIndex = 9;
            this.unVerifiedRadioBtn.TabStop = true;
            this.unVerifiedRadioBtn.Text = "Unverified";
            this.unVerifiedRadioBtn.UseVisualStyleBackColor = true;
            this.unVerifiedRadioBtn.CheckedChanged += new System.EventHandler(this.unVerifiedRadioBtn_CheckedChanged);
            // 
            // verifiedRadioBtn
            // 
            this.verifiedRadioBtn.AutoSize = true;
            this.verifiedRadioBtn.Location = new System.Drawing.Point(22, 585);
            this.verifiedRadioBtn.Name = "verifiedRadioBtn";
            this.verifiedRadioBtn.Size = new System.Drawing.Size(88, 27);
            this.verifiedRadioBtn.TabIndex = 8;
            this.verifiedRadioBtn.TabStop = true;
            this.verifiedRadioBtn.Text = "Verified";
            this.verifiedRadioBtn.UseVisualStyleBackColor = true;
            this.verifiedRadioBtn.CheckedChanged += new System.EventHandler(this.verifiedRadioBtn_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 547);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Status :";
            // 
            // emailTexbox
            // 
            this.emailTexbox.Enabled = false;
            this.emailTexbox.Location = new System.Drawing.Point(124, 506);
            this.emailTexbox.Name = "emailTexbox";
            this.emailTexbox.Size = new System.Drawing.Size(254, 30);
            this.emailTexbox.TabIndex = 6;
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.Enabled = false;
            this.fullNameTextBox.Location = new System.Drawing.Point(125, 465);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(254, 30);
            this.fullNameTextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 509);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Email :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Full Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 435);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "User Info :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Users :";
            // 
            // currentUsersGridView
            // 
            this.currentUsersGridView.AllowUserToAddRows = false;
            this.currentUsersGridView.AllowUserToDeleteRows = false;
            this.currentUsersGridView.AllowUserToResizeColumns = false;
            this.currentUsersGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.currentUsersGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.currentUsersGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.currentUsersGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.currentUsersGridView.BackgroundColor = System.Drawing.Color.LightGray;
            this.currentUsersGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.currentUsersGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.currentUsersGridView.ColumnHeadersHeight = 29;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.currentUsersGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.currentUsersGridView.EnableHeadersVisualStyles = false;
            this.currentUsersGridView.Location = new System.Drawing.Point(15, 97);
            this.currentUsersGridView.MultiSelect = false;
            this.currentUsersGridView.Name = "currentUsersGridView";
            this.currentUsersGridView.ReadOnly = true;
            this.currentUsersGridView.RowHeadersVisible = false;
            this.currentUsersGridView.RowHeadersWidth = 51;
            this.currentUsersGridView.RowTemplate.Height = 24;
            this.currentUsersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.currentUsersGridView.Size = new System.Drawing.Size(1010, 314);
            this.currentUsersGridView.TabIndex = 0;
            this.currentUsersGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.currentUsersGridView_CellClick);
            // 
            // notifyUsersBtn
            // 
            this.notifyUsersBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.notifyUsersBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.notifyUsersBtn.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notifyUsersBtn.ForeColor = System.Drawing.Color.White;
            this.notifyUsersBtn.Location = new System.Drawing.Point(12, 11);
            this.notifyUsersBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.notifyUsersBtn.Name = "notifyUsersBtn";
            this.notifyUsersBtn.Size = new System.Drawing.Size(132, 54);
            this.notifyUsersBtn.TabIndex = 2;
            this.notifyUsersBtn.Text = "Notify Users";
            this.notifyUsersBtn.UseVisualStyleBackColor = false;
            // 
            // logOutBtn
            // 
            this.logOutBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.logOutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logOutBtn.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutBtn.ForeColor = System.Drawing.Color.White;
            this.logOutBtn.Location = new System.Drawing.Point(952, 11);
            this.logOutBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logOutBtn.Name = "logOutBtn";
            this.logOutBtn.Size = new System.Drawing.Size(103, 54);
            this.logOutBtn.TabIndex = 3;
            this.logOutBtn.Text = "Log out";
            this.logOutBtn.UseVisualStyleBackColor = false;
            this.logOutBtn.Click += new System.EventHandler(this.logOutBtn_Click);
            // 
            // notificationsBtn
            // 
            this.notificationsBtn.Image = global::ProjectManagement.Properties.Resources.Bell_Inactive;
            this.notificationsBtn.Location = new System.Drawing.Point(977, 29);
            this.notificationsBtn.Name = "notificationsBtn";
            this.notificationsBtn.Size = new System.Drawing.Size(48, 48);
            this.notificationsBtn.TabIndex = 15;
            this.notificationsBtn.UseVisualStyleBackColor = true;
            this.notificationsBtn.Click += new System.EventHandler(this.notificationsBtn_Click);
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1073, 725);
            this.Controls.Add(this.logOutBtn);
            this.Controls.Add(this.notifyUsersBtn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AdminDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminDashboardForm_FormClosed);
            this.Load += new System.EventHandler(this.AdminDashboardForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentUsersGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView currentUsersGridView;
        private System.Windows.Forms.Button deleteAccountBtn;
        private System.Windows.Forms.Button updateStatusBtn;
        private System.Windows.Forms.RadioButton blockRadioBtn;
        private System.Windows.Forms.RadioButton unVerifiedRadioBtn;
        private System.Windows.Forms.RadioButton verifiedRadioBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox emailTexbox;
        private System.Windows.Forms.TextBox fullNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button notifyUsersBtn;
        private System.Windows.Forms.Button logOutBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox searchUserNameTxtBox;
        private System.Windows.Forms.Button notificationsBtn;
    }
}