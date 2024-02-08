using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucao.Application.Service.Interfaces
{
    public interface ICityService
    {
        Task<ValidationResult> AddIBGECitiesList();

    }
}
