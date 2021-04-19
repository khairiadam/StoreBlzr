// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using StoreBlzr.Server.Data;
// using StoreBlzr.Shared;

// namespace StoreBlzr.Server.Services.Categories
// {
//     public class CategoryService : ICategoryService
//     {
//         private readonly StoreDbContext _db;
//         public CategoryService(StoreDbContext db)
//         {
//             _db = db;
//         }
//         //TODO Each one of the group should implement one Method
//         public async Task Delete(string id)
//         {
//             var delCategory = await _db.Categories.FindAsync(id);
//             _db.Categories.Remove(delCategory);
//             await _db.SaveChangesAsync();
//         }

//         public async Task<Category> Get(string categoryId)
//         {
//             var find = await _db.Categories.FindAsync(categoryId);
//             return find;
//         }

//         public async Task<List<Category>> GetAll()
//         {
//            return await _db.Categories.ToListAsync();
//         }

//         public async Task<Category> Post(Category category)
//         {
//             _db.Categories.Add(category);
//             await _db.SaveChangesAsync();
//             return category;
//         }

//         public async Task Put(Category category)
//         {
//             _db.Entry(category).State = EntityState.Modified;
//             await _db.SaveChangesAsync();
//         }

//     }
// }