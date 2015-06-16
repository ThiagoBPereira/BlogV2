using System;
using System.Collections.Generic;
using System.Linq;
using TBP.Blog.Dominio.Entidades;
using TBP.Blog.Dominio.Interfaces.Repositorio;

namespace TBP.Blog.Infra.Data.Repositorios
{
    public class ComentarioRepositorio : BaseRepositorio<Comentario>, IComentarioRepositorio
    {
        public IEnumerable<Comentario> ListAllByPost(Guid idPost)
        {
            return DbSet.Where(i => i.IdPost == idPost);
        }
    }
}