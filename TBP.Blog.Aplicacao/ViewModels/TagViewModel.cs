using System;
using System.ComponentModel.DataAnnotations;

namespace TBP.Blog.Aplicacao.ViewModels
{
    public class TagViewModel
    {
        public TagViewModel()
        {
            IdTag = Guid.NewGuid();
        }

        public Guid IdTag { get; set; }

        [Required]
        [MinLength(3)]
        public string Nome { get; set; }
        public string UserId { get; set; }
    }
}