using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        public string Name;
        public string Error = "null";

        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                
                case 'B':
                    AddGrade(80);
                    break;
                
                case 'C':
                    AddGrade(70);
                    break;
                
                case 'D':
                    AddGrade(60);
                    break;
                
                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0){
                grades.Add(grade);
            }
            else{
                Error = "Invalid Value";
                Console.WriteLine(Error);
            }
        }

        public Statistics GetStatistics()
        {
            Statistics result = new Statistics();
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            
            for(var index = 0; index < grades.Count; index++)            
            {
                result.High = Math.Max(result.High, grades[index]);
                result.Low = Math.Min(result.Low, grades[index]);
                result.Average += grades[index];
            }
            result.Average /= grades.Count;

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }
    }
}