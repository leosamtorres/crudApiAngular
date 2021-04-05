using System;
using System.Collections.Generic;

namespace Entrvista.Dominio.Repositorio
{
    public interface IUsuarioRepositorio : IDisposable
    {
        Usuario Buscar(string cpf);

        IList<Usuario> Buscar();

        void Salvar(Usuario usuario);

        void Atualizar(Usuario usuario);

        void Deletar(int id);

        bool CpfExiste(string cpf);

    }
}
