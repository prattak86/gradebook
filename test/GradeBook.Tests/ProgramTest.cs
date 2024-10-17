// src/GradeBook/ProgramTest.cs
using System;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace GradeBook.Tests
{
    public class ProgramTest
    {
        [Fact]
        public void TestValidBookName()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("John's Grade Book\nq\n"))
                {
                    Console.SetIn(sr);
                    Program.Main(new string[] { });
                }
                var result = sw.ToString().Trim();
                Assert.Contains("What is the name of your student?", result);
                Assert.Contains("Enter a grade between 0 and 100, or 'q' to quit:", result);
            }
        }

        [Fact]
        public void TestInvalidBookName()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("\n"))
                {
                    Console.SetIn(sr);
                    Program.Main(new string[] { });
                }
                var result = sw.ToString().Trim();
                Assert.Contains("What is the name of your student?", result);
                Assert.Contains("Book name cannot be null or empty.", result);
            }
        }

        [Fact]
        public void TestValidGradeInput()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("John's Grade Book\n85\n90\nq\n"))
                {
                    Console.SetIn(sr);
                    Program.Main(new string[] { });
                }
                var result = sw.ToString().Trim();
                Assert.Contains("Enter a grade between 0 and 100, or 'q' to quit:", result);
                Assert.Contains("The highest grade in John's Grade Book is 90.0%", result);
                Assert.Contains("The lowest grade in John's Grade Book is 85.0%", result);
                Assert.Contains("John's average grade in the class is 87.5%", result);
            }
        }

        [Fact]
        public void TestInvalidGradeInput()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("John's Grade Book\ninvalid\nq\n"))
                {
                    Console.SetIn(sr);
                    Program.Main(new string[] { });
                }
                var result = sw.ToString().Trim();
                Assert.Contains("Enter a grade between 0 and 100, or 'q' to quit:", result);
                Assert.Contains("Input string was not in a correct format.", result);
            }
        }

        [Fact]
        public void TestStatisticsCalculation()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("John's Grade Book\n85\n90\n95\nq\n"))
                {
                    Console.SetIn(sr);
                    Program.Main(new string[] { });
                }
                var result = sw.ToString().Trim();
                Assert.Contains("The highest grade in John's Grade Book is 95.0%", result);
                Assert.Contains("The lowest grade in John's Grade Book is 85.0%", result);
                Assert.Contains("John's average grade in the class is 90.0%", result);
                Assert.Contains("John's average letter grade in class is 'A'", result);
            }
        }
    }
}