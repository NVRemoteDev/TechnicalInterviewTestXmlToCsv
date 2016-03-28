using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentEnrollmentDataParser.Helpers;

namespace StudentEnrollmentDataParserTests.Helpers
{
    [TestClass]
    public class CsvHelperTests
    {
        [TestMethod]
        public void TestCorrectNullHandling()
        {
            Assert.AreEqual(CsvHelper.SetupInputForCsv(null), "");
        }

        [TestMethod]
        public void TestSpecialCharCsvSetup()
        {
            Assert.AreEqual(CsvHelper.SetupInputForCsv("Jones, Jr."), "\"Jones, Jr.\"");
            Assert.AreEqual(CsvHelper.SetupInputForCsv("Robert, Jr.\""), "\"Robert, Jr.\"\"\"");
            Assert.AreEqual(CsvHelper.SetupInputForCsv("\"Robert, Jr.\""), "\"\"\"Robert, Jr.\"\"\"");
        }

        [TestMethod]
        public void TestNoSpaceBetweenCsvFields()
        {
            Assert.AreEqual(CsvHelper.AppendCsv("test1,", "test2"), "test1,test2,");
        }

        [TestMethod]
        public void TestSkipEndingComma()
        {
            Assert.AreEqual(CsvHelper.AppendCsv("test1,", "test2", true), "test1,test2");
        }
    }
}
