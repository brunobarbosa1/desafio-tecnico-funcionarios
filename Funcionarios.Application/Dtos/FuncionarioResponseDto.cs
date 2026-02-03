namespace Funcionarios.Application.Dtos;

public record FuncionarioResponseDto(
    int Id,
    string Nome,
    string Nacionalidade,
    DateTime DataNascimento,
    bool EhFormadoEmTi
    );