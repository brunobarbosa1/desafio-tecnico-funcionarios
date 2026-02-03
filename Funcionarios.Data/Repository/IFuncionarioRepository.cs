using Funcionarios.Domain.Entities;

namespace Funcionarios.Data.Repository;

public interface IFuncionarioRepository
{
    Task<FuncionarioEntity> AdicionarAsync(FuncionarioEntity funcionario);
    Task<List<FuncionarioEntity>> ListarAsync();
    Task<FuncionarioEntity?> BuscarPorIdAsync(int id);
    Task DeletarAsync(FuncionarioEntity funcionario);
    Task SalvarAsync(FuncionarioEntity funcionario);
}