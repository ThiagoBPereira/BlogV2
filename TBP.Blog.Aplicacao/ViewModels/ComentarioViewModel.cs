using System;
using System.ComponentModel.DataAnnotations;

namespace TBP.Blog.Aplicacao.ViewModels
{
    public class ComentarioViewModel
    {
        public ComentarioViewModel()
        {
            IdComentario = Guid.NewGuid();
            DataComentario = DateTime.Now;
        }

        public Guid IdComentario { get; set; }

        [Required]
        [MinLength(3)]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataComentario { get; set; }
        public PostViewModel PostViewModel { get; set; }
        public Guid IdPost { get; set; }

    }
}
