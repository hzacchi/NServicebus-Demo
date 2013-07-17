 
namespace Domain.Identities
{
    public sealed class RouteId : AbstractIdentity<long>
    {
        public const string TagValue = "route";

        public RouteId(long id)
        {
            Id = id;
        }

        public override string GetTag()
        {
            return TagValue;
        }

        public override long Id { get; set; }

        public RouteId() { }
    }
}