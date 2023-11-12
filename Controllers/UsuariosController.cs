using Microsoft.AspNetCore.Mvc;

namespace tl2_tp09_2023_Julian_quin.Controllers;

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
    public ActionResult NuevoUsuario(Usuario usuario)
    {
        accesoRepository.NuevoUsuario(usuario);
        return Ok("Nuevo Recurso Creado");  
    }
    [HttpPut("/api/Usuario/{idUsuario}")]
    public ActionResult ModificarUsuario(int idUsuario, Usuario usuario)
    {
        
        if(accesoRepository.ActualizarUsuario(usuario, idUsuario))return Ok("Recurso Actualizado");
        return NotFound ("Recurso No Encontrado");  
    }
    [HttpGet("/api/Usuario/{idUsuario}")]
    public ActionResult UsuarioViaId(int idUsuario)
    {
        var usuario = accesoRepository.UsuarioViaId(idUsuario);
        if (usuario!=null)return Ok(usuario);
        return NotFound("Recurso no encontrado");
        
    }
    [HttpDelete("/api/Usuario/{idUsuario}")]
     public ActionResult EliminarUsuario(int idUsuario)
    {
        if(accesoRepository.EliminarUsuario(idUsuario)) return Ok("Recurso Actualizado");
        return NotFound ("Recurso No Encontado");
    }
}
