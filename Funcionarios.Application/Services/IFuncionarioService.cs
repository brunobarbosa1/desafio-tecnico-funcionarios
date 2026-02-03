using Funcionarios.Application.Dtos;

namespace Funcionarios.Application.Services;

public interface IFuncionarioService
{
    Task<FuncionarioResponseDto> AdicionarAsync(FuncionarioRequestDto request);
    Task<List<FuncionarioResponseDto>> ListarAsync();
    Task<FuncionarioResponseDto?> BuscarPorIdAsync(int idAgendamento);
    Task<FuncionarioResponseDto>  AtualizarAsync(int idAgendamento, FuncionarioRequestDto request);
    Task DeletarAsync(int idAgendamento);
}