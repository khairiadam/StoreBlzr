using System;
using System.Collections.Generic;

namespace Shared
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public Double Price { get; set; }
        public Category ProductCategory { get; set; }
        public List<Images> ProductImages { get; set; }

    }

}