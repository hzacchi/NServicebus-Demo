 
namespace Domain.Identities
{
    public sealed class ResourceId : AbstractIdentity<long>
    {
        public const string TagValue = "resource";

        public ResourceId(long id)
        {
            Id = id;
        }

        public override string GetTag()
        {
            return TagValue;
        }

        public override long Id { get; set; }

        public ResourceId() { }
    }
}