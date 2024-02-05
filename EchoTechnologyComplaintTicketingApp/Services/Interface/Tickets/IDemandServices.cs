using EchoTechnologyComplaintTicketingApp.DTOS.Tickets;
using EchoTechnologyComplaintTicketingApp.Models.Generic;
using System.Threading.Tasks;

namespace EchoTechnologyComplaintTicketingApp.Services.Repository.Tickets
{
    public interface IDemandServices
    {
        Task AddDemandAsync(DemandDto demand);
        Task DeleteDemand(int demandId);
        Task<Page<DemandDto>> GetAllDemands(DemandDto demandDto);
        Task<DemandDto> GetDemandByIds(int demandId);
        Task UpdateDemand(DemandDto demand);
    }
}