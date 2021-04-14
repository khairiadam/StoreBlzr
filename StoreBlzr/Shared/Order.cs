using System;

namespace Shared
{
    public class Order
    {
        public Guid Id { get; set; }
        public ClientModel OrderClient { get; set; }
        public DateTime OrderDate { get; set; }
        public Status OrderStatus { get; set; }

    }

}