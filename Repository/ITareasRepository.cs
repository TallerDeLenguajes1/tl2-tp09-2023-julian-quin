namespace tl2_tp09_2023_Julian_quin;
public interface ITareasRepository
{
    Tarea CrearTarea(int idTablero, Tarea tarea);
    void ModificarTarea(int id, Tarea tarea);
    Tarea TareaId(int id);
    List<Tarea> TareasDeUnUsuario(int idUsuario);
    void EliminarTarea(int idUsuario);
}