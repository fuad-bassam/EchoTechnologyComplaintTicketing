using EchoTechnologyComplaintTicketingApp.DTOS.Tickets;
using EchoTechnologyComplaintTicketingApp.Models.Generic;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoTechnologyComplaintTicketingApp.Common.refit
{
    public interface IComplaintApi
    {
        [Post("/api/Complaint/GetComplaintById/{id}")]
        Task<ComplaintDto> GetComplaintById(int id);

        [Post("/api/Complaint/CreateComplaint")]
        Task<int> CreateComplaint([Body] ComplaintDto complaintDto);

        [Post("/api/Complaint/UpdateComplaint/{id}")]
        Task<bool> UpdateComplaint(int id, [Body] ComplaintDto complaintDto);

        [Post("/api/Complaint/DeleteComplaint/{id}")]
        Task<bool> DeleteComplaint(int id);

        [Post("/api/Complaint/CreateUpdateComplaint")]
        Task<int> CreateUpdateComplaint([Body] ComplaintDto complaintDto, [Query] int? id = null);

        [Post("/api/Complaint/GetComplaintsByUser")]
        Task<Page<ComplaintDto>> GetComplaintsByUser([Body] PageInfo<ComplaintDto> page);
    }
}
