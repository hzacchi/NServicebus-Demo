using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Contracts.Wip.Commands;

namespace Web.Api
{
    public class WipController : ApiController
    {
        public Guid Post()
        {
            var id = Guid.NewGuid();
            MvcApplication.Bus.Send(new ReleaseWip { WipId = id });
            return id;
        }
        
    }
}