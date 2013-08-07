using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class WipItem
    {
        public Guid Id { get; set; }
        public string Station { get; set; }
        public bool IsComplete { get; set; }
    }
}
