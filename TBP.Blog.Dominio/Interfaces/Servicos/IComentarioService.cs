using System;
using System.Collections.Generic;
using TBP.Blog.Dominio.Entidades;

namespace TBP.Blog.Dominio.Interfaces.Servicos
{
    public interface IComentarioService : IBaseService<Comentario>
    {
        IEnumerable<Comentario> ListAllByPost(Guid idPost);
    }
}