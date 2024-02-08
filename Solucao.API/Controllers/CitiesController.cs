using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService cityService;
        public CitiesController(ICityService _cityService)
        {
            cityService = _cityService;
        }

        [HttpGet("cities/add-cities-list")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(City))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ApplicationError))]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Type = typeof(ApplicationError))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ApplicationError))]
        public async Task<ValidationResult> AddStatesList()
        {
            return await cityService.AddIBGECitiesList();
        }
    }
}
