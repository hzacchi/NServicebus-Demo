namespace Domain.Identities
{
    public sealed class WipId : AbstractIdentity<long>
    {
        public const string TagValue = "wip";

        public WipId(long id)
        {
            Id = id;
        }

        public override string GetTag()
        {
            return TagValue;
        }

        public override long Id { get; protected set; }

        public WipId() { }
    }
}