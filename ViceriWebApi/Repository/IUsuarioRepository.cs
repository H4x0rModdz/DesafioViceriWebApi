using ViceriWebApi.Models;

namespace ViceriWebApi.Repository
{
    public interface IUsuarioRepository
    {
        Usuario GetById(Guid id);

        IEnumerable<Usuario> GetAll();

        void Add(Usuario user);

        void Edit(Usuario user);

        void Delete(Guid id);

        bool EhEmailJaCadastrado(Usuario usuario);

        bool EhCpfJaCadastrado(Usuario usuario);

        bool EhVerificaSeUsuarioExiste(Guid id);
    }
}
