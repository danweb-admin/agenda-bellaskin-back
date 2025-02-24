﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solucao.Application.Contracts;
using Solucao.Application.Contracts.Requests;
using Solucao.Application.Data.Entities;
using Solucao.Application.Service.Interfaces;
using Solucao.Application.Utils;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Solucao.API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    //[Authorize]
    public class EquipamentController : ControllerBase
    {
        private readonly IEquipamentService service;

        public EquipamentController(IEquipamentService _service)
        {
            service = _service;
        }

        [HttpGet("equipaments")]
        public async Task<IEnumerable<EquipamentViewModel>> GetAllAsync([FromQuery] EquipamentRequest request)
        {
            return await service.GetAll(request.Ativo);
        }

        [HttpPost("equipaments")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ApplicationError))]
        public async Task<IActionResult> PostAsync([FromBody] EquipamentViewModel model)
        {

            var result = await service.Add(model);

            if (result != null)
                return NotFound(result);
            return Ok(result);
        }


        [HttpPut("equipaments/{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] EquipamentViewModel model)
        {
            var result = await service.Update(model);

            if (result != null)
                return NotFound(result);
            return Ok(result);
        }
    }
}
