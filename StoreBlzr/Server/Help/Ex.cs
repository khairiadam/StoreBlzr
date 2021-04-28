using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StoreBlzr.Shared;

namespace StoreBlzr.Server.Help
{
    public static class Ex
    {
        public static string Check(string oldString, string newString)
        {
            var result = string.IsNullOrEmpty(newString) ? oldString : newString;
            return result;
        }

        public async static Task<Object> AddImg(Object item, List<IFormFile> imgs)
        {
            foreach (var file in imgs)
            {
                MemoryStream ms = new();
                await file.CopyToAsync(ms);
                if (item is Category)
                {
                    ((Category)item).Image = ms.ToArray();
                }
                else if (item is Product)
                {
                    var images = new Images();
                    images.ProductImgId = ((Product)item).Id;

                    // ((Product)item).Image = ms.ToArray();
                }
            }
            return item;
        }
    }


}