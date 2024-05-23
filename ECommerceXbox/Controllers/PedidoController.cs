using ECommerceXbox.Context;
using ECommerceXbox.DTO;
using ECommerceXbox.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceXbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public PedidoController()
        {
            _dataContext = new DataContext();
        }

        // GET: api/<PedidoController>
        [HttpGet]
        public ActionResult<List<Pedido>> Get()
        {
            return _dataContext.Pedido.ToList();
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public ActionResult<Pedido> Get(int id)
        {
            return _dataContext.Pedido.Find(id);
        }

        // POST api/<PedidoController>
        [HttpPost]
        public ActionResult<Pedido> Post([FromBody] PedidoRequest pedidoRequest)
        {
            if (ModelState.IsValid)
            {
                var pedido = pedidoRequest.toModel();
                _dataContext.Pedido.Add(pedido);
                _dataContext.SaveChanges();

                return pedido;
            }

            return BadRequest(ModelState);
        }

        // PUT api/<PedidoController>/5
        [HttpPut("{id}")]
        public ActionResult<Pedido> Put(int id, [FromBody] PedidoRequest pedidoRequest)
        {
            var pedido = _dataContext.Pedido.Find(id);
            if (pedido != null)
            {
                pedido.IdProduto = pedidoRequest.IdProduto;
                pedido.Endereco = pedidoRequest.Endereco;
                _dataContext.SaveChanges();

                return pedido;
            }

            return BadRequest("Id não encontrado");
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var pedido = _dataContext.Pedido.Find(id);
            if (pedido != null)
            {
                _dataContext.Pedido.Remove(pedido);
                _dataContext.SaveChanges();
            }
        }
    }
}
