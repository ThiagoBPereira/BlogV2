using System;
using System.Collections.Generic;
using TBP.Blog.Dominio.Entidades;
using TBP.Blog.Dominio.Interfaces.Repositorio;
using TBP.Blog.Dominio.Interfaces.Servicos;
using TBP.Blog.Dominio.ValueObjects;

namespace TBP.Blog.Dominio.Servicos
{
    public class ComentarioService : IComentarioService
    {
        private readonly IComentarioRepositorio _repositorio;

        public ComentarioService(IComentarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ValidationResult Create(Comentario obj)
        {
            var resultado = new ValidationResult();

            if (!obj.IsValid())
            {
                resultado.AdicionarErro(obj.ResultadoValidacao);
            }

            return resultado;
        }

        public Comentario Details(Guid id)
        {
            return _repositorio.Details(id);
        }

        public ValidationResult Edit(Comentario obj)
        {
            var resultado = new ValidationResult();

            if (!obj.IsValid())
            {
                resultado.AdicionarErro(obj.ResultadoValidacao);
            }

            return resultado;
        }

        public void Delete(Comentario obj)
        {
            _repositorio.Delete(obj);
        }

        public IEnumerable<Comentario> ListAllByPost(Guid idPost)
        {
            return _repositorio.ListAllByPost(idPost);
        }
    }
}