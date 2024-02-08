using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solucao.Application.Contracts;
using Solucao.Application.Service.Interfaces;

namespace Solucao.API.Controllers
{
    [Route("api/v1/model-attributes")]
    [ApiController]
    [Authorize]
    public class ModelAttributesController : ControllerBase
	{
        private readonly IModelAttributesService service;

        public ModelAttributesController(IModelAttributesService _service)
		{
            service = _service;
		}

        [HttpGet]
        public async Task<IActionResult> Get(Guid modelId)
        {
            var modelos = await service.GetAll(modelId);
            return Ok(modelos);
        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody] ModelAttributeViewModel model)
        {

            var result = await service.Add(model);

            if (result != null)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] ModelAttributeViewModel model)
        {
            var result = await service.Update(model);

            if (result != null)
                return NotFound(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await service.Remove(id);

            if (result != null)
                return NotFound(result);
            return Ok(result);
        }
    }
}

