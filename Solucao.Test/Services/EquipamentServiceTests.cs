using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Solucao.Application.AutoMapper;
using Solucao.Application.Contracts;
using Solucao.Application.Data;
using Solucao.Application.Data.Entities;
using Solucao.Application.Data.Repositories;
using Solucao.Application.Service.Implementations;
using Xunit;

namespace Solucao.Tests
{
    public class EquipamentServiceTests
    {
        private Mock<SolucaoContext> contextMock;
        private Mock<EquipamentRepository> repositoryMock;
        private readonly IMapper _mapper;

        public EquipamentServiceTests()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToEntityMappingProfile());
            }).CreateMapper();

            contextMock = new Mock<SolucaoContext>();
            repositoryMock = new Mock<EquipamentRepository>(contextMock.Object);
        }
        [Fact]
        public async Task Add_ValidEquipament_ReturnsSuccess()
        {
            // Arrange
            var equipamentService = new EquipamentService(
                repositoryMock.Object,
                _mapper);

            var equipamentViewModel = new EquipamentViewModel
            {
                Id = Guid.NewGuid()
            };

            repositoryMock.Setup(repo => repo.Add(It.IsAny<Equipament>()))
                .ReturnsAsync(ValidationResult.Success);

            // Act
            var result = await equipamentService.Add(equipamentViewModel);

            // Assert
            Assert.Equal(ValidationResult.Success, result);
        }

        [Fact]
        public async Task GetAll_ValidParameters_ReturnsEquipaments()
        {
            // Arrange

            var equipamentService = new EquipamentService(
                repositoryMock.Object,
                _mapper);

            var ativo = true; 

            repositoryMock.Setup(repo => repo.GetAll(ativo))
                .ReturnsAsync(new List<Equipament>());

            // Act
            var result = await equipamentService.GetAll(ativo);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Update_ValidEquipament_ReturnsSuccess()
        {
            // Arrange
            var equipamentService = new EquipamentService(
                repositoryMock.Object,
                _mapper);

            var equipamentViewModel = new EquipamentViewModel
            {
                Id = Guid.NewGuid(),
                Name = "TEste"
            };

            repositoryMock.Setup(repo => repo.Update(It.IsAny<Equipament>()))
                .ReturnsAsync(ValidationResult.Success);

            // Act
            var result = await equipamentService.Update(equipamentViewModel);

            // Assert
            Assert.Equal(ValidationResult.Success, result);
        }
    }
}
