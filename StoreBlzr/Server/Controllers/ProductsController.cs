using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Server.Services.Products;
using Shared;

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

           
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went Wrong");
            }


            return Ok(await _productService.Product(id));



        }


        [HttpPost("newProduct")]

        public async Task<IActionResult> CreateProduct([FromBody] Product model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went Wrong");
            }

            await _productService.CreateProduct(model);

            return Ok(model);



        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteProduct(string Id)
        {


       

            var result = await _productService.DeleteProduct(Id);

            if (result == null)
            {
                return BadRequest("Null Object");
            }


            return Ok(result);


        }


        [HttpPut("update/{Id}")]
        public async Task<IActionResult> Update(string Id, Product product)
        {


         

            var result = await _productService.UpdateProduct(Id, product);
            return Ok(result);




        }


    }
}
