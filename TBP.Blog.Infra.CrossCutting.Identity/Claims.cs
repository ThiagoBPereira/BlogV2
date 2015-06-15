using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TBP.Blog.Infra.CrossCutting.Identity
{
    /// <summary>
    /// Utilizado para substituir as Roles - Padrão do vNext
    /// Fazer acesso as páginas ser mais dinamico, sem a necessidade de refatoração de código
    ///  quando é necessário um novo tipo de acesso ao controle
    /// </summary>
    [Table("AspNetClaims")]
    public class Claims
    {
        public Claims()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Fornceça um nome para a Claim")]
        [MaxLength(128, ErrorMessage = "Tamanho máximo {0} excedido")]
        [Display(Name = "Nome da Claim")]
        public string Name { get; set; }
    }
}
