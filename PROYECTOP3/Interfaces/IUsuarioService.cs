using PROYECTOP3.Models;

namespace PROYECTOP3.Interfaces
{
    public interface IUsuarioService
    {
        List<Usuario> ObtenerUsuarios();
        Usuario? ObtenerPorId(int id);
        Usuario Crear(Usuario usuario);
        Usuario? Actualizar(int id, Usuario usuario);
        bool Eliminar(int id);
    }


}
