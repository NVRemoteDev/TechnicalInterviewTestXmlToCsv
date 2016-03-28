using StudentEnrollmentDataParser.DataParser;
using StudentEnrollmentDataParser.Helpers;
using StudentEnrollmentDataParser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace StudentEnrollmentDataParser
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string inputFile = "";
            string outputFile = "";

            if (!CheckArgs(args))
            {
                Console.WriteLine(ProgramHelper.GetInvalidArgsMessage());
                return;
            }

            inputFile = args[0];
            outputFile = args[1];

            // I purposefully overdesigned this solution to show concepts.
            // I would likely approach this problem differently in a real life scenario
            var factory = new SchoolEnrollmentFactory(inputFile, outputFile);
            factory.WriteOutputFile();

            Console.Write(ProgramHelper.GetFinishedMessage());
            Console.Read();
        }

        /// <summary>
        /// Checks to ensure the args meet the minimum requirements to run the program
        /// </summary>
        /// <param name="args">Command line parameter args</param>
        public static bool CheckArgs(string[] args)
        {
            if (args.Length < 2)
            {
                return false;
            }
            return true;
        }
    }
}
