using Funcionarios.Application.Dtos;
using Funcionarios.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Funcionarios.Api.Controllers;

[ApiController]
[Route("api/funcionarios")]
public class FuncionarioController : ControllerBase
{

    private readonly IFuncionarioService _funcionarioService;

    public FuncionarioController(IFuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }

    [HttpGet]
    public async Task<ActionResult<List<FuncionarioResponseDto>>> ListarAsync()
    {
        var agendamentos = await _funcionarioService.ListarAsync();
        return Ok(agendamentos);
    }
    
    
    [HttpGet("{id}")]
    public async Task<ActionResult<FuncionarioResponseDto>> BuscarPorIdAsync(int id)
    {
        try
        {
            var  agendamento = await _funcionarioService.BuscarPorIdAsync(id);
            return Ok(agendamento);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    
    [HttpPost]
    public async Task<ActionResult<FuncionarioResponseDto>> AdicionarAsync(FuncionarioRequestDto request)
    {
        try
        {
            var funcionario = await _funcionarioService.AdicionarAsync(request);
            return Created("api/funcionarios",funcionario);
        }
        catch (Exception e)
        {
           return BadRequest(e.Message); 
        }
    }
    
    
    [HttpPut("atualizar/{id}")]
    public async Task<ActionResult<FuncionarioResponseDto>> AtualizarAsync(int id, FuncionarioRequestDto request)
    {
        try
        {
            var agendamento = await _funcionarioService.AtualizarAsync(id, request);
            return Ok(agendamento);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletarAsync(int id)
    {
        try
        {
            await  _funcionarioService.DeletarAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}