using DeepBlue.Application.Commands;
using DeepBlue.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Projeto.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaApplicationService pessoaApplicationService;

        public PessoaController(IPessoaApplicationService pessoaApplicationService)
        {
            this.pessoaApplicationService = pessoaApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PessoaCreateCommand command)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var result = await pessoaApplicationService.Create(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(PessoaUpdateCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var result = await pessoaApplicationService.Update(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var command = new PessoaDeleteCommand { Id = id };
                var result = await pessoaApplicationService.Delete(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(pessoaApplicationService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                return Ok(pessoaApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}