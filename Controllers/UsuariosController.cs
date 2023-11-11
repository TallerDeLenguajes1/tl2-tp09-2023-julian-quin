using Microsoft.AspNetCore.Mvc;
using TP_BaseDeDatosWebApi;

namespace TP_BaseDeDatosWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
  

    private readonly ILogger<UsuarioController> _logger;
    private IUsuarioRepository accesoRepository;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        accesoRepository = new UsuarioRepositorio();
    }

    [HttpGet("/api/usuarios")]
    public ActionResult <List<Usuario>> Usuarios()
    {
        return Ok(accesoRepository.Usuarios());

    }
    [HttpPost("/api/Usuario")]
    public ActionResult NuevoUsuario (Usuario usuario)
    {
        accesoRepository.NuevoUsuario(usuario);
        return Ok();  
    }
    [HttpPut("/api/Usuario/{idUsuario}")]
    public ActionResult ModificarUsuario(int idUsuario, Usuario usuario)
    {
        accesoRepository.ActualizarUsuario(usuario, idUsuario);
        return Ok();  
    }
    [HttpGet("/api/Usuario/{idUsuario}")]
    public ActionResult UsuarioViaId(int idUsuario)
    {
        return Ok(accesoRepository.UsuarioViaId(idUsuario));
    }
    [HttpDelete("/api/Usuario/{idUsuario}")]
     public ActionResult EliminarUsuario(int idUsuario)
    {
        accesoRepository.EliminarUsuario(idUsuario);
        return Ok();
    }
}
