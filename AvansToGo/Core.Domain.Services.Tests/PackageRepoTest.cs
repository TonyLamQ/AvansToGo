using System;
using System.ComponentModel.DataAnnotations;
using Core.Domain;
using Core.Domain.Services.IRepository;
using Xunit;
using Moq;
using Portal.Controllers;
using System.Security.Claims;

namespace Core.Domain.Tests
{
    public class PackageRepoTest
    {
        [Fact]
        public void AddReservedPackageById()
        {
            //Arrange
            var Student = new Student
            {
                StudentId = 1,
                UserName = "Test",
                BirthDate = DateTime.Now,
                Email = "Test@Gmail.com",
                City = EnumCity.Breda,
                PhoneNumber = "12498135",
                Packages = new List<Package> { }
            };

            var Package = new Package
            {
                Id = 1,
                Name = "test",
                City = EnumCity.Breda,
                ContainsAlcohol = true,
                Price = 19,
                Canteen = new Canteen(),
                CanteenLocation = "la",
                Products = new List<Product>(),
                PickUpTimeStart = DateTime.Now,
                PickUpTimeEnd = DateTime.Now,
                Type = EnumMealType.Beverage,
                ReservedBy = null,
                StudentId = null,
            };
            var RepoMock = new Mock<IPackageRepo>();
            var StudentMock = new Mock<IStudentRepo>();

            RepoMock.Setup(p => p.AddReservedById(1, 1)).Returns(true);
            StudentMock.Setup(p => p.GetStudentByEmail("Student@gmail.com")).Returns(Student);

            var controller = new HomeController(RepoMock.Object, StudentMock.Object);
            //Act

            var Bool = controller.AddReservedById(1);
            //Assert

            RepoMock.Verify(p => p.AddReservedById(1, 1));
            Assert.True(Bool);
        }

        [Fact]
        public void Cannot_Reserve_Package_Already_Reserved()
        {
            //Arrange
            var Student = new Student
            {
                StudentId = 2,
                UserName = "Test",
                BirthDate = DateTime.Now,
                Email = "Test@Gmail.com",
                City = EnumCity.Breda,
                PhoneNumber = "12498135",
                Packages = new List<Package> { }
            };

            var Package = new Package
            {
                Id = 1,
                Name = "test",
                City = EnumCity.Breda,
                ContainsAlcohol = true,
                Price = 19,
                Canteen = new Canteen(),
                CanteenLocation = "la",
                Products = new List<Product>(),
                PickUpTimeStart = DateTime.Now,
                PickUpTimeEnd = DateTime.Now,
                Type = EnumMealType.Beverage,
                ReservedBy = null,
                StudentId = 1,
            };
            var RepoMock = new Mock<IPackageRepo>();
            var StudentMock = new Mock<IStudentRepo>();

            RepoMock.Setup(p => p.AddReservedById(1, 1)).Returns(true);
            StudentMock.Setup(p => p.GetStudentByEmail("Student@gmail.com")).Returns(Student);

            var controller = new HomeController(RepoMock.Object, StudentMock.Object);
            //Act

            var Bool = controller.AddReservedById(1);
            //Assert

            RepoMock.Verify(p => p.AddReservedById(2, 1));
            Assert.False(Bool);
        }

    }
}