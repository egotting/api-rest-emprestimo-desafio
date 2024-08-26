using api_rest_emprestimo.Model;

namespace api_rest_emprestimo.Repositories;

public interface IUsuarioRepository
{
    public Usuario CreateUser(Usuario user);

    public Usuario GetUniqueUser(string cpf);
    public IEnumerable<Usuario> GetAllUsers();
    
    public bool DeleteUser(Usuario cpf);
}
