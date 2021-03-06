﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TBP.Blog.Aplicacao.ViewModels
{
    public class TagViewModel
    {
        public TagViewModel()
        {
            IdTag = Guid.NewGuid();
            Posts = new List<PostViewModel>();
        }

        public Guid IdTag { get; set; }

        [Required]
        [MinLength(3)]
        public string Nome { get; set; }
        public string UserId { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}