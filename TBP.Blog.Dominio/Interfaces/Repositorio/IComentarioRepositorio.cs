using System;
using System.Collections.Generic;
using TBP.Blog.Dominio.Entidades;

namespace TBP.Blog.Dominio.Interfaces.Repositorio
{
    public interface IComentarioRepositorio : IBaseRepositorio<Comentario>
    {
        IEnumerable<Comentario> ListAllByPost(Guid idPost);
    }
}