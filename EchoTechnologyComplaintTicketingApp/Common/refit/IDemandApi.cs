using EchoTechnologyComplaintTicketingApp.DTOS.Tickets;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoTechnologyComplaintTicketingApp.Common.refit
{
    public interface IDemandApi
    {
        [Post("/api/Demand/GetAllDemands/{complaintId}")]
        Task<List<DemandDto>> GetAllDemandsAsync(int complaintId);

        [Post("/api/Demand/GetDemandById/{demandId}")]
        Task<DemandDto> GetDemandByIdAsync(int demandId);

        [Post("/api/Demand/AddDemand")]
        Task AddDemandAsync([Body] DemandDto demand);

        [Post("/api/Demand/UpdateDemand")]
        Task UpdateDemandAsync([Body] DemandDto demand);

        [Post("/api/Demand/DeleteDemand/{demandId}")]
        Task DeleteDemandAsync(int demandId);
    }
}
