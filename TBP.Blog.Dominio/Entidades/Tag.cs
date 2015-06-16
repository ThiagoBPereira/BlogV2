using System;
using System.Collections.Generic;
using System.Linq;
using TBP.Blog.Dominio.Interfaces.Specification;
using TBP.Blog.Dominio.Interfaces.Validation;
using TBP.Blog.Dominio.Validation.Tag;
using TBP.Blog.Dominio.ValueObjects;

namespace TBP.Blog.Dominio.Entidades
{
    public class Tag : ISelfValidator
    {
        public Tag()
        {
            IdTag = Guid.NewGuid();
            Posts = new List<Post>();
        }

        public Guid IdTag { get; set; }
        public string UserId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public ValidationResult ResultadoValidacao { get; private set; }

        public bool IsValid()
        {
            var validar = new TagDevidamentePreenchidaValidation();

            ResultadoValidacao = validar.Validar(this);

            return ResultadoValidacao.IsValid;
        }
    }
}