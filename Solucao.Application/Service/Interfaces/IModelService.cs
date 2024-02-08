using System;
using Solucao.Application.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Solucao.Application.Service.Interfaces
{
	public interface IModelService
	{
        Task<IEnumerable<ModelViewModel>> GetAll();

        Task<ValidationResult> Add(ModelViewModel model);

        Task<ValidationResult> Update(ModelViewModel model);
    }
}

