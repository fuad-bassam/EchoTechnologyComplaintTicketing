using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EchoTechnologyComplaintTicketingApp.DTOS.User;
using EchoTechnologyComplaintTicketingApp.Models.User;
using static EchoTechnologyComplaintTicketingApp.Common.Enums;

namespace EchoTechnologyComplaintTicketingApp.DTOS.Tickets
{
    public class ComplaintDto
    {
        public int ComplaintId { get; set; }
        [Required(ErrorMessage = "the Text is Required")]
        public string Text { get; set; }
        public List<DemandDto> Demands { get; set; }
        public string AttachmentPath { get; set; }
        //public UserDto UserDto { get; set; }
        public DateTime ComplaintDate { get; set; }
        public string UserId { get; set; }
        public ComplaintStatus Status { get; set; }


    }
}
