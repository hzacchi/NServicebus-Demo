 
namespace Domain.Identities
{
    public sealed class CustomerId : AbstractIdentity<long>
    {
        public const string TagValue = "customer";

        public CustomerId(long id)
        {
            Id = id;
        }

        public override string GetTag()
        {
            return TagValue;
        }

        public override long Id { get; set; }

        public CustomerId() { }
    }
}