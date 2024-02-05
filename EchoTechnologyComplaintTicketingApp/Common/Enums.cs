using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoTechnologyComplaintTicketingApp.Common
{
    public class Enums
    {
        public enum ComplaintStatus
        {
            UnderProcessing = 1,
            Complete = 2
        }
        public enum DemandStatus
        {

            UnderProcessing = 1,
            REJECTED = 2,
            ACCEPTED = 3

        }
    }
}
