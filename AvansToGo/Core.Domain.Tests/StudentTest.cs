using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Core.Domain.Tests
{
    public class StudentTest
    {
        [Fact]
        public void GetStudentId_Returns_StudentID()
        {
            //Arrange
            var student = new Student
            {
                StudentId = 1,
                UserName= "Test",
                BirthDate= DateTime.Now,
                Email = "test@Gmail.com",
                City = EnumCity.Breda,
                PhoneNumber = "1124841",             
            };
            //Act
            var StudentId = student.StudentId;
            //Assert
            Assert.Equal(1, StudentId);
           
        }
    }
}