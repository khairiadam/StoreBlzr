using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Shared;
using StoreBlzr.Server.Services.Products;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreBlzr.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }




        [HttpGet("products")]
        public async Task<IActionResult> Get()
        {


            return Ok(await _productService.GetProducts());




        }

        [HttpGet("GetProduct/{Id}")]
        public async Task<IActionResult> Getproduct(string id)
        {
          var result =  await _productService.Product(id);

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

            await _productService.CreateProduct(model);

            return Ok("Product Created successful");



        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteProduct(string Id)
        {


       

            var result = await _productService.DeleteProduct(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            return Ok(result);


        }


        [HttpPut("update/{Id}")]
        public async Task<IActionResult> Update(string Id, Product product)
        {

            
            var result = await _productService.UpdateProduct(Id, product);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);




        }


    }
}
