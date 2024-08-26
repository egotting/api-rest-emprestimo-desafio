using System.ComponentModel.DataAnnotations;
using api_rest_emprestimo.Validate;

namespace api_rest_emprestimo.Model.DTOs.Usuarios;

public record UsuarioRequest(
    [Required(ErrorMessage = "Precisa por a sua idade")]
    int Age,
    [Required(ErrorMessage = "Precisa por seu Cpf")]
    string Cpf,
    [Required(ErrorMessage = "Precisa por o seu nome")]
    string FullName,
    [Required(ErrorMessage = "precisa por seu salario")]
    float Wage,
    [Required(ErrorMessage = "precisa por sua localização")]
    string Location
);
