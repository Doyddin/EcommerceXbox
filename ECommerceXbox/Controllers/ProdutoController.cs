using ECommerceXbox.Context;
using ECommerceXbox.DTO;
using ECommerceXbox.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceXbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProdutoController()
        {
            _dataContext = new DataContext();
        }


        // GET: api/<ProdutoController>
        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            var produto = _dataContext.Produto.ToList();

            return produto;
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _dataContext.Produto.Find(id).Nome;
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public ActionResult<Produto> Post([FromBody] ProdutoRequest produtoRequest)
        {
            if(ModelState.IsValid)
            {
                var produto = produtoRequest.toModel();
                _dataContext.Produto.Add(produto);
                _dataContext.SaveChanges();
                return produto;
            }
            return BadRequest(ModelState);
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public ActionResult<Produto> Put(int id, [FromBody] ProdutoRequest produtoRequest)
        {
            var produto = _dataContext.Produto.Find(id);

            if (produto != null)
            {
                produto.CategoriaId = produtoRequest.CategoriaId;
                produto.Nome = produtoRequest.Nome;
                _dataContext.SaveChanges();

                return produto;
            }

            return BadRequest("Id não existente");
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var produto = _dataContext.Produto.Find(id);
            _dataContext.Produto.Remove(produto);
        }
    }
}
