using System;
using System.Collections.Generic;
using TBP.Blog.Dominio.Entidades;
using TBP.Blog.Dominio.Interfaces.Repositorio;
using TBP.Blog.Dominio.Interfaces.Servicos;
using TBP.Blog.Dominio.Validation.Tag;
using TBP.Blog.Dominio.ValueObjects;

namespace TBP.Blog.Dominio.Servicos
{
    public class TagService : ITagService
    {
        private readonly ITagRepositorio _repositorio;

        public TagService(ITagRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Tag> GetByName(string username, string nome)
        {
            return _repositorio.GetByName(username, nome);
        }

        public IEnumerable<Tag> ListAllByUser(string username)
        {
            return _repositorio.ListAllByUser(username);
        }

        public ValidationResult Create(Tag obj)
        {
            var resultado = new ValidationResult();

            if (!obj.IsValid())
            {
                resultado.AdicionarErro(obj.ResultadoValidacao);
            }

            //Verificar se é único no banco
            var fiscalUnico = new TagAptaParaCadastroValidation(_repositorio);
            var kk = fiscalUnico.Validar(obj);

            if (!kk.IsValid)
            {
                resultado.AdicionarErro(kk);
            }

            if (!resultado.IsValid)
            {
                return resultado;
            }

            _repositorio.Create(obj);

            return resultado;
        }

        public Tag Details(Guid id)
        {
            return _repositorio.Details(id);
        }

        public ValidationResult Edit(Tag obj)
        {
            var resultado = new ValidationResult();

            if (!obj.IsValid())
            {
                resultado.AdicionarErro(obj.ResultadoValidacao);
            }

            //Verificar se é único no banco
            var fiscalUnico = new TagAptaParaCadastroValidation(_repositorio);
            var kk = fiscalUnico.Validar(obj);

            if (!kk.IsValid)
            {
                resultado.AdicionarErro(kk);
            }

            if (!resultado.IsValid)
            {
                return resultado;
            }

            _repositorio.Edit(obj);

            return resultado;
        }

        public void Delete(Tag obj)
        {
            _repositorio.Delete(obj);
        }
    }
}
