using Entrevista.Infra.Contexto;
using Entrvista.Dominio;
using Entrvista.Dominio.Repositorio;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Entrevista.Infra.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private EntrevistaContextoDeDados _contexto;
        public UsuarioRepositorio(EntrevistaContextoDeDados contexto)
        {
            _contexto = contexto;
        }
        public Usuario Buscar(string cpf)
        {
            return _contexto.Usuarios.Where(x => x.CPF == cpf).FirstOrDefault();
        }

        public IList<Usuario> Buscar()
        {
            try
            {
                return _contexto.Usuarios.ToList();
            }
            catch (System.Exception e)
            {

                throw(e);
            }
            
        }

        public void Deletar(int id)
        {
            _contexto.Usuarios.Remove(_contexto.Usuarios.Find(id));
        }

        public void Salvar(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            _contexto.Entry<Usuario>(usuario).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public bool CpfExiste(string cpf)
        {
            return _contexto.Usuarios.Any(x => x.CPF == cpf);
        }

        
    }
}
