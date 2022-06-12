using ViceriWebApi.Models;
using ViceriWebApi.Repository;

namespace ViceriWebApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepository.GetAll();
        }

        public Usuario GetById(Guid id)
        {
            if (_usuarioRepository.EhVerificaSeUsuarioExiste(id))
                throw new ArgumentException("Id de Usuário não existe");

            return _usuarioRepository.GetById(id);
        }

        public Usuario Add(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();

            if (usuario.Senha is null)
                throw new ArgumentException("O campo da Senha é obrigatório");

            if (_usuarioRepository.EhEmailJaCadastrado(usuario))
                throw new ArgumentException("Email de Usuário já existe");

            if (_usuarioRepository.EhCpfJaCadastrado(usuario))
                throw new ArgumentException("CPF já existe");

            usuario.DataNascimento = usuario.DataNascimento.Date;

            _usuarioRepository.Add(usuario);

            return usuario;
        }

        public Usuario Edit(Usuario usuario)
        {
            if (_usuarioRepository.EhEmailJaCadastrado(usuario))
                throw new ArgumentException("Email de Usuário já existe");

            if (_usuarioRepository.EhCpfJaCadastrado(usuario))
                throw new ArgumentException("CPF já existe");

            _usuarioRepository.Edit(usuario);

            return usuario;
        }

        public void Delete(Guid id)
        {
            _usuarioRepository.Delete(id);
        }
    }
}