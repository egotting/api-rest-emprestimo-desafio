using api_rest_emprestimo.Model.DTOs.Usuarios;
using api_rest_emprestimo.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_rest_emprestimo.Controller;
[ApiController]
[Route("/v1")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioServices _service;

    public UsuariosController(IUsuarioServices service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("/Users")]
    public IActionResult GetAllUsers()
    {
        return Ok(_service.GetInfoAllUser());    
    }
    
    [HttpGet]
    [Route("/usuario/{email}")]
    public IActionResult GetUniqueUser(string cpf)
    {
        return Ok(_service.GetUniqueUser(cpf));
    }
    [HttpPost]
    [Route("/Cadastre-se")]
    public IActionResult CadasterUser([FromBody] UsuarioRequest user)
    {
        if(!ModelState.IsValid){
            return BadRequest(user);
        }

        var result = _service.CreateUser(user);
        return Ok(result);
    }

        [HttpDelete]
    [Route("/Delete")]
    public IActionResult DeleteUser(string cpf)
    {
        _service.DeleteUser(cpf);
        return NoContent();
    }
}
