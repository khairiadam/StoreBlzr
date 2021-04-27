using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Http;
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
        //private readonly ITypeCrud<Product> _iTypeCrud;

        private readonly IProductService _iProductService;

        public ProductsController(IProductService iProductService)
        {
            _iProductService = iProductService;
        }


        [HttpGet("products")]
        public async Task<IActionResult> Get()
        {


            return Ok(await _iProductService.GetAll());




        }

        [HttpGet("GetProduct/{Id}")]
        public async Task<IActionResult> Getproduct(string id)
        {
          var result =  await _iProductService.Get(id);

            if (result == null)
            {
                return NotFound();
            }


            return Ok(result);



        }


        [HttpPost("Post")]

        public async Task<IActionResult> Post( [FromBody] Product model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }

            await _iProductService.Post(model);
          

            return Ok(model);



        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {

            if (ModelState.IsValid)
            {
                await _iProductService.Delete(id);
            }


            else
            {
                return BadRequest();

            }



            return NoContent();





        }






        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put(string id,Product product)
        {
            //if (id != product.Id)
            //{
            //    return BadRequest();
            //}

            await _iProductService.Update(product);
            return Ok(product);
        }


    }
}
