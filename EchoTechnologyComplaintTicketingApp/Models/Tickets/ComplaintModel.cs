using EchoTechnologyComplaintTicketing.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EchoTechnologyComplaintTicketingApp.Models.User;
using static EchoTechnologyComplaintTicketingApp.Common.Enums;

namespace EchoTechnologyComplaintTicketingApp.Models.Tickets
{
    public class ComplaintModel
    {
        [Key]
        public int ComplaintId { get; set; }
        public string Text { get; set; }
        public List<DemandModel> Demands { get; set; }
        public string AttachmentPath { get; set; }
        public UserModel User { get; set; }
        public DateTime ComplaintDate { get; set; }
        public ComplaintStatus Status { get; set; }

        public string UserId { get; set; }
    }
}
