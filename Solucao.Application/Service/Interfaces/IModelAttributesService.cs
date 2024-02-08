using System;
using Solucao.Application.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Solucao.Application.Service.Interfaces
{
	public interface IModelAttributesService
	{
        Task<IEnumerable<ModelAttributeViewModel>> GetAll(Guid modelId);
        Task<ValidationResult> Add(ModelAttributeViewModel model);
        Task<ValidationResult> Update(ModelAttributeViewModel model);
        Task<ValidationResult> Remove(Guid id);

    }
}

