using System;
using Solucao.Application.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Solucao.Application.Data.Entities;

namespace Solucao.Application.Service.Interfaces
{
	public interface IModelConfigurationService
	{
        Task<IEnumerable<TechnicalAttributes>> GetTechnicalAttributes();
        Task<IEnumerable<AttributeTypes>> GetAttributeTypes();

    }
}

