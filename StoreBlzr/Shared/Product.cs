using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public string Id { get; set; }
       [Required(ErrorMessage = "Product name is required")]  public string Name { get; set; }
       [Required(ErrorMessage = "ShortDescription is required")] public string ShortDescription { get; set; }
        [Required(ErrorMessage = "LongDescription is required")]  public string LongDescription { get; set; }
        [Required(ErrorMessage = "Quantity is required")]  public int Quantity { get; set; }
        [Required(ErrorMessage = "Color is required")]  public string Color { get; set; }
        [Required(ErrorMessage = "Price is required")]  public Double Price { get; set; }
        public Category ProductCategory { get; set; }

        [JsonIgnore]
        public List<Images> ProductImages { get; set; }

    }

}