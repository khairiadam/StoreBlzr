using System;

namespace Shared
{
    public class Order
    {
        public Guid Id { get; set; }
        public AppClient OrderClient { get; set; }
        public DateTime OrderDate { get; set; }
        public Status OrderStatus { get; set; }

    }

}