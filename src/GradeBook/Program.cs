// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace GradeBook
{  
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is the name of your student?");
            string? bookname = System.Console.ReadLine();
            Book book = new Book(bookname);
            var done = false;
            
            while(!done){
                Console.WriteLine("Enter a grade between 0 and 100, or 'q' to quit:");
                string? input = Console.ReadLine();
                
                if(input == "q"){
                    done = true;
                    continue;
                }
                
                try{
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex){
                    Console.WriteLine(ex.Message);
                    throw;
                }
                catch(FormatException ex){
                    Console.WriteLine(ex.Message);
                    throw;
                }
                
            }
            
            var stats = book.GetStatistics();
            
            Console.WriteLine($"The highest grade in {bookname}'s Grade Book is {stats.High:N1}%");
            Console.WriteLine($"The lowest grade in {bookname}'s Grade Book is {stats.Low:N1}%");
            Console.WriteLine($"{bookname}'s average grade in the class is {stats.Average:N1}%");
            Console.WriteLine($"{bookname}'s average letter grade in class is '{stats.Letter}'");
            
        }
    }
}
