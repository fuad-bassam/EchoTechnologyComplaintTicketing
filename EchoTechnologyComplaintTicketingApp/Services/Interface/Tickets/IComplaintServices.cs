using EchoTechnologyComplaintTicketingApp.DTOS.Tickets;
using EchoTechnologyComplaintTicketingApp.Models.Generic;
using System.Threading.Tasks;

namespace EchoTechnologyComplaintTicketingApp.Services.Repository.Tickets
{
    public interface IComplaintServices
    {
        Task<int> CreateComplaint(ComplaintDto complaintDto);
        Task<bool> DeleteComplaint(int id);
        Task<ComplaintDto> GetComplaintById(int id);
        Task<Page<ComplaintDto>> GetComplaintbyUser(PageInfo<ComplaintDto> page);
        Task<bool> UpdateComplaint(ComplaintDto complaintDto);
    }
}