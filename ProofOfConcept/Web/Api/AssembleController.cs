using System;
using System.Web.Http;
using Contracts.Assemble.Commands;

namespace Web.Api
{
    public class AssembleController : ApiController
    {
        public void Post(Guid id)
        {
            var pass = (DateTime.Now.Ticks%3) > 0;

            if (pass)
            {
                MvcApplication.Bus.Send(new PassAssemble { WipId = id });
            }
            else
            {
                MvcApplication.Bus.Send(new FailAssemble { WipId = id });
            }
        }
    }
}