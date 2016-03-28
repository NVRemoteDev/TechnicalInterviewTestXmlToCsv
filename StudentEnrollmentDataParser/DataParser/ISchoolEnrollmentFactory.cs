using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentDataParser.DataParser
{
    public interface ISchoolEnrollmentFactory
    {
        /// <summary>
        /// Write the output CSV File
        /// </summary>
        void WriteOutputFile();

        /// <summary>
        /// Set the school model from the input XML
        /// </summary>
        void SetModelFromInputXml();

        /// <summary>
        /// Set the CSV from the school model
        /// </summary>
        void SetCsvFromModel();
    }
}
