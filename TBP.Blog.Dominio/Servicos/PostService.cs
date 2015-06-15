using System;
using System.Collections.Generic;
using TBP.Blog.Dominio.Entidades;
using TBP.Blog.Dominio.Interfaces.Repositorio;
using TBP.Blog.Dominio.Interfaces.Servicos;
using TBP.Blog.Dominio.ValueObjects;

namespace TBP.Blog.Dominio.Servicos
{
    public class PostService : IPostService
    {
        private readonly IPostRepositorio _repositorio;

        public PostService(IPostRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Post> ListAllByUser(string username, int indexPagina, int qtddPorPagina)
        {
            return _repositorio.ListAllByUser(username, indexPagina, qtddPorPagina);
        }

        public IEnumerable<Post> GetByTagName(string username, string tag, int indexPagina, int qtddPorPagina)
        {
            return _repositorio.GetByTagName(username, tag, indexPagina, qtddPorPagina);
        }

        public int ObterTotalRegistros(string username)
        {
            return _repositorio.ObterTotalRegistros(username);
        }

        public int ObterTotalRegistrosByTag(string username, string tag)
        {
            return _repositorio.ObterTotalRegistrosByTag(username, tag);

        }

        public ValidationResult Create(Post obj)
        {
            var resultado = new ValidationResult();

            //Verificar se os dados estão corretamente preenchidos
            if (!obj.IsValid())
            {
                resultado.AdicionarErro(obj.ResultadoValidacao);
                return resultado;
            }

            _repositorio.Create(obj);

            return resultado;
        }

        public Post Details(Guid id)
        {
            return _repositorio.Details(id);
        }

        public ValidationResult Edit(Post obj)
        {
            var resultado = new ValidationResult();

            //Verificar se os dados estão corretamente preenchidos
            if (!obj.IsValid())
            {
                resultado.AdicionarErro(obj.ResultadoValidacao);
                return resultado;
            }

            _repositorio.Edit(obj);

            return resultado;
        }

        public void Delete(Post obj)
        {
            _repositorio.Delete(obj);
        }
    }
}