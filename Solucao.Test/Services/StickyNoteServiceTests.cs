using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Moq;
using Solucao.Application.Contracts;
using Solucao.Application.Data.Entities;
using Solucao.Application.Data.Interfaces;
using Solucao.Application.Service.Implementations;

namespace Solucao.Tests
{
    public class StickyNoteServiceTests
    {
        [Fact]
        public async Task Add_ValidStickyNote_ReturnsSuccess()
        {
            // Arrange
            var stickyNoteRepositoryMock = new Mock<IStickyNoteRepository>();
            var mapperMock = new Mock<IMapper>();
            var stickyNoteService = new StickyNoteService(stickyNoteRepositoryMock.Object, mapperMock.Object);

            var stickyNoteViewModel = new StickyNoteViewModel
            {
                Date = DateTime.Now,
                Id = Guid.NewGuid()
            };

            stickyNoteRepositoryMock.Setup(repo => repo.Add(It.IsAny<StickyNote>()))
                .ReturnsAsync(ValidationResult.Success);

            // Act
            var result = await stickyNoteService.Add(stickyNoteViewModel);

            // Assert
            Assert.Equal(ValidationResult.Success, result);
        }

        [Fact]
        public async Task GetAll_ValidDate_ReturnsStickyNotes()
        {
            // Arrange
            var stickyNoteRepositoryMock = new Mock<IStickyNoteRepository>();
            var mapperMock = new Mock<IMapper>();
            var stickyNoteService = new StickyNoteService(stickyNoteRepositoryMock.Object, mapperMock.Object);

            var date = DateTime.Now; // Provide a valid date for testing

            stickyNoteRepositoryMock.Setup(repo => repo.GetAll(date))
                .ReturnsAsync(new List<StickyNote>());

            // Act
            var result = await stickyNoteService.GetAll(date);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Update_ValidStickyNote_ReturnsSuccess()
        {
            // Arrange
            var stickyNoteRepositoryMock = new Mock<IStickyNoteRepository>();
            var mapperMock = new Mock<IMapper>();
            var stickyNoteService = new StickyNoteService(stickyNoteRepositoryMock.Object, mapperMock.Object);

            var stickyNoteViewModel = new StickyNoteViewModel
            {
                Date = DateTime.Now,
                Id = Guid.NewGuid()
            };

            stickyNoteRepositoryMock.Setup(repo => repo.Update(It.IsAny<StickyNote>()))
                .ReturnsAsync(ValidationResult.Success);

            // Act
            var result = await stickyNoteService.Update(stickyNoteViewModel);

            // Assert
            Assert.Equal(ValidationResult.Success, result);
        }

        [Fact]
        public async Task UpdateResolved_ValidStickyNoteId_ReturnsSuccess()
        {
            // Arrange
            var stickyNoteRepositoryMock = new Mock<IStickyNoteRepository>();
            var mapperMock = new Mock<IMapper>();
            var stickyNoteService = new StickyNoteService(stickyNoteRepositoryMock.Object, mapperMock.Object);

            var stickyNoteId = Guid.NewGuid(); // Provide a valid StickyNoteId for testing

            stickyNoteRepositoryMock.Setup(repo => repo.GetById(stickyNoteId))
                .ReturnsAsync(new StickyNote { /* Provide valid data for testing */ });

            // Act
            var result = await stickyNoteService.UpdateResolved(stickyNoteId);

            // Assert
            Assert.Equal(ValidationResult.Success, result);
        }

        [Fact]
        public async Task UpdateResolved_ValidStickyNoteId_ReturnsError()
        {
            // Arrange
            var stickyNoteRepositoryMock = new Mock<IStickyNoteRepository>();
            var mapperMock = new Mock<IMapper>();
            var errorMessage = new ValidationResult("Anotação não encontrada");
            var stickyNoteService = new StickyNoteService(stickyNoteRepositoryMock.Object, mapperMock.Object);

            var stickyNoteId = Guid.NewGuid(); // Provide a valid StickyNoteId for testing

            stickyNoteRepositoryMock.Setup(repo => repo.GetById(Guid.NewGuid()))
                .ReturnsAsync(new StickyNote { /* Provide valid data for testing */ });

            // Act
            var result = await stickyNoteService.UpdateResolved(stickyNoteId);

            // Assert
            Assert.Equal(errorMessage.ToString(), result.ToString());
        }

        [Fact]
        public async Task Remove_ValidStickyNoteId_ReturnsSuccess()
        {
            // Arrange
            var stickyNoteRepositoryMock = new Mock<IStickyNoteRepository>();
            var mapperMock = new Mock<IMapper>();
            var stickyNoteService = new StickyNoteService(stickyNoteRepositoryMock.Object, mapperMock.Object);

            var stickyNoteId = Guid.NewGuid(); // Provide a valid StickyNoteId for testing

            stickyNoteRepositoryMock.Setup(repo => repo.GetById(stickyNoteId))
                .ReturnsAsync(new StickyNote {
                    Date = DateTime.Now,
                    Id = Guid.NewGuid()
                });

            // Act
            var result = await stickyNoteService.Remove(stickyNoteId);

            // Assert
            Assert.Equal(ValidationResult.Success, result);
        }


        [Fact]
        public async Task Remove_ValidStickyNoteId_ReturnsError()
        {
            // Arrange
            var stickyNoteRepositoryMock = new Mock<IStickyNoteRepository>();
            var mapperMock = new Mock<IMapper>();
            var errorMessage = new ValidationResult("Anotação não encontrada");
            var stickyNoteService = new StickyNoteService(stickyNoteRepositoryMock.Object, mapperMock.Object);

            var stickyNoteId = Guid.NewGuid(); // Provide a valid StickyNoteId for testing

            stickyNoteRepositoryMock.Setup(repo => repo.GetById(Guid.NewGuid()))
                .ReturnsAsync(new StickyNote
                {
                    Date = DateTime.Now,
                    Id = Guid.NewGuid()
                });

            // Act
            var result = await stickyNoteService.Remove(stickyNoteId);

            // Assert
            Assert.Equal(errorMessage.ToString(), result.ToString());
        }
    }
}
