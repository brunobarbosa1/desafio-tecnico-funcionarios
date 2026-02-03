namespace Funcionarios.Domain.Entities;

public class FuncionarioEntity
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Nacionalidade { get; set; }
    public DateTime DataNascimento { get; set; } 
    public bool EhFormadoEmTi{ get; set; }


    public FuncionarioEntity(string nome, string nacionalidade, DateTime dataNascimento, bool ehFormadoEmTi)
    {
        Nome = nome;
        Nacionalidade = nacionalidade;
        DataNascimento = dataNascimento;
        EhFormadoEmTi = ehFormadoEmTi;
    }

    public static void ValidarEntidade(FuncionarioEntity funcionario)
    {
        if (!funcionario.EhFormadoEmTi)
        {
            throw new Exception("Funcionário precisa ser formado em TI para ser cadastrado!");
        }

        if (funcionario.DataNascimento >= DateTime.Today.AddYears(-18))
        {
            throw new Exception("Funcionário deve ser maior de 18 anos para ser cadastrado!");
        }
    }


}