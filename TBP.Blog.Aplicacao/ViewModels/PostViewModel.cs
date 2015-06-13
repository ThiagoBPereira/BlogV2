using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TBP.Blog.Aplicacao.ViewModels
{
    public class PostViewModel
    {
        public PostViewModel()
        {
            IdPost = Guid.NewGuid();
            DataPostagem = DateTime.Now;
        }

        public Guid IdPost { get; set; }
        public string UserId { get; set; }
        [Required]
        [MinLength(3)]
        public string Titulo { get; set; }
        [Required]
        [MinLength(3)]
        public string Corpo { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DataPostagem { get; set; }

        public string CorpoDiminuido
        {
            get { return (Corpo.Substring(0, Corpo.Length >= 15 ? 15 : Corpo.Length) + "..."); }
        }
        public virtual IEnumerable<TagViewModel> Tags { get; set; }
        public virtual IEnumerable<ComentarioViewModel> Comentarios { get; set; }
    }
}
