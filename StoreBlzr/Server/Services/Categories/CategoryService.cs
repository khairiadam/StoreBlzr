using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Server.Services;
using StoreBlzr.Server.Data;
using StoreBlzr.Shared;

namespace StoreBlzr.Server.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly StoreDbContext _db;
        public CategoryService(StoreDbContext db)
        {
            _db = db;
        }
        //TODO Each one of the group should implement one Method
        public async Task Delete(string id)
        {
            var delCategory = await _db.Categories.FindAsync(id);
            _db.Categories.Remove(delCategory);
            await _db.SaveChangesAsync();
        }

        public async Task<Category> Get(string id)
        {
            var find = await _db.Categories.FindAsync(id);
            return find;
        }

        public async Task<List<Category>> GetAll()
        {
           return await _db.Categories.ToListAsync();
           
        }

        public async Task<Category> Post(Category category)
        {
            byte[] x = await File.ReadAllBytesAsync(category.Image.ToString());
            category.Image = x.OfType<byte>().ToArray();
            //List<IFormFile> uploadFile = new();
            //foreach (var file in uploadFile)
            //{
            //    MemoryStream ms = new();
            //    await file.CopyToAsync(ms);
            //    category.Image = ms.ToArray();
            //}
            
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task Put(Category category)
        {
            _db.Entry(category).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

    }
}