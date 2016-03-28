using StudentEnrollmentDataParser.Helpers;
using StudentEnrollmentDataParser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StudentEnrollmentDataParser.DataParser
{
    public class SchoolEnrollmentFactory : ISchoolEnrollmentFactory
    {
        private string _outputFile;
        private string _inputFile;
        private School _model;

        public string Csv { get; private set; }
        public School Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                SetCsvFromModel();
            }
        }

        /// <summary>
        /// Creates an instance of SchoolEnrollmentFactory
        /// </summary>
        public SchoolEnrollmentFactory(string inputFile, string outputFile)
        {
            this._inputFile = inputFile;
            this._outputFile = outputFile;

            SetModelFromInputXml();
            SetCsvFromModel();
        }

        /// <summary>
        /// Set the school model from the input XML
        /// </summary>
        public virtual void SetModelFromInputXml()
        {
            var doc = new XmlDocument();
            doc.Load(_inputFile);

            Model = doc.OuterXml.ParseXml<School>();
        }

        /// <summary>
        /// Set the CSV from the school model
        /// </summary>
        public virtual void SetCsvFromModel()
        {
            Csv = SchoolEnrollmentHelper.GetCsvHeader() + Environment.NewLine;

            foreach (Grade grade in Model.Grades)
            {
                foreach (Classroom classroom in grade.Classrooms)
                {
                    AddClassroom(classroom, grade.Id.ToString());
                }
            }
        }

        /// <summary>
        /// Adds classroom data to the CSV
        /// </summary>
        private void AddClassroom(Classroom classroom, string studentGradeId)
        {
            var tempStudents = classroom.Students;

            if (tempStudents == null)
            {
                tempStudents = new ClassroomStudent[1] { new ClassroomStudent() };
            }

            foreach (ClassroomStudent student in tempStudents)
            {
                var tempGradeId = studentGradeId;
                var tempStudentId = student.Id.ToString();

                // If we have a classroom without a student 
                // we want a blank id instead of a 0 in the CSV
                if (tempStudentId == "0"
                    && string.IsNullOrEmpty(student.FirstName)
                    && string.IsNullOrEmpty(student.LastName))
                {
                    tempStudentId = "";
                    tempGradeId = "";
                }

                Csv = CsvHelper.AppendCsv(Csv, classroom.Id.ToString());
                Csv = CsvHelper.AppendCsv(Csv, classroom.Name);

                AddTeacherDataToCsv(classroom.Teachers);

                Csv = CsvHelper.AppendCsv(Csv, tempStudentId);
                Csv = CsvHelper.AppendCsv(Csv, student.LastName);
                Csv = CsvHelper.AppendCsv(Csv, student.FirstName);
                Csv = CsvHelper.AppendCsv(Csv, tempGradeId, skipEndingComma: true);

                Csv += Environment.NewLine;
            }
        }

        /// <summary>
        /// Adds teacher data to the csv
        /// </summary>
        /// <param name="teachers">Classroom teachers</param>
        private void AddTeacherDataToCsv(ClassroomTeacher[] teachers)
        {
            var tempTeachers = CheckPrepareTeachersData(teachers);

            foreach (ClassroomTeacher teacher in tempTeachers)
            {
                // If we have no teacher we want a blank id instead of a 0 in the CSV
                var tempTeacherId = teacher.Id.ToString();
                if (tempTeacherId == "0"
                    && string.IsNullOrEmpty(teacher.FirstName)
                    && string.IsNullOrEmpty(teacher.LastName))
                {
                    tempTeacherId = "";
                }

                Csv = CsvHelper.AppendCsv(Csv, tempTeacherId);
                Csv = CsvHelper.AppendCsv(Csv, teacher.LastName);
                Csv = CsvHelper.AppendCsv(Csv, teacher.FirstName);
            }
        }

        /// <summary>
        /// Creates an output file
        /// </summary>
        public virtual void WriteOutputFile()
        {
            File.WriteAllText(_outputFile, Csv);
        }

        /// <summary>
        /// Prepares teacher data for CSV addition
        /// </summary>
        private static ClassroomTeacher[] CheckPrepareTeachersData(ClassroomTeacher[] teachers)
        {
            if (teachers.Length > SchoolEnrollmentHelper.MAX_TEACHERS)
            {
                throw new Exception(
                    string.Format("Expected a maximum of {0} teachers.", SchoolEnrollmentHelper.MAX_TEACHERS.ToString()));
            }

            var tempTeachers = teachers;

            if (tempTeachers.Length < SchoolEnrollmentHelper.MIN_TEACHERS)
            {
                var teacherList = new List<ClassroomTeacher>();
                foreach (var teacher in tempTeachers)
                {
                    teacherList.Add(teacher);
                }
                while (teacherList.Count < SchoolEnrollmentHelper.MIN_TEACHERS)
                {
                    teacherList.Add(new ClassroomTeacher());
                }

                tempTeachers = teacherList.ToArray();
            }

            return tempTeachers;
        }

        
    }
}
