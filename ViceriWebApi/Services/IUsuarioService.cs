using ViceriWebApi.Models;

namespace ViceriWebApi.Services
{
    public interface IUsuarioService
    {
        Usuario GetById(Guid id);
        IEnumerable<Usuario> GetAll();
        Usuario Add(Usuario usuario);
        Usuario Edit(Usuario usuario);
        void Delete(Guid id);
    }
}
