namespace tl2_tp09_2023_Julian_quin;
public interface IUsuarioRepository
{
    List<Usuario> Usuarios();
    void NuevoUsuario (Usuario usuario);
    bool ActualizarUsuario(Usuario usuario, int id);
    Usuario UsuarioViaId(int id);
    bool EliminarUsuario(int id);

}