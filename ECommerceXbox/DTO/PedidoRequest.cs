using ECommerceXbox.Model;
using System.ComponentModel.DataAnnotations;

namespace ECommerceXbox.DTO
{
    public class PedidoRequest
    {
        [Required]
        public int IdProduto { get; set; }
        [Required]
        public string Endereco { get; set; }

        public Pedido toModel() => new Pedido(IdProduto, Endereco);

    }
}
