using System;
using System.Collections.Generic;

namespace Messages
{
    public class State
    {
        public static string FilePath = @"c:\test\state2.json";

        public IDictionary<int, IList<Guid>> InQueue { get; set; }
        public IDictionary<int, Guid> InProcess { get; set; } 
 
        public State()
        {
            InQueue = new Dictionary<int, IList<Guid>>();
            InProcess = new Dictionary<int, Guid>();
        }
    }
}