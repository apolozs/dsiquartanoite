using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/produto")]

    public class ProdutoController : ControllerBase
    {

        private readonly DataContext _context;

        //Contrutor
        public ProdutoController(DataContext context) => _context = context;

        //POST: /api/produto/create
        [HttpPost]
        [Route("create")]
        public Produto Create(Produto produto)
        {

            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        //GET: /api/produto/list
        [HttpGet]
        [Route("list")]
        public List<Produto> list() => _context.Produtos.ToList();


        //get /api/produto/getid/id

        [HttpGet]
        [Route("getid/{id}")]
        //public Produto getid(int id) => _context.Produtos.Find(id);
        public IActionResult getid([FromRoute] int id)
        {
            Produto produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }
    }
}