﻿using SchoolOfExcellence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOfWeek = SchoolOfExcellence.Database.DayOfWeek;

namespace SchoolOfExcellence
{
    public static class DataAccess
    {
        public static List<Cabinet> GetCabinets()
        {
            return new List<Cabinet>(Connection.BdConnection.Cabinet).ToList();
        }

        public static List<SkipVisit> GetSkipVisits()
        {
            return new List<SkipVisit>(Connection.BdConnection.SkipVisit).ToList();
        }

        public static List<DayOfWeek> GetDaysOfWeek()
        {
            return new List<DayOfWeek>(Connection.BdConnection.DayOfWeek).ToList();
        }
        // schedule
        public static List<Schedule> GetSchedules()
        {
            return new List<Schedule>(Connection.BdConnection.Schedule).Where(a => a.Date.Value.Date >= DateTime.Now.Date).ToList();
        }

        //public static List<Schedule> GetSchedule(string week)
        //{
        //    return GetSchedules().Where(a => a.DayOfWeek.Name == week).ToList();
        //}

        public static void AddSchedule(Schedule schedule)
        {
            Connection.BdConnection.Schedule.Add(schedule);
            Connection.BdConnection.SaveChanges();
        }
        
        // teachers
        public static List<Teacher> GetTeachers()
        {
            return new List<Teacher>(Connection.BdConnection.Teacher.Where(a=>a.IsActive == true)).ToList();
        }

        public static Teacher GetTeacher(int idUser)
        {
            return GetTeachers().Where(a => a.IdUser == idUser).FirstOrDefault();
        }

        // activities
        public static List<Activity> GetActivities()
        {
            return new List<Activity>(Connection.BdConnection.Activity.Where(a=>a.IsActive == true)).ToList();
        }

        public static List<TeacherActivity> GetTeachersActivities()
        {
            return new List<TeacherActivity>(Connection.BdConnection.TeacherActivity).ToList();
        }

        public static List<TeacherActivity> GetTeachersInActivities(int idActivity)
        {
            return GetTeachersActivities().Where(a => a.IdActivity == idActivity).ToList();
        }

        public static List<TeacherActivity> GetActivitiesInTeacher(int idTeacher)
        {
            return GetTeachersActivities().Where(a => a.IdTeacher == idTeacher).ToList();
        }

        public static List<StudentActivity> GetStudentsActivities()
        {
            return new List<StudentActivity>(Connection.BdConnection.StudentActivity.Where(a=>a.IsActive == true)).ToList();
        }

        public static List<StudentActivity> GetStudentsInActivities(int idActivity)
        {
            return GetStudentsActivities().Where(a => a.IdTeacherActivity == idActivity).ToList();
        }

        public static List<Student> GetStudents()
        {
            return new List<Student>(Connection.BdConnection.Student).ToList();
        }

        // headmaster
        public static List<Headmaster> GetHeadmasters()
        {
            return new List<Headmaster>(Connection.BdConnection.Headmaster).ToList();
        }

        public static Headmaster GetHeadmaster(int idUser)
        {
            return GetHeadmasters().Where(a => a.IdUser == idUser).FirstOrDefault();
        }

        // users
        public static List<User> GetUsers()
        {
            return new List<User>(Connection.BdConnection.User).ToList();
        }

        public static bool IsCorrectUser(string email, string password)
        {
            var user = GetUsers().Where(a => email == a.Login && password == a.Password).FirstOrDefault();

            if (user != null && user.IdRole == 2)
            {
                CurrentUser.User = user;
                CurrentUser.Teacher = GetTeacher(CurrentUser.User.Id);
                return true;
            }
            else if (user != null && user.IdRole == 1)
            {
                CurrentUser.User = user;
                CurrentUser.Headmaster = GetHeadmaster(CurrentUser.User.Id);
                return true;
            }
            else
                return false;
        }
    }
}
