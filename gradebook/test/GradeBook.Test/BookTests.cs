using System;
using Xunit;

namespace GradeBook.Test
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStats()
        {
            // 1 .arrage to put test data
            var book = new InMemoryBook("");
            book.AddGrades(89.1);
            book.AddGrades(90.5);
            book.AddGrades(77.3);

            // 2. act
            var result = book.GetStatistics();
            
            // 3. assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.LetterGrade);

        }
    }
}
