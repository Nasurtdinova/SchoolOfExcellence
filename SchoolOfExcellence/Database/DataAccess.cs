using SchoolOfExcellence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolOfExcellence
{
    public static class DataAccess
    {

        public static List<SkipVisit> GetSkipVisits()
        {
            return new List<SkipVisit>(Connection.BdConnection.SkipVisit).ToList();
        }

        // schedule
        public static List<Schedule> GetSchedules()
        {
            return new List<Schedule>(Connection.BdConnection.Schedule).Where(a => a.Date.Value.Date >= DateTime.Now.Date).ToList();
        }

        public static List<Schedule> GetSchedulesPast()
        {
            return new List<Schedule>(Connection.BdConnection.Schedule).Where(a => a.Date.Value.Date <= DateTime.Now.Date).ToList();
        }

        public static void AddSchedule(Schedule schedule)
        {
            Connection.BdConnection.Schedule.Add(schedule);
            Connection.BdConnection.SaveChanges();
        }
        
        // teachers
        public static List<Teacher> GetTeachers()
        {
            return new List<Teacher>(Connection.BdConnection.Teacher).Where(a => a.IsActive == true).ToList();
        }

        public static List<Grade> GetGrades()
        {
            return new List<Grade>(Connection.BdConnection.Grade).ToList();
        }

        public static void SaveTeacher(Teacher teacher)
        {
            teacher.IsActive = true;
            if (teacher.PersonnelNumber == 0)
                Connection.BdConnection.Teacher.Add(teacher);
            Connection.BdConnection.SaveChanges();
        }

        // activities
        public static List<Activity> GetActivities()
        {
            return new List<Activity>(Connection.BdConnection.Activity).Where(a => a.IsActive == true).ToList();
        }

        public static void SaveActivity(Activity activity)
        {
            activity.IsActive = true;
            if (activity.Code == 0)
                Connection.BdConnection.Activity.Add(activity);
            Connection.BdConnection.SaveChanges();
        }

        public static List<TeacherActivity> GetTeachersActivities()
        {
            return new List<TeacherActivity>(Connection.BdConnection.TeacherActivity).Where(a=>a.IsDeleted == false).ToList();
        }
        public static List<TeacherActivity> GetTeachersActivitiesTotal()
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

        public static List<Student> GetStudents()
        {
            return new List<Student>(Connection.BdConnection.Student).ToList();
        }

        public static List<Student> GetStudentsInTeacher(int idTeacher)
        {
            return GetStudents().Where(a => a.Grade.Curator == idTeacher).ToList();
        }

        public static List<Student> GetStudentsInGrade(int? idGrade)
        {
            return GetStudents().Where(a => a.Grade.Id == idGrade).ToList();
        }
    }
}
