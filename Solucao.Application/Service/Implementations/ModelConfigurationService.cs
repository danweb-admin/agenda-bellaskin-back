using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Solucao.Application.Data.Entities;
using Solucao.Application.Data.Repositories;
using Solucao.Application.Service.Interfaces;

namespace Solucao.Application.Service.Implementations
{
	public class ModelConfigurationService : IModelConfigurationService
	{
        private readonly AttributeTypesRepository repositoryAttr;
        private readonly TechnicalAttributesRepository repositoryTechnicalAttr;

        public ModelConfigurationService(AttributeTypesRepository _repositoryAttr, TechnicalAttributesRepository _repositoryTechnicalAttr)
		{
            repositoryAttr = _repositoryAttr;
            repositoryTechnicalAttr = _repositoryTechnicalAttr;
		}

        public async Task<IEnumerable<AttributeTypes>> GetAttributeTypes()
        {
            return await repositoryAttr.Get();
        }

        public async Task<IEnumerable<TechnicalAttributes>> GetTechnicalAttributes()
        {
            return await repositoryTechnicalAttr.Get();
        }
    }
}

