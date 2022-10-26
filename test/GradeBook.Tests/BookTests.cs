using System;
using GradeBook;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStats()
        {
            // arrange
            var book = new Book("");
                     
            book.AddGrade(89.1);
            book.AddGrade(99.9);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            book.AddGrade(68.1);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.02, result.Average, 2);
            Assert.Equal(99.9, result.High, 1);
            Assert.Equal(68.1, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
    }
}