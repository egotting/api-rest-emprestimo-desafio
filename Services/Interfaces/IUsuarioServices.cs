using api_rest_emprestimo.Model;
using api_rest_emprestimo.Model.DTOs.Usuarios;

namespace api_rest_emprestimo.Services;

public interface IUsuarioServices
{
    public UsuarioResponse CreateUser(UsuarioRequest request);

    public IEnumerable<UsuarioResponse> GetInfoAllUser();
    Usuario GetUniqueUser(string cpf);
    public bool DeleteUser(string cpf);
}
