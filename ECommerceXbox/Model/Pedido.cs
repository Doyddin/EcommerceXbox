using System.ComponentModel.DataAnnotations;

namespace ECommerceXbox.Model
{
    public class Pedido
    {
        [Key]
        public int Id {  get; set; }
        public string Endereco { get; set; }
        public int IdProduto { get; set; }
        public DateTime Data { get; set; }

        public Pedido(int idProduto, string endereco)
        {
            Data =  DateTime.Today;
            IdProduto = idProduto;
            Endereco = endereco;
        }
    }
}
