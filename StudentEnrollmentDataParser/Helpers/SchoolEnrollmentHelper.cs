using StudentEnrollmentDataParser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StudentEnrollmentDataParser.Helpers
{
    public static class SchoolEnrollmentHelper
    {
        public const int MIN_TEACHERS = 2;
        public const int MAX_TEACHERS = 2;

        public static string GetCsvHeader()
        {
            return "classroom id, classroom_name, teacher_1_id, teacher_1_last_name, teacher_1_first_name, teacher_2_id, "
                + "teacher_2_last_name, teacher_2_first_name, student_id, student_last_name, student_first_name, student_grade";
        }
    }
}
