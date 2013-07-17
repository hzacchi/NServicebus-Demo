namespace Domain.Identities
{
    public sealed class ShopFloorOrderId : AbstractIdentity<long>
    {
        public const string TagValue = "shopfloororder";

        public ShopFloorOrderId(long id)
        {
            Id = id;
        }

        public override string GetTag()
        {
            return TagValue;
        }

        public override long Id { get; set; }

        public ShopFloorOrderId() { }
    }
}