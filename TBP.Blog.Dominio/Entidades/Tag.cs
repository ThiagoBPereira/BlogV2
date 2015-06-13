using System;
using System.Collections.Generic;

namespace TBP.Blog.Dominio.Entidades
{
    public class Tag
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
    }
}