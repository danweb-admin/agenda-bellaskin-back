using AutoMapper;
using Solucao.Application.Contracts;
using Solucao.Application.Data.Entities;
using Solucao.Application.Data.Interfaces;
using Solucao.Application.Data.Repositories;
using Solucao.Application.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucao.Application.Service.Implementations
{
    public class ClientService : IClientService
    {
        private IClientRepository clientRepository;
        private readonly IMapper mapper;

        public ClientService(IClientRepository _clientRepository, IMapper _mapper)
        {
            clientRepository = _clientRepository;
            mapper = _mapper;
        }
        public Task<ValidationResult> Add(ClientViewModel client)
        {
            client.Id = Guid.NewGuid();
            client.CreatedAt = DateTime.Now;
            var _client = mapper.Map<Client>(client);

            return clientRepository.Add(_client);
        }

        public async Task<IEnumerable<ClientViewModel>> GetAll(bool ativo, string search)
        {
            return mapper.Map<IEnumerable<ClientViewModel>>(await clientRepository.GetAll(ativo,search));
        }

        public Task<ClientViewModel> GetById(Guid Id)
        {
            return mapper.Map<Task<ClientViewModel>>(clientRepository.GetById(Id));
        }

        public Task<ValidationResult> Update(ClientViewModel client)
        {
            client.UpdatedAt = DateTime.Now;
            var _client = mapper.Map<Client>(client);

            return clientRepository.Update(_client);
        }
    }
}
