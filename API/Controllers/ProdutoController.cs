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
        public IActionResult Create([FromBody] Produto produto)
        {

            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Created("", produto);
        }

        //GET: /api/produto/list
        [HttpGet]
        [Route("list")]
        public List<Produto> list() => _context.Produtos.ToList();


        //GET/api/produto/getid/id
        [HttpGet]
        [Route("getid/{id}")]
        //public Produto getid(int id) => _context.Produtos.Find(id);
        public IActionResult getid([FromRoute] int id)
        {
            //Buscar UM produto por id
            Produto produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        //GET/api/produto/delete/Batatinha
        [HttpDelete]
        [Route("delete/{name}")]
        public IActionResult delete([FromRoute] string name)
        {
            
            //Expressão lambda
            //Buscar UM produto pelo nome
            Produto produto = _context.Produtos.FirstOrDefault(produto => produto.Nome == name);
            if (produto == null)
            {
                return NotFound();
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok(_context.Produtos.ToList());
        }

    }
}