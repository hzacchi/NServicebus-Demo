using System;
using System.Web.Http;
using Contracts.Assemble.Commands;

namespace Web.Api
{
    public class AssembleController : ApiController
    { 
        public void Post(Guid id)
        {
            MvcApplication.Bus.Send(new StartAssemble { WipId = id });
        }
    }
}