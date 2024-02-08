using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Moq;
using Solucao.Application.AutoMapper;
using Solucao.Application.Contracts;
using Solucao.Application.Data;
using Solucao.Application.Data.Entities;
using Solucao.Application.Data.Repositories;
using Solucao.Application.Service.Interfaces;

namespace Solucao.Tests
{
    public class SpecificationServiceTests
    {
        private Mock<SolucaoContext> contextMock;
        private Mock<SpecificationRepository> specificationRepositoryMock;
        private readonly IMapper _mapper;


        public SpecificationServiceTests()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToEntityMappingProfile());
            }).CreateMapper();

            contextMock = new Mock<SolucaoContext>();
            specificationRepositoryMock = new Mock<SpecificationRepository>(contextMock.Object);
        }

        [Fact]
        public async Task Add_NonUniqueSpecification_ReturnsValidationResultWithSuccess()
        {
            // Arrange
            specificationRepositoryMock.Setup(repo => repo.SingleIsValid(It.IsAny<Guid>())).ReturnsAsync(true);

            var specificationService = new SpecificationService(specificationRepositoryMock.Object, _mapper);
            var specification = new SpecificationViewModel { Single = true };

            // Act
            var result = await specificationService.Add(specification);

            // Assert
            Assert.Equal(ValidationResult.Success, result);
        }

        [Fact]
        public async Task Add_UniqueSpecification_ReturnsValidationResultWithError()
        {
            // Arrange
            specificationRepositoryMock.Setup(repo => repo.SingleIsValid(null)).ReturnsAsync(true);

            var specificationService = new SpecificationService(specificationRepositoryMock.Object, _mapper);
            var specification = new SpecificationViewModel { Single = true };

            // Act
            var result = await specificationService.Add(specification);

            // Assert
            Assert.Equal("Já existe uma especificação única", result.ErrorMessage);
        }

        [Fact]
        public async Task Update_NonUniqueSpecification_ReturnsValidationResultWithSuccess()
        {
            // Arrange

            specificationRepositoryMock.Setup(repo => repo.SingleIsValid(It.IsAny<Guid>())).ReturnsAsync(false);

            var specificationService = new SpecificationService(specificationRepositoryMock.Object, _mapper);
            var specification = new SpecificationViewModel { Id = Guid.NewGuid() };

            // Act
            var result = await specificationService.Update(specification);

            // Assert
            Assert.Equal(ValidationResult.Success, result);
        }

        [Fact]
        public async Task Update_UniqueSpecification_ReturnsValidationResultWithError()
        {
            // Arrange
            specificationRepositoryMock.Setup(repo => repo.SingleIsValid(It.IsAny<Guid>())).ReturnsAsync(true);

            var specificationService = new SpecificationService(specificationRepositoryMock.Object, _mapper);
            var specification = new SpecificationViewModel { Id = Guid.NewGuid() };

            // Act
            var result = await specificationService.Update(specification);

            // Assert
            Assert.Equal("Já existe uma especificação única", result.ErrorMessage);
        }

        [Fact]
        public async Task GetSpecificationByEquipament_ReturnsListOfSpecifications()
        {
            // Arrange
            var equipamentIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };
            var specifications = new List<Specification>
            {
                new Specification { Id = Guid.NewGuid() },
                new Specification { Id = Guid.NewGuid() }
            };

            specificationRepositoryMock.Setup(repo => repo.GetSpecificationByEquipament(It.IsAny<List<Guid>>())).ReturnsAsync(specifications);

            var specificationService = new SpecificationService(specificationRepositoryMock.Object, _mapper);

            // Act
            var result = await specificationService.GetSpecificationByEquipament(equipamentIds);

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetSpecification_ReturnsListOfSpecifications()
        {
            // Arrange
            var equipamentIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };
            var specifications = new List<Specification>
            {
                new Specification { Id = Guid.NewGuid() },
                new Specification { Id = Guid.NewGuid() }
            };

            specificationRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(specifications);

            var specificationService = new SpecificationService(specificationRepositoryMock.Object, _mapper);

            // Act
            var result = await specificationService.GetAll();

            // Assert
            Assert.Equal(2, result.Count());
        }
    }
}
