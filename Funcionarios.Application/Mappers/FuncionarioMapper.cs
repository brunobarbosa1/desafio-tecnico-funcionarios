using Funcionarios.Application.Dtos;
using Funcionarios.Domain.Entities;

namespace Funcionarios.Application.Mappers;

public class FuncionarioMapper
{
    public static FuncionarioEntity ToEntity(FuncionarioRequestDto dto)
    {
        return new FuncionarioEntity(
            dto.Nome,
            dto.Nacionalidade,
            dto.DataNascimento,
            dto.EhFormadoEmTi
            );
    }

    
    public static FuncionarioResponseDto ToDto(FuncionarioEntity funcionario)
    {
        return new FuncionarioResponseDto(
            funcionario.Id,
            funcionario.Nome,
            funcionario.Nacionalidade,
            funcionario.DataNascimento,
            funcionario.EhFormadoEmTi);
    }
}