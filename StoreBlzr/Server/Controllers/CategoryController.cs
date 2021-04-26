using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreBlzr.Server.Services.Categories;
using StoreBlzr.Shared;
using Server.Services;
using System.IO;

namespace StoreBlzr.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ITypeCrud<Category> _category;

        public CategoryController(ITypeCrud<Category> category)
        {
            _category = category;
        }

        [HttpGet("Categories")]
        public async Task<List<Category>> GetCategories()
        {
           return await _category.GetAll();
        }

        [HttpGet("GetCategory")]
        public async Task<Category> GetCategory(string id)
        {
            var cat = await _category.Get(id);
            return cat;
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategories([FromForm] Category category)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            

            await _category.Post(category);
            return Ok(category);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
             await _category.Delete(id);
             return NoContent();
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> Edit(string id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            await _category.Put(category);
            return Ok(category);
        }
    }
}
