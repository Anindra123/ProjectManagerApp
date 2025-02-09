﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.ClassFiles
{
    public class ProjectTask
    {

        public int Task_ID { get; set; }
        public string Task_Title { get; set; }
        public string Task_Desc { get; set; }
        public int Task_Completed { get; set; }
        public string Task_Comment { get; set; }
        public byte[] Task_Attached { get; set; }


        DataTable dt = new DataTable();

        /// <summary>
        /// Common function 
        /// used to reset the datatable data and fill the datatable
        /// with new data
        /// </summary>
        public void FillData(string query)
        {
            dt.Clear();
            dt.Columns.Clear();
            dt.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnString()))
            {
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.Fill(dt);
            }
        }
        /// <summary>
        /// Common function 
        /// used to open database connection and run executeNonQuery command
        /// and the number of rows effected boolean value is returned
        /// </summary>
        public bool RunQuery(string query)
        {
            bool ret = false;
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnString()))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    ret = true;
                }
            }
            return ret;
        }
        /// <summary>
        /// checks whether member is assigned a task
        /// takes only the project member id
        /// </summary>
        public DataTable CheckTaskAssingedToMember(int pm_id)
        {

            string query = $"select * from PerformTask_TBL where " +
                $"PMember_ID = '{pm_id}'";
            FillData(query);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
        /// <summary>
        /// checks whether member is assigned a task
        /// takes both the project member id and task id
        /// </summary>
        public bool CheckTaskAssingedToMember(int pm_id, int task_id)
        {

            string query = $"select * from PerformTask_TBL where " +
                $"PMember_ID = '{pm_id}' and Task_ID = '{task_id}'";
            FillData(query);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Deletes tasks from respected tables
        /// </summary>
        public bool DeleteFromTaskTable()
        {
            string query = $"delete from Task_TBL where " +
                $"Task_ID = '{Task_ID}'";
            return RunQuery(query);
        }
        public bool DeleteFromAssignTaskTable()
        {
            string query = $"delete from AssignTask_TBL where " +
                   $"Task_ID = '{Task_ID}'";
            return RunQuery(query);
        }
        public bool DeleteFromPerformTaskTable()
        {
            string query = $"delete from PerformTask_TBL where " +
                   $"Task_ID = '{Task_ID}'";
            return RunQuery(query);
        }
        /// <summary>
        /// Returns what the current status of task is in boolean
        /// </summary>
        public bool CheckTaskStatus(int s_id)
        {
            string s;
            string query = $"select StatusName from TaskStatus_TBL where StatusID = '{s_id}'";
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnString()))
            {
                SqlCommand cmnd = new SqlCommand(query, conn);
                cmnd.Connection.Open();
                s = (string)cmnd.ExecuteScalar();
            }
            if (s == "Pending")
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns all the task data that was assigned to project member
        /// </summary>
        public DataTable FillAssignedTaskList(int pm_id)
        {
            string query = $"select pt.Task_Title as Title,pt.Task_Desc as Description,ts.StatusName as Status from " +
                $"PerformTask_TBL as pt,TaskStatus_TBL as ts where " +
                $"pt.PMember_ID = '{pm_id}' and ts.StatusID = pt.Task_Completed;";
            FillData(query);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
        /// <summary>
        /// Returns the status of task in string
        /// </summary>
        public string GetStatus()
        {
            string s;
            string query = $"select StatusName from TaskStatus_TBL where StatusID = '{Task_Completed}'";
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnString()))
            {
                SqlCommand cmnd = new SqlCommand(query, conn);
                cmnd.Connection.Open();
                s = (string)cmnd.ExecuteScalar();
            }
            return s;
        }
        /// <summary>
        /// If a task is completed its attached file and comment will be 
        /// retrived
        /// </summary>
        public bool GetCompletedTask()
        {
            string query = $"select Task_Attached,Task_Comment from PerformTask_TBL" +
                $" where Task_ID = '{Task_ID}' ";
            FillData(query);
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0]["Task_Attached"] != null && dt.Rows[0]["Task_Comment"] != null)
                {

                    Task_Attached = (byte[])dt.Rows[0]["Task_Attached"];
                    Task_Comment = $"{dt.Rows[0]["Task_Comment"]}";
                    return true;
                }

            }
            return false;
        }
        /// <summary>
        /// Takes a project id and returns all the created task for the project
        /// </summary>
        public DataTable GetTaskListFromProject(int proj_id)
        {
            string query = $"select at.Task_ID as ID,at.Task_title as Title,at.Task_Desc as Description,ts.StatusName as Status from" +
               $" Task_TBL as at,TaskStatus_TBL as ts" +
               $" where at.Project_ID = '{proj_id}' and ts.StatusID = at.Task_Completed ";
            FillData(query);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }

            return null;

        }
        /// <summary>
        /// Check for duplicate task 
        /// or task having same title
        /// </summary>
        public bool CheckTaskExist(string taskTitle)
        {
            string query = $"select * from Task_TBL where Lower(Task_title) = '{taskTitle}'";
            FillData(query);
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Updates the data from each of the task table
        /// </summary>
        public bool UpdatePerformTaskTable(string tTitle, string tDesc)
        {
            string query = $"update PerformTask_TBL " +
                $"set Task_title = '{tTitle}',Task_Desc = '{tDesc}' " +
                $"where task_ID = '{Task_ID}'";
            return RunQuery(query);
        }
        public bool UpdateAssignTaskTable(string tTitle, string tDesc)
        {
            string query = $"update AssignTask_TBL " +
                $"set Task_title = '{tTitle}',Task_Desc = '{tDesc}' " +
                $"where task_ID = '{Task_ID}'";
            return RunQuery(query);
        }
        public bool UpdateTaskTable(string tTitle, string tDesc)
        {
            string query = $"update Task_TBL " +
                $"set Task_title = '{tTitle}',Task_Desc = '{tDesc}' " +
                $"where task_ID = '{Task_ID}'";
            return RunQuery(query);
        }
    }
}
