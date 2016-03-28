using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentDataParser.Helpers
{
    public static class ProgramHelper
    {
        public static string GetFinishedMessage()
        {
            return "Finished! Press any key to continue.";
        }

        public static string GetInvalidArgsMessage()
        {
            return string.Format("{0}{1}{2}"
                , "Please enter an input XML file and an output filename."
                , Environment.NewLine
                , "Usage: StudentEnrollmentDataParser [input.xml] [output.csv]");
        }
    }
}
