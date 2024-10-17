// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

            // Original console application logic
            Console.WriteLine("What is the name of your student?");
            string? bookname = System.Console.ReadLine();
            if (string.IsNullOrEmpty(bookname))
            {
                Console.WriteLine("Book name cannot be null or empty.");
                return; // Exit the program if the book name is invalid
            }
            Book book = new Book(bookname);
            var done = false;

            while (!done)
            {
                Console.WriteLine("Enter a grade between 0 and 100, or 'q' to quit:");
                string? input = Console.ReadLine();

                if (input == "q")
                {
                    done = true;
                    continue;
                }

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be null or empty.");
                    continue;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                catch (FormatException ex)
                {
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