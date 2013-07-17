namespace Domain.Identities
{
    public sealed class CustomerOrderId : AbstractIdentity<long>
    {
        public const string TagValue = "customerorder";

        public CustomerOrderId(long id)
        {
            Id = id;
        }

        public override string GetTag()
        {
            return TagValue;
        }

        public override long Id { get; set; }

        public CustomerOrderId() { }
    }
}