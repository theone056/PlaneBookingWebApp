using Microsoft.EntityFrameworkCore;
using Moq;
using PlaneBookingWebApp.Core.Domain;
using PlaneBookingWebApp.Infrastructure.Context;
using PlaneBookingWebApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PlaneBookingWebApp.Infrastructure.Tests.Repositories
{
    public class AirportRepositoryTests
    {
        private Mock<DbSet<Airport>> mockSet;
        private Mock<PlaneBookingDbContext> mockContext;
        public AirportRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<PlaneBookingDbContext>()
                          .UseInMemoryDatabase(databaseName: "TestDb")
                          .Options;
            mockSet = new Mock<DbSet<Airport>>();
            mockContext = new Mock<PlaneBookingDbContext>(options);
        }

        [Fact]
        public async void Method_Add_VerifiedAddedAndSaved()
        {
            //Arrange
            mockContext.Setup(x=>x.Set<Airport>()).Returns(mockSet.Object);
            mockContext.Setup(x => x.Airports).Returns(mockSet.Object);

            var _unitOfWork = new UnitOfWork(mockContext.Object);
            //Act
            await _unitOfWork.Airports.Add(new Airport() { Id = 1, Address = "Test Address", Name = "Test Name" });
            await _unitOfWork.Save();

            //Verify
            mockSet.Verify(x=> x.AddAsync(It.IsAny<Airport>(), It.IsAny<CancellationToken>()),Times.Once);
            mockContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()),Times.Once);
        }

        [Fact]
        public async void Method_Add_Throws_Exception()
        {
            //Arrange
            mockContext.Setup(x => x.Set<Airport>()).Returns(mockSet.Object);
            mockContext.Setup(x => x.Airports).Returns(mockSet.Object);

            //Act and Assert
            var _unitOfWork = new UnitOfWork(mockContext.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(()=> _unitOfWork.Airports.Add(It.IsAny<Airport>()));
            mockSet.Verify(x => x.AddAsync(It.IsAny<Airport>(), It.IsAny<CancellationToken>()), Times.Never);
            mockContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async void Method_Delete_Returns_False()
        {
            //Arrange
            mockContext.Setup(x => x.Set<Airport>()).Returns(mockSet.Object);
            mockContext.Setup(x => x.Airports).Returns(mockSet.Object);

            var _unitOfWork = new UnitOfWork(mockContext.Object);

            //Act
            var result = await _unitOfWork.Airports.Delete(1);

            //Verify
            Assert.False(result);
            mockSet.Verify(x => x.Remove(It.IsAny<Airport>()), Times.Never);
            mockContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async void Method_Delete_Returns_True()
        {
            //Arrange
            var airports = new List<Airport>()
            {
                new Airport(){ Id = 1, Name = "Test Name 1", Address = "Test Address 1"},
                new Airport(){ Id = 2, Name = "Test Name 2", Address = "Test Address 2"}
            };
            mockContext.Setup(x => x.Set<Airport>()).Returns(mockSet.Object);
            mockContext.Setup(x => x.Airports).Returns(mockSet.Object);
            mockContext.Setup(x => x.Airports.Remove(It.IsAny<Airport>())).Callback<Airport>((entity) => airports.Remove(entity));
            mockContext.Setup(x => x.Airports.FindAsync(1)).ReturnsAsync(airports.Single(x=>x.Id == 1));
            var _unitOfWork = new UnitOfWork(mockContext.Object);
            //Act
            var result = await _unitOfWork.Airports.Delete(1);
            await _unitOfWork.Save();

            //Verify
            Assert.True(result);
            mockSet.Verify(x => x.Remove(It.IsAny<Airport>()), Times.Once);
            mockContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async void Method_GetById_Returns_Airport()
        {
            //Arrange
            var airports = new List<Airport>()
            {
                new Airport(){ Id = 1, Name = "Test Name 1", Address = "Test Address 1"},
                new Airport(){ Id = 2, Name = "Test Name 2", Address = "Test Address 2"}
            };
            mockContext.Setup(x => x.Set<Airport>()).Returns(mockSet.Object);
            mockContext.Setup(x => x.Airports).Returns(mockSet.Object);
            mockContext.Setup(x => x.Airports.FindAsync(1)).ReturnsAsync(airports.Single(x => x.Id == 1));
            var _unitOfWork = new UnitOfWork(mockContext.Object);
            //Act
            var result = await _unitOfWork.Airports.GetById(1);

            //Verify
            Assert.IsType<Airport>(result);
            Assert.NotNull(result);
            mockSet.Verify(x => x.FindAsync(1), Times.Once);
            mockContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async void Method_GetById_Returns_Null()
        {
            //Arrange
            var airports = new List<Airport>()
            {
                new Airport(){ Id = 1, Name = "Test Name 1", Address = "Test Address 1"},
                new Airport(){ Id = 2, Name = "Test Name 2", Address = "Test Address 2"}
            };
            mockContext.Setup(x => x.Set<Airport>()).Returns(mockSet.Object);
            mockContext.Setup(x => x.Airports).Returns(mockSet.Object);
            mockContext.Setup(x => x.Airports.FindAsync(0)).ReturnsAsync(new Airport());
            var _unitOfWork = new UnitOfWork(mockContext.Object);
            //Act
            var result = await _unitOfWork.Airports.GetById(0);

            //Verify
            Assert.IsType<Airport>(result);
            Assert.Null(result.Address);
            mockSet.Verify(x => x.FindAsync(0), Times.Once);
            mockContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
