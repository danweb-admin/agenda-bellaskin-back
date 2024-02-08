
using Dynamitey;
using Newtonsoft.Json;
using Solucao.Application.Data.Entities;
using Solucao.Application.Data.Repositories;
using Solucao.Application.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Solucao.Application.Service.Implementations
{
    public class CityService : ICityService
    {
        private StateRepository stateRepository;
        private CityRepository cityRepository;

        private readonly IHttpClientFactory clientFactory;

        public CityService(StateRepository _stateRepository, CityRepository _cityRepository, IHttpClientFactory _clientFactory)
        {
            stateRepository = _stateRepository;
            cityRepository = _cityRepository;
            clientFactory = _clientFactory;

        }
        public async Task<ValidationResult> AddIBGECitiesList()
        {
            HttpResponseMessage response = null;
            var citiesList = new List<City>();
            var states = stateRepository.GetAll();

            foreach (var state in states)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{state.Id}/municipios");

                var client = clientFactory.CreateClient();
                response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    dynamic json = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

                    foreach (var item in json)
                    {
                        var id = Dynamic.InvokeGet(item, "id");
                        var nome = Dynamic.InvokeGet(item, "nome");

                        var city = new City { Id = id, Nome = nome, StateId = state.Id };
                        citiesList.Add(city);
                    }

                    await cityRepository.Add(citiesList);
                    citiesList = new List<City>();
                }
            }
            
            return new ValidationResult(response?.StatusCode.ToString());
        }
    }
}
