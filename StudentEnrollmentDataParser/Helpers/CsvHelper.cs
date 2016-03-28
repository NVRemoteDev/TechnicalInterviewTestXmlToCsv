using StudentEnrollmentDataParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentDataParser.Helpers
{
    public static class CsvHelper
    {
        /// <summary>
        /// Add csv field to the end of a csv string
        /// 
        /// Use skipEndComma = true for the last field on a CSV line
        /// </summary>
        public static string AppendCsv(string csv, string dataToAdd, bool skipEndingComma = false)
        {
            return string.Format("{0}{1}", csv + SetupInputForCsv(dataToAdd), skipEndingComma ? "" : ",");
        }

        /// <summary>
        /// Setup data for a CSV file
        /// </summary>
        public static string SetupInputForCsv(string input)
        {
            if (input == null)
            {
                return "";
            }

            string tempInput = input;
            if (tempInput.Contains("\"") || tempInput.Contains(",") || tempInput.Contains(Environment.NewLine))
            {
                tempInput = "\"" + tempInput.Replace("\"", "\"\"") + "\"";
            }
            
            return tempInput;
        }
    }
}
