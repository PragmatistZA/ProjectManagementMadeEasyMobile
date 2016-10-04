using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XPMMS.Helpers;

namespace XPMMS.DAL
{
    public static class WebService
    {
        private static readonly pmmeWS _pmmeWS = new pmmeWS();

        public static string VerifyUserLogin(string email, string password)
        {
           return _pmmeWS.EndverifyUserLogin(_pmmeWS.BeginverifyUserLogin(email, SHA1.Encode(password), delegate { }, new object()));
        }

        public static string LoginUser(string email, string password)
        {
            return _pmmeWS.EndloginUser(_pmmeWS.BeginloginUser(email, SHA1.Encode(password), delegate { }, new object()));
        }

        public static string AddNewUser(string firstName, string lastName, string email, string password)
        {
            return _pmmeWS.EndaddNewUser(_pmmeWS.BeginaddNewUser(firstName, lastName, email, SHA1.Encode(password), delegate { }, new object()));
        }

        public static string GetUser(string email)
        {
            return _pmmeWS.EndgetUser(_pmmeWS.BegingetUser(email, delegate { }, new object()));
        }

        public static string EditUser(string userId, string title, string firstName, string lastName, string jobDesc, string email, string contact)
        {
            return _pmmeWS.EndeditUser(_pmmeWS.BegineditUser(userId, title, firstName, lastName, jobDesc, email, contact, delegate { }, new object()));
        }

        public static string UserAddNewTeam(string email, string teamName)
        {
            return _pmmeWS.EnduserAddNewTeam(_pmmeWS.BeginuserAddNewTeam(email, teamName, delegate { }, new object()));
        }

        public static string AddUserToTeam(string email, string teamName)
        {
            return _pmmeWS.EndaddUserToTeam(_pmmeWS.BeginaddUserToTeam(email, teamName, delegate { }, new object()));
        }

        public static string GetTeamProjects(string teamName)
        {
            return _pmmeWS.EndgetTeamProjects(_pmmeWS.BegingetTeamProjects(teamName, delegate { }, new object()));
        }

        public static string GetListOfTeams()
        {
            return _pmmeWS.EndgetListOfTeams(_pmmeWS.BegingetListOfTeams(delegate { }, new object()));
        }

        public static string GetTeam(string teamId)
        {
            return _pmmeWS.EndgetTeam(_pmmeWS.BegingetTeam(teamId, delegate { }, new object()));
        }

        public static string GetTeamMembers(string teamId)
        {
            return _pmmeWS.EndgetTeamMembers(_pmmeWS.BegingetTeamMembers(teamId, delegate { }, new object()));
        }

        public static string AddTask(string projectId, string taskDesc, string timeReq, string taskCreated, string taskDue)
        {
            return _pmmeWS.EndaddTask(_pmmeWS.BeginaddTask(projectId, taskDesc, timeReq, taskCreated, taskDue, delegate { }, new object()));
        }

        public static string AddNewProject(string projectManagerId, string teamId, string projectDesc, string projectName)
        {
            return _pmmeWS.EndaddNewProject(_pmmeWS.BeginaddNewProject(projectManagerId, teamId, projectDesc, projectName, delegate { }, new object()));
        }

        public static string DeleteTask(string taskId)
        {
            return _pmmeWS.EnddeleteTask(_pmmeWS.BegindeleteTask(taskId, delegate { }, new object()));
        }

        public static string JoinTeam(string userId, string teamId)
        {
            return _pmmeWS.EndjoinTeam(_pmmeWS.BeginjoinTeam(userId, teamId, delegate { }, new object()));
        }

        public static string GetAllUsers()
        {
            return _pmmeWS.EndgetAllUsers(_pmmeWS.BegingetAllUsers(delegate { }, new object()));
        }

        public static string GetAllTeams()
        {
            return _pmmeWS.EndgetAllTeams(_pmmeWS.BegingetAllTeams(delegate { }, new object()));
        }

        public static string GetAllProjects()
        {
            return _pmmeWS.EndgetAllProjects(_pmmeWS.BegingetAllProjects(delegate { }, new object()));
        }

        public static string GetAllTasks()
        {
            return _pmmeWS.EndgetAllTasks(_pmmeWS.BegingetAllTasks(delegate { }, new object()));
        }
    }
}
