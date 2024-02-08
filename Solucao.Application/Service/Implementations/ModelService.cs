using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Solucao.Application.Contracts;
using Solucao.Application.Data.Entities;
using Solucao.Application.Data.Repositories;
using Solucao.Application.Service.Interfaces;

namespace Solucao.Application.Service.Implementations
{
	public class ModelService : IModelService
	{
        private readonly ModelRepository modelRepository;
        private readonly ModelAttributesRepository modelAttributesRepository;

        private readonly IMapper mapper;

        public ModelService(ModelRepository _modelRepository, IMapper _mapper, ModelAttributesRepository _modelAttributesRepository)
		{
            modelRepository = _modelRepository;
            mapper = _mapper;
            modelAttributesRepository = _modelAttributesRepository;
		}

        public async Task<ValidationResult> Add(ModelViewModel model)
        {
            model.Id = Guid.NewGuid();
            model.CreatedAt = DateTime.Now;
            var _model = mapper.Map<Model>(model);
            await modelRepository.Add(_model);

            return ValidationResult.Success;
        }

        public async Task<IEnumerable<ModelViewModel>> GetAll()
        {
            return mapper.Map<IEnumerable<ModelViewModel>>(await modelRepository.GetAll());
        }

        public async Task<ValidationResult> Update(ModelViewModel model)
        {
            
            var _model = mapper.Map<Model>(model);

            var result = await modelRepository.Update(_model);

            return ValidationResult.Success;

        }
    }
}

