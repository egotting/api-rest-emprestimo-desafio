using api_cadastro_backend.Exceptions;
using api_rest_emprestimo.Model;
using api_rest_emprestimo.Model.DTOs.Usuarios;
using api_rest_emprestimo.Repositories;

namespace api_rest_emprestimo.Services;

public class UsuarioServices : IUsuarioServices
{

    private readonly IUsuarioRepository _repository;

    public UsuarioServices(IUsuarioRepository repository)
    {
        _repository = repository;
    }
    public UsuarioResponse CreateUser(UsuarioRequest request)
    {
        var user = new Usuario(request.Age, request.Cpf, request.FullName, request.Wage, request.Location);
        user = _repository.CreateUser(user);
        return new UsuarioResponse(user.Age,user.FullName, user.Wage, user.Location);
    }

    public IEnumerable<UsuarioResponse> GetInfoAllUser()
    {
        return _repository.GetAllUsers()
        .Select(user => new UsuarioResponse(user.Age, user.FullName, user.Wage, user.Location))
        .ToList();
    }

    public Usuario GetUniqueUser(string cpf)
    {
        var user = _repository.GetUniqueUser(cpf);
        return user;
    }

    public bool DeleteUser(string cpf)
    {
        var deleteUser = _repository.GetUniqueUser(cpf) 
            ?? throw new NotFoundEmailUser("User not found");
        return _repository.DeleteUser(deleteUser);
    }
}
