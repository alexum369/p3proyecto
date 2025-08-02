using Newtonsoft.Json;
using PROYECTOP3.Interfaces;
using PROYECTOP3.Models;

namespace PROYECTOP3.Services
{
    public class UsuarioServiceClass
    {
        public class UsuarioService : IUsuarioService
        {
            private readonly string filePath = "usuarios.json";

            private List<Usuario> LeerUsuarios()
            {
                if (!File.Exists(filePath))
                    return new List<Usuario>();

                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Usuario>>(json) ?? new List<Usuario>();
            }

            private void GuardarUsuarios(List<Usuario> usuarios)
            {
                var json = JsonConvert.SerializeObject(usuarios, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }

            public List<Usuario> ObtenerUsuarios() => LeerUsuarios();

            public Usuario? ObtenerPorId(int id) =>
                LeerUsuarios().FirstOrDefault(u => u.Id == id);

            public Usuario Crear(Usuario usuario)
            {
                var usuarios = LeerUsuarios();
                usuario.Id = usuarios.Count > 0 ? usuarios.Max(u => u.Id) + 1 : 1;
                usuarios.Add(usuario);
                GuardarUsuarios(usuarios);
                return usuario;
            }

            public Usuario? Actualizar(int id, Usuario usuario)
            {
                var usuarios = LeerUsuarios();
                var index = usuarios.FindIndex(u => u.Id == id);
                if (index == -1) return null;

                usuario.Id = id;
                usuarios[index] = usuario;
                GuardarUsuarios(usuarios);
                return usuario;
            }

            public bool Eliminar(int id)
            {
                var usuarios = LeerUsuarios();
                var usuario = usuarios.FirstOrDefault(u => u.Id == id);
                if (usuario == null) return false;

                usuarios.Remove(usuario);
                GuardarUsuarios(usuarios);
                return true;
            }
        }
    }
}
