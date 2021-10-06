using System;
using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly DataContext _context;

        //Construtor
        public CategoriaController(DataContext context) => _context = context;

        //POST: api/categoria/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return Created("", categoria);
        }

        //GET: api/categoria/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.Categorias.ToList());

        //GET: api/categoria/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            //Buscar um categoria pela chave primária
            Categoria categoria = _context.Categorias.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        //DELETE: api/categoria/delete/
        [HttpDelete]
        [Route("delete/{name}")]
        public IActionResult Delete([FromRoute] string name)
        {
            //Expressão lambda
            //Buscar um categoria pelo nome
            Categoria categoria = _context.Categorias.FirstOrDefault
            (
                categoria => categoria.Nome == name
            );
            if (categoria == null)
            {
                return NotFound();
            }
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return Ok(_context.Categorias.ToList());
        }

        //PUT: api/categoria/create
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        }


    }
}