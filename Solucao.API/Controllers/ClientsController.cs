using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solucao.Application.Contracts;
using Solucao.Application.Contracts.Requests;
using Solucao.Application.Enum;
using Solucao.Application.Service.Interfaces;
using Solucao.Application.Utils;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Solucao.API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Authorize]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService clientService;
        private readonly IHistoryService historyService;


        public ClientsController(IClientService _clientService, IHistoryService _historyService)
        {
            clientService = _clientService;
            historyService = _historyService;
        }

        [HttpGet("client")]
        public async Task<IEnumerable<ClientViewModel>> GetAllAsync([FromQuery] ClientRequest clientRequest)
        {
            return await clientService.GetAll(clientRequest.Ativo,clientRequest.Search);
        }


        [HttpPost("client")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ApplicationError))]
        public async Task<IActionResult> PostAsync([FromBody] ClientViewModel model)
        {
            var result = await clientService.Add(model);

            if (result != null)
                return NotFound(result);

            await historyService.Add(TableEnum.Client.ToString(), OperationEnum.Criacao.ToString(), User.Identity.Name, $"Client: Nome: {model.Name}, Endereco: {model.Address}");

            return Ok(result);
        }


        [HttpPut("client/{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] ClientViewModel model)
        {
            var result = await clientService.Update(model);

            if (result != null)
                return NotFound(result);

            await historyService.Add(TableEnum.Client.ToString(), OperationEnum.Alteracao.ToString(), User.Identity.Name, $"Client: Nome: {model.Name}, Endereco: {model.Address}");


            return Ok(result);
        }
    }
}
