using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolOfExcellence
{
    public static class DataAccess
    {
        public static List<User> GetUsers()
        {
            return new List<User>(Connection.BdConnection.User).ToList();
        }

        public static List<Activity> GetActivities()
        {
            return new List<Activity>(Connection.BdConnection.Activity).ToList();
        }

        public static List<TeacherActivity> GetTeachersActivities()
        {
            return new List<TeacherActivity>(Connection.BdConnection.TeacherActivity).ToList();
        }

        public static List<TeacherActivity> GetTeachersInActivities(int idActivity)
        {
            return GetTeachersActivities().Where(a => a.IdActivity == idActivity).ToList();
        }

        public static List<Teacher> GetTeachers()
        {
            return new List<Teacher>(Connection.BdConnection.Teacher).ToList();
        }

        public static Teacher GetTeacher(int idUser)
        {
            return GetTeachers().Where(a => a.IdUser == idUser).FirstOrDefault();
        }

        public static List<Headmaster> GetHeadmasters()
        {
            return new List<Headmaster>(Connection.BdConnection.Headmaster).ToList();
        }

        public static Headmaster GetHeadmaster(int idUser)
        {
            return GetHeadmasters().Where(a => a.IdUser == idUser).FirstOrDefault();
        }

        public static bool IsCorrectUser(string email, string password)
        {
            var admin = from usrs in GetUsers()
                        where email == usrs.Login && password == usrs.Password && usrs.IdRole == 1
                        select usrs;

            var teacher = from usrs in GetUsers()
                          where email == usrs.Login && password == usrs.Password && usrs.IdRole == 2
                          select usrs;

            if (teacher.Count() == 1)
            {
                CurrentUser.User = teacher.FirstOrDefault();
                CurrentUser.Teacher = GetTeacher(CurrentUser.User.Id);
                return true;
            }
            else if (admin.Count() == 1)
            {
                CurrentUser.User = admin.FirstOrDefault();
                CurrentUser.Headmaster = GetHeadmaster(CurrentUser.User.Id);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
