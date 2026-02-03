namespace Funcionarios.Application.Dtos;

public record FuncionarioRequestDto(
    string Nome,
    string Nacionalidade,
    DateTime DataNascimento,
    bool EhFormadoEmTi
    );