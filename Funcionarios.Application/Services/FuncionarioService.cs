using Funcionarios.Application.Dtos;
using Funcionarios.Application.Mappers;
using Funcionarios.Data.Repository;
using Funcionarios.Domain.Entities;

namespace Funcionarios.Application.Services;

public class FuncionarioService : IFuncionarioService
{
    
    private readonly IFuncionarioRepository _funcionarioRepository;

    public FuncionarioService(IFuncionarioRepository funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
    }


    public async Task<FuncionarioResponseDto> AdicionarAsync(FuncionarioRequestDto request)
    {
       var funcionario = FuncionarioMapper.ToEntity(request);
       FuncionarioEntity.ValidarEntidade(funcionario);
       
       await _funcionarioRepository.AdicionarAsync(funcionario);
       await _funcionarioRepository.SalvarAsync(funcionario);
       
       return FuncionarioMapper.ToDto(funcionario);
    }

    
    public async Task<List<FuncionarioResponseDto>> ListarAsync()
    {
        var funcionarios = await _funcionarioRepository.ListarAsync();
        var response = new List<FuncionarioResponseDto>();

        foreach (var funcionario in funcionarios)
        {
            response.Add(FuncionarioMapper.ToDto(funcionario));
        }
        return response;
    }
    

    public async Task<FuncionarioResponseDto?> BuscarPorIdAsync(int idAgendamento)
    {
        var funcionario = await _funcionarioRepository.BuscarPorIdAsync(idAgendamento);
        if (funcionario == null)
        {
            throw new Exception("Funcionário não encontrado!");
        }
        return FuncionarioMapper.ToDto(funcionario);
    }
    

    public async Task<FuncionarioResponseDto> AtualizarAsync(int idAgendamento, FuncionarioRequestDto request)
    {
        var funcionario = await _funcionarioRepository.BuscarPorIdAsync(idAgendamento);
        
        if (funcionario == null)
        {
            throw new Exception("Funcionário não encontrado para atualização!");
        }
        
        funcionario.Nome = request.Nome;
        funcionario.Nacionalidade = request.Nacionalidade;
        funcionario.DataNascimento = request.DataNascimento;
        funcionario.EhFormadoEmTi = request.EhFormadoEmTi;
        
        FuncionarioEntity.ValidarEntidade(funcionario);
        await _funcionarioRepository.SalvarAsync(funcionario);
        
        return FuncionarioMapper.ToDto(funcionario);
    }

    
    public async Task DeletarAsync(int idAgendamento)
    {
        var funcionario = await _funcionarioRepository.BuscarPorIdAsync(idAgendamento);
        if (funcionario == null)
        {
            throw new Exception("Funcionário não encontrado para deleção!");
        }
        await _funcionarioRepository.DeletarAsync(funcionario);
    }
}