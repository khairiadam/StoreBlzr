using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Server.Services;
using Shared;
using StoreBlzr.Server.Services.Products;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreBlzr.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ITypeCrud<Product> _iTypeCrud;

        public ProductsController(ITypeCrud<Product> iTypeCrud)
        {
            _iTypeCrud = iTypeCrud;
        }


        [HttpGet("products")]
        public async Task<IActionResult> Get()
        {


            return Ok(await _iTypeCrud.GetAll());




        }

        [HttpGet("GetProduct/{Id}")]
        public async Task<IActionResult> Getproduct(string id)
        {
          var result =  await _iTypeCrud.Get(id);

            if (result == null)
            {
                return NotFound();
            }


            return Ok();



        }


        [HttpPost("newProduct")]

        public async Task<IActionResult> CreateProduct([FromBody] Product model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _iTypeCrud.Post(model);

            return Ok("Product Created successful");



        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteProduct(string Id)
        {

            if (ModelState.IsValid)
            {
                  var result =  _iTypeCrud.Delete(Id);
            }


            else
            {
                return BadRequest();

            }



            return NoContent();





        }


        [HttpPut("update/{Id}")]
        public async Task<IActionResult> Update(string Id, Product product)
        {

            
            var result =  _iTypeCrud.Put(product);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);




        }


    }
}
