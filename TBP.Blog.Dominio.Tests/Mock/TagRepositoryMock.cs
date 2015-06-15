using System;
using System.Collections.Generic;
using TBP.Blog.Dominio.Entidades;
using TBP.Blog.Dominio.Interfaces.Repositorio;

namespace TBP.Blog.Dominio.Tests.Mock
{
    /// <summary>
    /// Classe de mock para evitar que testes "batam" no banco
    /// </summary>
    public class TagRepositoryMock : ITagRepositorio
    {
        public void Create(Tag obj)
        {
            throw new NotImplementedException();
        }
        public Tag Details(Guid id)
        {
            throw new NotImplementedException();
        }
        public void Edit(Tag obj)
        {
            throw new NotImplementedException();
        }
        public void Delete(Tag obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> ListAllByUser(string username)
        {
            var local = "userTeste";

            return new List<Tag>()
            {
                new Tag
                {
                    IdTag = Guid.NewGuid(),
                    Nome = "Teste",
                    UserId = local
                },
                new Tag()
                {
                    IdTag = Guid.NewGuid(),
                    Nome = "Testando",
                    UserId = local
                },
                new Tag()
                {
                    IdTag = Guid.NewGuid(),
                    Nome = "Mocagem",
                    UserId = local
                },
                new Tag()
                {
                    IdTag = Guid.NewGuid(),
                    Nome = "categoria",
                    UserId = local
                }
            };
        }
        public IEnumerable<Tag> GetByName(string username, string nome)
        {
            throw new NotImplementedException();
        }
    }
}
