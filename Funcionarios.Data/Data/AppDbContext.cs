using Funcionarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Funcionarios.Data.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<FuncionarioEntity> Funcionarios { get; set; }
}