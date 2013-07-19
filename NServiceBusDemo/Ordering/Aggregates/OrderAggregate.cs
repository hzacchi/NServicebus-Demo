using System;
using System.Collections.Generic;
using Domain.Identities;
using Messages.V1.Ordering;
using NServiceBus;
using Ordering.Domain;

namespace Ordering.Aggregates
{
    public class CustomerOrderAggregate : 
        IHandleMessages<OrderCreated>
    {
        public void Handle(OrderCreated message)
        {
            Console.WriteLine("Receieved event with Id {0}.", message.EventId);
        }
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