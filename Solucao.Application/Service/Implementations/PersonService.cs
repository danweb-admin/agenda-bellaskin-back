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
    public class PersonService : IPersonService
    {
        private IPersonRepository personRepository;
        private readonly IMapper mapper;

        public PersonService(IPersonRepository _personRepository, IMapper _mapper)
        {
            personRepository = _personRepository;
            mapper = _mapper;
        }

        public Task<ValidationResult> Add(PersonViewModel person)
        {
            person.Id = Guid.NewGuid();
            person.CreatedAt = DateTime.Now;
            var _person = mapper.Map<Person>(person);
            return personRepository.Add(_person);
        }

        public async Task<IEnumerable<PersonViewModel>> GetAll(bool ativo, string tipo_pessoa)
        {
            return mapper.Map<IEnumerable<PersonViewModel>>(await personRepository.GetAll(ativo, tipo_pessoa));
        }

        public async Task<IEnumerable<PersonViewModel>> GetByName(string tipo_pessoa, string nome)
        {
            return mapper.Map<IEnumerable<PersonViewModel>>(await personRepository.GetByName(tipo_pessoa, nome));
        }

        public Task<ValidationResult> Update(PersonViewModel person)
        {
            person.UpdatedAt = DateTime.Now;
            var _person = mapper.Map<Person>(person);
            
            return personRepository.Update(_person);
        }

        
    }
}
