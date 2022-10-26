using System;
using GradeBook;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void ErrorIfGradeAboveHundred(){
            var book = new Book("High Error Book");
            book.AddGrade(105);
            string expected = "Invalid Value";

            Assert.Equal(expected, book.Error);
        }

        [Fact]
        public void ErrorIfGradeBelowZero(){
            var book = new Book("Low Error Book");
            book.AddGrade(-5);
            string expected = "Invalid Value";

            Assert.Equal(expected, book.Error);
        }
        
        [Fact]
        public void StringsBehaveLikeValueTypes(){
            string name = "Adam";
            var upper = MakeUpperase(name);

            Assert.Equal("Adam", name);
            Assert.Equal("ADAM", upper);
        }

        private string MakeUpperase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            // arrange
            var book2 = GetBook("Book 2");
            GetBookSetNameRef(ref book2, "New Name");

            // act
            

            // assert
            Assert.Equal("New Name", book2.Name);
            
        }

        private void GetBookSetNameRef(ref Book book, string name)
        {
            book = new Book(name);

        }
        
        
        [Fact]
        public void CSharpIsPassByValue()
        {
            // arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            // act
            

            // assert
            Assert.Equal("Book 1", book1.Name);
            
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);

        }
        
        [Fact]
        public void CanSetNameFromRef()
        {
            // arrange
            var book1 = GetBook("Book 1");
            SetName(book1, "Book 1");

            // act
            

            // assert
            Assert.Equal("Book 1", book1.Name);
            
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;

        }
        
        [Fact]
        public void GetBookReturnsDiffObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // act
            

            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanRefSameObject()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            // act
            

            // assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}

