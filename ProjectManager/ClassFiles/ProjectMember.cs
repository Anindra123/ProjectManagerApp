﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.ClassFiles
{
    public class ProjectMember : User
    {
        public int PMemberID { get; set; }
        public int PGroupID { get; set; }
        public int Project_ID { get; set; }

        private static DataTable dt = new DataTable();

        private void FillTable(string query)
        {
            dt.Clear();
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnString()))
            {
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.Fill(dt);
            }
        }
        public int GetMemberID()
        {
            int val = 100;
            string query = $"select * from PMember_TBL where " +
                $"PMember_Email = '{this.Email}' AND " +
                $"PMember_Password = '{this.password}';";
            FillTable(query);
            if (dt.Rows.Count == 1)
            {
                val = Convert.ToInt32(dt.Rows[0]["PMember_ID"].ToString());
            }
            return val;
        }
        public bool SignUPProjectMember(string firstName, string LastName,
        string email, string password)
        {
            this.FirstName = firstName;
            this.LastName = LastName;
            this.Email = email;
            this.password = password;
            string query = $"insert into PMember_TBL " +
            $"(PMember_FirstName, PMember_LastName, PMember_Email, PMember_Password) " +
                $"values('{firstName}', '{LastName}', '{email}', '{password}')";
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                PMemberID = GetMemberID();
                return true;
            }

        }
        public bool SignInProjectMember(string email, string password)
        {

            string query = $"select * from PMember_TBL where " +
                $"PMember_Email = '{email}' AND " +
                $"PMember_Password = '{password}';";
            FillTable(query);

            if (dt.Rows.Count == 1)
            {
                this.PMemberID = Convert.ToInt32(dt.Rows[0]["PMember_ID"].ToString());
                this.FirstName = dt.Rows[0]["PMember_FirstName"].ToString();
                this.LastName = dt.Rows[0]["PMember_LastName"].ToString();
                this.Email = dt.Rows[0]["PMember_Email"].ToString();
                this.password = dt.Rows[0]["PMember_Password"].ToString();
                return true;
            }
            return false;
        }

        public void SaveGroupInfo(int g_id)
        {

            string query = $"insert into PMemberGroupInfo_TBL " +
                $"(PMember_ID,PMember_FirstName, PMember_LastName, PMember_Email, PMember_Password,PGroup_ID) " +
                $" values ('{this.PMemberID}','{this.FirstName}', '{this.LastName}', '{this.Email}', '{this.password}','{g_id}') ";
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void SaveProjectInfo(int proj_id)
        {

            string query = $"insert into PMemberProjectInfo_TBL " +
                $"(PMember_ID,PMember_FirstName, PMember_LastName, PMember_Email, PMember_Password,Project_ID) " +
                $" values ('{this.PMemberID}','{this.FirstName}', '{this.LastName}', '{this.Email}', '{this.password}','{proj_id}') ";
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool CheckifGroupMember(int pm_id)
        {
            string query = $"select * from PMemberGroupInfo_TBL where " +
                $"PMember_ID = '{pm_id}';";
            FillTable(query);
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            return false;

        }
    }
}
