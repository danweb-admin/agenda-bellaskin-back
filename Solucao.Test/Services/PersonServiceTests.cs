using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Solucao.Application.Contracts;
using Solucao.Application.Data.Entities;
using Solucao.Application.Data.Interfaces;
using Solucao.Application.Service.Implementations;
using Xunit;

namespace Solucao.Tests
{
    public class PersonServiceTests
    {
        [Fact]
        public async Task Add_ValidPerson_ReturnsSuccess()
        {   
            // Arrange
            var personRepositoryMock = new Mock<IPersonRepository>();
            var mapperMock = new Mock<IMapper>();
            var personService = new PersonService(personRepositoryMock.Object, mapperMock.Object);

            var personViewModel = new PersonViewModel
            {
                Id = Guid.NewGuid(),
                Name = "Teste"
            };

            personRepositoryMock.Setup(repo => repo.Add(It.IsAny<Person>()))
                .ReturnsAsync(ValidationResult.Success);

            // Act
            var result = await personService.Add(personViewModel);

            // Assert
            Assert.Equal(ValidationResult.Success, result);
        }

        [Fact]
        public async Task GetAll_ValidParameters_ReturnsPersons()
        {
            // Arrange
            var personRepositoryMock = new Mock<IPersonRepository>();
            var mapperMock = new Mock<IMapper>();
            var personService = new PersonService(personRepositoryMock.Object, mapperMock.Object);

            var ativo = true; // Provide a valid value for testing
            var tipoPessoa = "TipoA"; // Provide a valid value for testing

            personRepositoryMock.Setup(repo => repo.GetAll(ativo, tipoPessoa))
                .ReturnsAsync(new List<Person>());

            // Act
            var result = await personService.GetAll(ativo, tipoPessoa);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByName_ValidParameters_ReturnsPersons()
        {
            // Arrange
            var personRepositoryMock = new Mock<IPersonRepository>();
            var mapperMock = new Mock<IMapper>();
            var personService = new PersonService(personRepositoryMock.Object, mapperMock.Object);

            var tipoPessoa = "TipoA"; 
            var nome = "John Doe"; 

            personRepositoryMock.Setup(repo => repo.GetByName(tipoPessoa, nome))
                .ReturnsAsync(new List<Person>());

            // Act
            var result = await personService.GetByName(tipoPessoa, nome);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Update_ValidPerson_ReturnsSuccess()
        {
            // Arrange
            var personRepositoryMock = new Mock<IPersonRepository>();
            var mapperMock = new Mock<IMapper>();
            var personService = new PersonService(personRepositoryMock.Object, mapperMock.Object);

            var personViewModel = new PersonViewModel
            {
                Id = Guid.NewGuid()
            };

            personRepositoryMock.Setup(repo => repo.Update(It.IsAny<Person>()))
                .ReturnsAsync(ValidationResult.Success);

            // Act
            var result = await personService.Update(personViewModel);

            // Assert
            Assert.Equal(ValidationResult.Success, result);
        }
    }
}
