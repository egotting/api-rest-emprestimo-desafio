using api_cadastro_backend.Exceptions;
using api_rest_emprestimo.Model;

namespace api_rest_emprestimo.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly Context _context;

    public UsuarioRepository(Context _context)
    {
        this._context = _context;
    }
    public Usuario CreateUser(Usuario user)
    {
        _context.Usuarios.Add(user);
        _context.SaveChangesAsync();
        return user;
    }

    public bool DeleteUser(Usuario cpf)
    {
        _context.Usuarios.Remove(cpf);
        _context.SaveChanges();
        return true;
    }
    public IEnumerable<Usuario> GetAllUsers()
    {
        return _context.Usuarios.ToList();
    }
        public Usuario GetUniqueUser(string cpf)
    {
        return _context.Usuarios.Where(e => e.Cpf == cpf)
                .FirstOrDefault(x => x.Cpf == cpf)
            ?? throw new NotFoundEmailUser("Not found User");
    }
}
