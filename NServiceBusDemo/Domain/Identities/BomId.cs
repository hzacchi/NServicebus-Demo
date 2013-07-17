namespace Domain.Identities
{
    public sealed class BomId : AbstractIdentity<long>
    {
        public const string TagValue = "bom";

        public BomId(long id)
        {
            Id = id;
        }

        public override string GetTag()
        {
            return TagValue;
        }

        public override long Id { get; set; }

        public BomId() { }
    }
}