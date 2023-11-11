using Microsoft.AspNetCore.Mvc;
using TP_BaseDeDatosWebApi;

namespace TP_BaseDeDatosWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TareasController : ControllerBase
{
  

    private readonly ILogger<TareasController> _logger;
    private ITareasRepository accesoRepository;

    public TareasController(ILogger<TareasController> logger)
    {
        _logger = logger;
        accesoRepository = new TareasRepository();
    }

    [HttpPost("/api/Tarea/{idTablero}")]
    public ActionResult CrearTarea(int idTablero,Tarea tarea)
    {
        var TareaCreada = accesoRepository.CrearTarea(idTablero , tarea);
        return Ok(TareaCreada);  
    }

    [HttpGet("/api/Tarea/Usuario/{idUsuario}")]
    public ActionResult <List<Usuario>> TareasDeUnUsuario(int idUsuario)
    {
        return Ok(accesoRepository.TareasDeUnUsuario(idUsuario));

    }

    [HttpPut("/Api/Tarea/{idTarea}")]
    public ActionResult ModificarTarea(int idTarea, Tarea actualizacion)
    {
        accesoRepository.ModificarTarea(idTarea,actualizacion);
        return Ok("Tarea Actualizada");  
    }

    
    [HttpGet("Tarea/{idTarea}")] // no se pidió!
    public ActionResult TareaId(int idTarea)
    {
        var tareaEncontrada = accesoRepository.TareaId(idTarea);
        if(tareaEncontrada!=null)return Ok(tareaEncontrada);
        return NotFound("Error en la solicitud");
    }

    [HttpDelete("/api/Tarea/{idTarea}")]
     public ActionResult EliminarTarea(int idTarea)
    {
        accesoRepository.EliminarTarea(idTarea);
        return Ok();
    }
}
