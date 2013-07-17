using Domain.Identities;

namespace Ordering.Domain
{
    public class ShopFloorOrder
    {
        public ShopFloorOrderId Id { get; set; }
        public WipId WipId { get; set; }
        public MaterialId MaterialId { get; set; }
        public BomId BomId { get; set; }
    }
}
