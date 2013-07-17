 
namespace Domain.Identities
{
    public sealed class MaterialId : AbstractIdentity<long>
    {
        public const string TagValue = "material";

        public MaterialId(long id)
        {
            Id = id;
        }

        public override string GetTag()
        {
            return TagValue;
        }

        public override long Id { get; set; }

        public MaterialId() { }
    }
}