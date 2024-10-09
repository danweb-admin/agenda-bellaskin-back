using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Solucao.Application.Utils;
using Solucao.Application.Contracts;
using Solucao.Application.Data.Entities;
using Solucao.Application.Service.Implementations;
using Solucao.Application.Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Solucao.Application.Contracts.Requests;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using Solucao.Application.Enum;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Solucao.API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly TokenService tokenService;
        private readonly IHistoryService historyService;
        private readonly ILogger<UsersController> logger;

        
        public UsersController(IUserService _userService, TokenService _tokenService, ILogger<UsersController> _logger, IHistoryService _historyService)
        {
            userService = _userService;
            tokenService = _tokenService;
            historyService = _historyService;
            logger = _logger;
        }


        [HttpGet("user")]
        [Authorize]
        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            logger.LogInformation($"{nameof(GetAllAsync)} | Inicio da chamada");
            return await userService.GetAll();
        }

        [HttpPost("user")]
        [Authorize]
        public async Task<IActionResult> PostAsync([FromBody] User model)
        {
            logger.LogInformation($"{nameof(PostAsync)} | Inicio da chamada - {model.Email}");
            var result = await userService.Add(model);

            if (result != null)
            {
                logger.LogWarning($"{nameof(PostAsync)} | Erro na criacao - {model.Email} - {result}");
                return NotFound(result);
            }

            await historyService.Add(TableEnum.User.ToString(), OperationEnum.Criacao.ToString(), User.Identity.Name, $"UserName: {model.Name},Email: {model.Email}");

            return Ok(result);
        }


        [HttpPut("user/{id}")]
        [Authorize]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] User model)
        {
            logger.LogInformation($"{nameof(PutAsync)} | Inicio da chamada - {model.Email}");
            var result = await userService.Update(model, id);

            if (result != null)
            {
                logger.LogWarning($"{nameof(PutAsync)} | Erro na atualizacao - {model.Email} - {result}");
                return NotFound(result);

            }
            await historyService.Add(TableEnum.User.ToString(), OperationEnum.Alteracao.ToString(), User.Identity.Name, $"UserId: {id}");

            return Ok(result);
            
        }

        [HttpPost("user/change-user-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ChangeUserPassworAsync([FromBody] ChangeUserPasswordRequest model)
        {
            logger.LogInformation($"{nameof(ChangeUserPassworAsync)} | Inicio da chamada - {model.Email}");

            var userAuthenticated = await userService.GetByName(User.Identity.Name);

            var user = await userService.GetByEmail(model.Email);

            if (userAuthenticated.Name != user.Name)
            {
                logger.LogWarning($"{nameof(ChangeUserPassworAsync)} | Erro Autenticacao - {model.Email}");
                return BadRequest(new ApplicationError { Code = "404", Message = "Você não pode alterar a senha de outro usuário." });
            }

            if (user == null)
            {
                logger.LogWarning($"{nameof(ChangeUserPassworAsync)} | Erro Autenticacao - {model.Email}");
                return BadRequest(new ApplicationError { Code = "404", Message = "Usuário não encontrado." });

            }

            await historyService.Add(TableEnum.User.ToString(), OperationEnum.Alteracao.ToString(), User.Identity.Name, $"AlteracaoSenha: {model.Email}");

            return Ok(await userService.ChangeUserPassword(user,model.Password));
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] User model)
        {
            logger.LogInformation($"{nameof(Authenticate)} | Inicio da chamada - {model.Email}");
            // Recupera o usuário
            var user = await userService.Authenticate(model.Email, model.Password);

            // Verifica se o usuário existe
            if (user == null)
            {
                logger.LogWarning($"{nameof(Authenticate)} | Erro Autenticacao - {model.Email}");
                return BadRequest(new ApplicationError { Code = "400", Message = "Senha ou usuário inválido." });
            }

            await historyService.Add(TableEnum.User.ToString(), OperationEnum.Logou.ToString(), user.Name, string.Empty);

            // Gera o Token
            var token = tokenService.GenerateToken(user);

            // Retorna os dados
            return Ok(new
            {
                user = user,
                token = token
            });
        }
    }
}
