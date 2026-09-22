using Banquinho.Application.DTOs.Requests;
using Banquinho.Application.DTOs.Responses;
using Banquinho.Application.Services;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace Banquinho.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPost]
        [ProducesResponseType(typeof(AccountResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateAccountRequest request)
        {
            try
            {
                var response = await _accountService.CreateAccountAsync(request);

                
                return CreatedAtAction(nameof(GetById), new { id = response.AccountId }, response);
            }
            catch (ValidationException ex)
            {
                
                var errors = ex.Errors.Select(e => new
                {
                    Campo = e.PropertyName,
                    Mensagem = e.ErrorMessage
                });

                return BadRequest(new { Titulo = "Erro de Validação", Erros = errors });
            }
        }
      

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(AccountResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _accountService.GetAccountByIdAsync(id);

            if (response is null)
                return NotFound(new { Mensagem = $"Conta com ID '{id}' não foi encontrada." });

            return Ok(response);
        }
    }
}
