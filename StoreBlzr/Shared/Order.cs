using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StoreBlzr.Shared
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public string Id { get; set; }
        public AppClient OrderClient { get; set; }
        public DateTime OrderDate { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }
        public Status OrderStatus { get; set; }
        public Order()
        {
            this.CreationDate = DateTime.Now;
        }
    }

}