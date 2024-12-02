using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEvents
{
    public class KeyPointEvent
    {
        public string keyName { get; set; }
        public bool isInTime { get; set; }
    }

    public class GateEvent
    {
        public string gateName { get; set; }
        public string message { get; set; }
    }
}
