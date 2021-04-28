using System;
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
using StoreBlzr.Server.Help;
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
            //var getItems = (Category)_db.Categories.OrderBy(i => i.Id);
            ////var getItems = await _db.Categories.ToListAsync();
            //string img = Convert.ToBase64String(getItems.Image);
            //string imageDataURL = string.Format("data:image/jpg;base64,{0}", img);
            ////var results = new Category()
            ////{
            ////    Id = getItems.Id,
            ////    Description = getItems.Description,
            ////    Name = getItems.Name,
            ////    Image = imageDataURL;
            ////}
            //return imageDataURL.ToList();
        }

        public async Task<Category> Post(Category category, List<IFormFile> image)
        {
            // foreach (var file in image)
            // {
            //     MemoryStream ms = new();
            //     await file.CopyToAsync(ms);
            //     category.Image = ms.ToArray();
            // }

            await Ex.AddImg(category, image);
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            //MemoryStream ms = new();
            //await image.CopyToAsync(ms);
            //category.Image = ms.ToArray();

            //_db.Categories.Add(category);
            //await _db.SaveChangesAsync();
            return category;
        }

        public async Task Put(Category category, List<IFormFile> image)
        {
            //MemoryStream ms = new();
            //await image.CopyToAsync(ms);
            //category.Image = ms.ToArray();

            foreach (var file in image)
            {
                MemoryStream ms = new();
                await file.CopyToAsync(ms);
                category.Image = ms.ToArray();
                _db.Categories.Update(category);
                await _db.SaveChangesAsync();
            }


            //_db.Entry(category).State = EntityState.Modified;
            //await _db.SaveChangesAsync();
        }

    }
}