using System;
using System.Collections.Generic;
using TBP.Blog.Dominio.Interfaces.Validation;
using TBP.Blog.Dominio.Validation.Post;
using TBP.Blog.Dominio.ValueObjects;

namespace TBP.Blog.Dominio.Entidades
{
    public class Post : ISelfValidator
    {
        public Post()
        {
            IdPost = Guid.NewGuid();
            Tags = new List<Tag>();
            Comentarios = new List<Comentario>();
        }

        public Guid IdPost { get; set; }
        public string UserId { get; set; }
        public string Titulo { get; set; }
        public string Corpo { get; set; }
        public DateTime DataPostagem { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }

        //Usado apenas para enviar Validações do Dominio para a camada de Apresentação
        public ValidationResult ResultadoValidacao { get; private set; }

        /// <summary>
        /// Método de verificação do ISpecification para parantir a integridade dos dados
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            var fiscal = new PostAptoParaCadastro();

            ResultadoValidacao = fiscal.Validar(this);

            return ResultadoValidacao.IsValid;
        }
    }
}
