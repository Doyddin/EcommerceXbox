using ECommerceXbox.Context;
using ECommerceXbox.DTO;
using ECommerceXbox.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceXbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CategoriaController()
        {
            _dataContext = new DataContext();
        }


        // GET: api/<CategoriaController>
        [HttpGet]
        public ActionResult<List<Categoria>> Get()
        {
            var categorias = _dataContext.Categoria.ToList();

            return categorias;
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _dataContext.Categoria.Find(id).Nome;
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public ActionResult<Categoria> Post([FromBody] CategoriaRequest categoriaRequest)
        {
            if (ModelState.IsValid)
            {
                var categoria = categoriaRequest.toModel();
                _dataContext.Categoria.Add(categoria);
                _dataContext.SaveChanges();
                return categoria;
            }

            return BadRequest(ModelState);
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
