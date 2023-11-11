namespace TP_BaseDeDatosWebApi;
public interface IUsuarioRepository
{
    List<Usuario> Usuarios();
    void NuevoUsuario (Usuario usuario);
    void ActualizarUsuario(Usuario usuario, int id);
    Usuario UsuarioViaId(int id);
    void EliminarUsuario(int id);

}