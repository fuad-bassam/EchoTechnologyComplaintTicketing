using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static EchoTechnologyComplaintTicketingApp.Common.Enums;

namespace EchoTechnologyComplaintTicketingApp.DTOS.Tickets
{
    public class DemandDto
    {
        public int DemandId { get; set; }
        public int ComplaintId { get; set; }

        [Required(ErrorMessage = "the Description is Required")]
        public string Description { get; set; }

        public DemandStatus Status { get; set; }

    }
}
