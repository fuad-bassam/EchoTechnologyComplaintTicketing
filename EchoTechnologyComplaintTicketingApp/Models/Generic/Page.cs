using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoTechnologyComplaintTicketingApp.Models.Generic
{
    public class Page<T>
    {
        public int totalElements { set; get; }
        public List<T> content { set; get; }
    
    }
}
