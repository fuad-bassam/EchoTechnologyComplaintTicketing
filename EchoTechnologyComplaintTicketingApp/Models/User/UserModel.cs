using EchoTechnologyComplaintTicketingApp.Models.Tickets;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EchoTechnologyComplaintTicketingApp.Models.User
{
    public class UserModel: IdentityUser
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }

        //Improvement Fuad - can convert it to table of Privilege or useing IdentityUserRole in the future 
        public bool IsAdminPrivilege { get; set; }


        public ICollection<ComplaintModel> Complaints { get; set; }
    }
}
