using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Images Image { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}