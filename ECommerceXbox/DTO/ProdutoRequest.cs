using ECommerceXbox.Model;
using System.ComponentModel.DataAnnotations;

namespace ECommerceXbox.DTO
{
    public class ProdutoRequest
    {

        [MinLength(5)]
        public string Nome { get; set; }

        [Required]
        public int CategoriaId { get; set; }
        public Produto toModel() => new Produto(Nome, CategoriaId);
    }
}
