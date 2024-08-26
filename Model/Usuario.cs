using System.ComponentModel.DataAnnotations;
using api_rest_emprestimo.Validate;

namespace api_rest_emprestimo.Model;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Precisa colocar sua idade")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Precisa por seu Cpf")]
    public string Cpf { get; set; }
    
    [Required(ErrorMessage = "Precisa por seu nome completo")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Precisa por o seu Salario")]
    public float Wage { get; set; }

    [Required(ErrorMessage = "precisa por sua localização")]
    public string Location { get; set; }

    public Usuario()
    {
    }

    public Usuario(int age, string cpf, string fullName, float wage, string location)
    {
        Age = age;
        Cpf = cpf;
        FullName = fullName;
        Wage = wage;
        Location = location;
    }
}