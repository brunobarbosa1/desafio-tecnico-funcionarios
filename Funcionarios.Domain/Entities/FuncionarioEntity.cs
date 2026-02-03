namespace Funcionarios.Domain.Entities;

public class FuncionarioEntity
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public String Nacionalidade { get; set; }
    public DateTime DataNascimento { get; set; } 
    
    public bool EhFormadoEmTi{ get; set; }
    

    public FuncionarioEntity(string nome, string nacionalidade, DateTime dataNascimento, bool ehFormadoEmTi)
    {
        if (!ehFormadoEmTi)
        { 
            throw new Exception("Funcionário precisa ser formado em TI para ser cadastrado!");
        }
        if (dataNascimento <= DateTime.Today.AddYears(-18))
        {
            throw new Exception("Funcionário deve ser maior de 18 anos para ser cadastrado!"); 
        }
        Nome = nome;
        Nacionalidade = nacionalidade;
        DataNascimento = dataNascimento;
        EhFormadoEmTi = ehFormadoEmTi;
    }
}