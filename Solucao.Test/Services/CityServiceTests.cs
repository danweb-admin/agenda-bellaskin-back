using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using Moq;
using Moq.Protected;
using Solucao.Application.Data;
using Solucao.Application.Data.Entities;
using Solucao.Application.Data.Repositories;
using Solucao.Application.Service.Implementations;

namespace Solucao.Tests
{
    public class CityServiceTests
    {
        private Mock<SolucaoContext> contextMock;
        private Mock<StateRepository> stateRepositoryMock;
        private Mock<CityRepository> cityRepositoryMock;
        private Mock<IHttpClientFactory> httpClientFactoryMock;
        private Mock<HttpMessageHandler> handlerMock;
        private Mock<IHttpClientFactory> mockHttpClientFactory;
        private Mock<HttpClient> httpClientMock;
        

        public CityServiceTests()
        {
            handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            contextMock = new Mock<SolucaoContext>();
            stateRepositoryMock = new Mock<StateRepository>();
            cityRepositoryMock = new Mock<CityRepository>();
            httpClientFactoryMock = new Mock<IHttpClientFactory>();

            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            dynamic json = new[]
            {
                new { id = 1, nome = "City1" },
                new { id = 2, nome = "City2" }
            };

            httpResponseMessage.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(json));
            var validationResult = ValidationResult.Success;

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(httpResponseMessage)
                .Verifiable();

            httpClientMock = new Mock<HttpClient>(handlerMock.Object);

            mockHttpClientFactory = new Mock<IHttpClientFactory>();

            mockHttpClientFactory.Setup(_ => _.CreateClient(string.Empty)).Returns(httpClientMock.Object);

            stateRepositoryMock.Setup(repo => repo.GetAll()).Returns(new List<State>
            {
                new State { Id = 1 },
                new State { Id = 2 }
            });

            cityRepositoryMock.Setup(repo => repo.Add(It.IsAny<List<City>>())).Returns(Task.FromResult<ValidationResult>(validationResult));

        }

        [Fact]
        public async Task AddIBGECitiesList_Success()
        {

            var cityService = new CityService(stateRepositoryMock.Object, cityRepositoryMock.Object, mockHttpClientFactory.Object);

            // Act
            var result = await cityService.AddIBGECitiesList();

            // Assert
            Assert.NotNull(result);
            cityRepositoryMock.Verify(repo => repo.Add(It.IsAny<List<City>>()), Times.Exactly(2));
        }

        [Fact]
        public async Task AddIBGECitiesList_Error()
        {
            //Arrange
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(httpResponseMessage)
                .Verifiable();

            var cityService = new CityService(stateRepositoryMock.Object, cityRepositoryMock.Object, mockHttpClientFactory.Object);
            // Act
            var result = await cityService.AddIBGECitiesList();

            // Assert
            Assert.Equal(HttpStatusCode.NotFound.ToString(), result.ErrorMessage);
            cityRepositoryMock.Verify(repo => repo.Add(It.IsAny<List<City>>()), Times.Never);
        }
    }
}
