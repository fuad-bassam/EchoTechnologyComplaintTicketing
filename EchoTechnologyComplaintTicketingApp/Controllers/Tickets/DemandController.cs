using EchoTechnologyComplaintTicketingApp.DTOS.Tickets;
using EchoTechnologyComplaintTicketingApp.Services.Repository.Tickets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoTechnologyComplaintTicketingApp.Controllers.Tickets
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DemandController : ControllerBase
    {
        private readonly IDemandServices _demandService;

        public DemandController(IDemandServices demandService)
        {
            _demandService = demandService;
        }

        [HttpPost("GetAllDemands/{complaintId}")]
        public async Task<ActionResult<List<DemandDto>>> GetAllDemands(DemandDto demandDto)
        {
            var demands = await _demandService.GetAllDemands(demandDto);
            return Ok(demands);
        }

        [HttpPost("GetDemandById/{demandId}")]
        public async Task<ActionResult<DemandDto>> GetDemandById(int demandId)
        {
            var demand = await _demandService.GetDemandByIds(demandId);
            return Ok(demand);
        }

        [HttpPost("AddDemand")]
        public async Task<ActionResult> AddDemand([FromBody] DemandDto demand)
        {
            await _demandService.AddDemandAsync(demand);
            return Ok();
        }

        [HttpPost("UpdateDemand")]
        public async Task<ActionResult> UpdateDemand([FromBody] DemandDto demand)
        {
            await _demandService.UpdateDemand(demand);
            return Ok();
        }

        [HttpPost("DeleteDemand/{demandId}")]
        public async Task<ActionResult> DeleteDemand(int demandId)
        {
            await _demandService.DeleteDemand(demandId);
            return Ok();
        }
    }

}
