using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solucao.Application.Service.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Solucao.API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Authorize]
    public class StatesController : ControllerBase
    {
        private readonly IStateService stateService;

        public StatesController(IStateService _stateService)
        {
            stateService = _stateService;
        }

        [HttpGet("states/add-states-list")]
        public async Task<ValidationResult> AddStatesList()
        {
            return await stateService.AddIBGEStatesList();
        }
    }
}
