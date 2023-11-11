using Microsoft.AspNetCore.Mvc;

namespace TP_BaseDeDatosWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TableroController : ControllerBase
{
  

    private readonly ILogger<TableroController> _logger;
    private ITableroRepository accesoRepository;

    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        accesoRepository = new TableroRepository();
    }
    [HttpGet("/api/Tableros")]
    public ActionResult<List<Tablero>> Tableros()
    {
        return Ok(accesoRepository.Tableros());
    }

    [HttpPost("/api/Tablero")]
    public ActionResult<Tablero> NuevoTablero(Tablero tablero)
    {
        accesoRepository.NuevoTablero(tablero);
        return Ok();  
    }

    //DESDE ACÁ SON ENDPOINT QUE NO SE PIDIERON
    
    [HttpPut("/api/Tablero/{idTablero}")]
    public ActionResult ActualizarTablero(int idTablero, Tablero tablero)
    {
        accesoRepository.ModificarTablero(tablero, idTablero);
        return Ok("Tablero Modificado");  
    }
    [HttpGet("/api/Tablero/{id}")]
    public ActionResult<Tablero> TableroViaId(int idTablero)
    {
        var tableroEncontrado = accesoRepository.TableroViaId(idTablero);
        if (tableroEncontrado!=null)return Ok(tableroEncontrado);
        return NotFound("Recurso no encontrado");
        
    }

    [HttpGet("/api/Tableros/{idUsuario}")]
    public ActionResult<List<Tablero>> TablerosDeUnUsuario(int idUsuario)
    {
        return Ok(accesoRepository.TablerosDeUnUsuario(idUsuario));
    }

    [HttpDelete("/api/Tablero/{idTablero}")]
     public ActionResult BorrarTablero(int idTablero)
    {
        accesoRepository.EliminarTablero(idTablero);
        return Ok();
    }
}