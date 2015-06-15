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
            Tags = new List<TagViewModel>();
            Comentarios = new List<ComentarioViewModel>();
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
            get { return (Corpo.Substring(0, Corpo.Length >= 360 ? 360 : Corpo.Length) + "..."); }
        }
        public IEnumerable<TagViewModel> Tags { get; set; }
        public IEnumerable<ComentarioViewModel> Comentarios { get; set; }
    }
}
