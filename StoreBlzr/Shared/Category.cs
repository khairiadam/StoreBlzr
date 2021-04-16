using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Shared
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}