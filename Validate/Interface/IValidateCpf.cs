namespace api_rest_emprestimo.Validate.Interface;

public interface IValidateCpf
{
    public bool ValidCpf(string cpf);
    public string RemoveIsNotNumeric(string txt);
}
