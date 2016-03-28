using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentEnrollmentDataParser.DataParser;
using System.IO;
using System.Xml;

namespace StudentEnrollmentDataParserTests
{
    [TestClass]
    public class FactoryTests
    {
        string _inputFile;
        string _outputFile;

        string DataDirectory
        {
            get { return "../../data/"; }
        }
        string InputFile
        {
            get { return DataDirectory + _inputFile; }
            set { _inputFile = value; }
        }
        string OutputFile
        {
            get { return DataDirectory + _outputFile; }
            set { _outputFile = value; }
        }

        [TestMethod]
        public void TestSampleDataParse()
        {
            try
            {
                InputFile = "sample_data.xml";
                OutputFile = "sample_data.csv";

                var factory = new SchoolEnrollmentFactory(InputFile, OutputFile);

                try
                {
                    factory.WriteOutputFile();
                }
                catch (IOException)
                {
                    Assert.Fail("Unable to write File");
                }

                Assert.IsNotNull(factory.Csv);
                Assert.IsNotNull(factory.Model);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Sample data parse failed.{0}Reason: {1}",
                    Environment.NewLine,
                    ex.Message));
            }
        }

        [TestMethod]
        public void TestInvalidXmlFormatFail()
        {
            InputFile = "sample_data_missing_grade_tag.xml";
            OutputFile = "";

            try
            {
                var factory = new SchoolEnrollmentFactory(InputFile, OutputFile);
                Assert.Fail("Expected XML Exception exception");
            }
            catch (XmlException)
            { }
        }

        [TestMethod]
        public void TestMissingNonRequiredData()
        {
            InputFile = "sample_data_missing_names.xml";
            OutputFile = "";

            try
            {
                var factory = new SchoolEnrollmentFactory(InputFile, OutputFile);
            }
            catch (InvalidOperationException)
            {
                Assert.Fail("Expected data writing exception");
            }
        }

        [TestMethod]
        public void TestMissingRequiredData()
        {
            InputFile = "sample_data_missing_student_id.xml";
            OutputFile = "";

            try
            {
                var factory = new SchoolEnrollmentFactory(InputFile, OutputFile);
                Assert.Fail("Expected data writing exception");
            }
            catch (InvalidOperationException)
            { }
        }
    }
}
