namespace TP_BaseDeDatosWebApi;
public interface ITableroRepository
{
    Tablero NuevoTablero(Tablero tablero);
    void ModificarTablero(Tablero tablero, int id);
    Tablero TableroViaId(int id);
    List<Tablero> Tableros();
    List<Tablero> TablerosDeUnUsuario(int idUsuario);
    void EliminarTablero(int id);
}