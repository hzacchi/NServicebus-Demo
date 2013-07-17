 
namespace Domain.Identities
{
    public sealed class RouteStepId : AbstractIdentity<long>
    {
        public const string TagValue = "routestep";

        public RouteStepId(long id)
        {
            Id = id;
        }

        public override string GetTag()
        {
            return TagValue;
        }

        public override long Id { get; set; }

        public RouteStepId() { }
    }
}