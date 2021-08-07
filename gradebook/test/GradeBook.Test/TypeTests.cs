using System;
using Xunit;

namespace GradeBook.Test
{
    public delegate string WriteLogDelegate(string LogMessage);
    public class TypeTests
    {
        private int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello");
            Assert.Equal(3, count);
        }
        string ReturnMessage(string message)
        {
            ++count;
            return message;
        }
        string IncrementCount(string message)
        {
            ++count;
            return message;
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(out x);
            Assert.Equal(42, x);
        }
        private int GetInt()
        {
            return 2;
        }
        private void SetInt(out int x)
        {
            x = 42;
        }

        [Fact]
        public void StringsBehaveLikeValueType()
        {
            string name = "Ayush";
            var upper = MakeUpperCase(name);

            Assert.Equal("Ayush", name);
            Assert.Equal("AYUSH", upper);
        }

        private string MakeUpperCase(string name)
        {
            return name.ToUpper();
        }

        [Fact]
        public void GetBooksReturnsDifferentObjects()
        {
            // 1 .arrage to put test data
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book2, book1);
        }

         [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }
        private void SetName(IBook book, string newName)
        {
            book.Name = newName;
        } 

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }
        private void GetBookSetName(IBook book, string newName)
        {
            book = new InMemoryBook(newName);
        } 

        [Fact]
        public void CSharpCanPassRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(out book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }
        private void GetBookSetName(out IBook book, string newName)
        {
            book = new InMemoryBook(newName);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            // 1 .arrage to put test data
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        private IBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
