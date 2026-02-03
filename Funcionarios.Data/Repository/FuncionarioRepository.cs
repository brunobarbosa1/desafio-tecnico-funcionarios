using Funcionarios.Data.Data;
using Funcionarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Funcionarios.Data.Repository;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly AppDbContext _context;
    
    public FuncionarioRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<FuncionarioEntity> AdicionarAsync(FuncionarioEntity funcionario)
    {
        await _context.Funcionarios.AddAsync(funcionario);
        return funcionario;
    }

    public async Task<List<FuncionarioEntity>> ListarAsync()
    {
        return await _context.Funcionarios.ToListAsync();
    }

    public async Task<FuncionarioEntity?> BuscarPorIdAsync(int id)
    {
        return await _context.Funcionarios.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task DeletarAsync(FuncionarioEntity funcionario)
    { 
        _context.Funcionarios.Remove(funcionario);
        await _context.SaveChangesAsync();
    }

    public async Task SalvarAsync(FuncionarioEntity funcionario)
    {
        await _context.SaveChangesAsync();
    }
}