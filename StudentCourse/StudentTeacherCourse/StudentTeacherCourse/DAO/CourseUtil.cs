using StudentTeacherCourse.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentTeacherCourse.DAO
{
    public static class CourseUtil
    {

        public static bool checkIfStudentIsEnrolled(List<int> EnrolledCourseIds, int CourseId)
        {
            //string currentUserId = user.GetUserId();

            bool isEnrolled = false;
            for (int index = 0; index < EnrolledCourseIds.Count; index++)
            {
                if (EnrolledCourseIds[index] == CourseId)
                {
                    isEnrolled = true;
                }
            }

            


            return false;
        }
    }
}