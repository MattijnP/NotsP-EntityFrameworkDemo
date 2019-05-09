using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotsP_EntityFrameworkDemo.Entities;
using NotsP_EntityFrameworkDemo.Repositories;

namespace NotsP_EntityFrameworkDemo.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Products> repository;

        public ProductController(IRepository<Products> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = repository.GetById(id);

            if (product == null)
            {
                return NotFound("Het product was niet gevonden");
            }

            return Ok(product);
        }

    }
}
