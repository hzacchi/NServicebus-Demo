using System.Collections.Generic;
using Domain.Identities;
using Ordering.Domain;

namespace Ordering.Aggregates
{
    public class CustomerOrderAggregate
    {

    } 

    public class CustomerOrderState
    {
        public CustomerOrderId Id { get; set; }
        public IList<ShopFloorOrder> ShopFloorOrders { get; set; }
        public string Status { get; set; }

        public CustomerOrderState()
        {
            ShopFloorOrders = new List<ShopFloorOrder>();
        }
    }
}