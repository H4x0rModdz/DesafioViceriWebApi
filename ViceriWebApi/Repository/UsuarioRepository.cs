using ViceriWebApi.Data;
using ViceriWebApi.Models;

namespace ViceriWebApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IAppDbContext _context;

        public UsuarioRepository(IAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetById(Guid id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Edit(Usuario usuario)
        {
            var usuarioEncontrado = GetById(usuario.Id);

            usuarioEncontrado.Nome = usuario.Nome;
            usuarioEncontrado.Senha = usuario.Senha;
            usuarioEncontrado.Email = usuario.Email;
            usuarioEncontrado.CPF = usuario.CPF;
            usuarioEncontrado.DataNascimento = usuario.DataNascimento;

            _context.Usuarios.Update(usuarioEncontrado);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var usuario = GetById(id);

            if (usuario == null)
                throw new ArgumentException($"O Usuário não foi encontrado");

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public bool EhCpfJaCadastrado(Usuario usuario)
        {
            var usuarios = _context.Usuarios.Where(u => u.CPF == usuario.CPF).ToList();

            if (usuarios.Count == 0)
                return false;

            var ehProprioUsuario = usuarios.Where(u => u.Id == usuario.Id).FirstOrDefault() != null;

            if (ehProprioUsuario)
                return false;

            return true;
        }

        public bool EhEmailJaCadastrado(Usuario usuario)
        {
            var usuarios = _context.Usuarios.Where(s => s.Email == usuario.Email).ToList();

            if (usuarios.Count == 0)
                return false;

            var ehProprioUsuario = usuarios.Where(u => u.Id == usuario.Id).FirstOrDefault() != null;

            if (usuarios.Count == 0 || ehProprioUsuario)
                return false;

            return true;
        }

        public bool EhVerificaSeUsuarioExiste(Guid id)
        {
            var verificarIdNoBanco = _context.Usuarios.Where(s => s.Id == id).ToList();

            if (verificarIdNoBanco.Count > 1)
                return true;

            return false;
        }
    }
}
