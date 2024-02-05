using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static EchoTechnologyComplaintTicketingApp.Common.Enums;

namespace EchoTechnologyComplaintTicketingApp.Models.Tickets
{
    public class DemandModel
    {
        [Key]
        public int DemandId { get; set; }
        public string Description { get; set; }


        public int ComplaintId { get; set; }
        public ComplaintModel Complaint { get; set; }
        public DemandStatus Status { get; set; }

    }
}
