using System;
using System.Collections;

namespace StudentEnrollmentDataParser.Models
{
    /// <summary>
    /// Represents a school
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false, ElementName = "school")]
    public partial class School
    {
        [System.Xml.Serialization.XmlElementAttribute("grade")]
        public Grade[] Grades { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("id")]
        public int Id { get; set; }
    }

    /// <summary>
    /// Represents a grade
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Grade
    {
        [System.Xml.Serialization.XmlElementAttribute("classroom")]
        public Classroom[] Classrooms { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("id")]
        public int Id { get; set; }
    }

    /// <summary>
    /// Represents a classroom
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Classroom
    {
        [System.Xml.Serialization.XmlAttributeAttribute("id")]
        public int Id { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("name")]
        public string Name { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("teacher")]
        public ClassroomTeacher[] Teachers { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("student")]
        public ClassroomStudent[] Students { get; set; }
    }

    /// <summary>
    /// Represent's a classroom teacher
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ClassroomTeacher
    {
        [System.Xml.Serialization.XmlAttributeAttribute("id")]
        public ulong Id { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("first_name")]
        public string FirstName { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("last_name")]
        public string LastName { get; set; }
    }

    /// <summary>
    /// Represents a classroom student
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ClassroomStudent
    {
        [System.Xml.Serialization.XmlAttributeAttribute("id")]
        public ulong Id { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("first_name")]
        public string FirstName { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("last_name")]
        public string LastName { get; set; }
    }
}