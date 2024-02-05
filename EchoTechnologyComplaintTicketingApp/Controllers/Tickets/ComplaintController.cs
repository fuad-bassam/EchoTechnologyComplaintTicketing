using EchoTechnologyComplaintTicketingApp.DTOS.Tickets;
using EchoTechnologyComplaintTicketingApp.Models;
using EchoTechnologyComplaintTicketingApp.Models.Generic;
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
    public class ComplaintController : ControllerBase
    {
        private readonly IComplaintServices _complaintService;

        public ComplaintController(IComplaintServices complaintService)
        {
            _complaintService = complaintService;
        }

        [HttpPost("GetComplaintById/{id}")]
        public async Task<ActionResult<ComplaintDto>> GetComplaintById(int id)
        {
            var complaint = await _complaintService.GetComplaintById(id);
            return Ok(complaint);
        }

        [HttpPost("CreateComplaint")]
        public async Task<ActionResult<int>> CreateComplaint([FromBody] ComplaintDto complaintDto)
        {
            var complaintId = await _complaintService.CreateComplaint(complaintDto);
            return Ok(complaintId);
        }

        [HttpPost("UpdateComplaint/{id}")]
        public async Task<ActionResult> UpdateComplaint( ComplaintDto complaintDto)
        {
            var result = await _complaintService.UpdateComplaint( complaintDto);
            return Ok(result);
        }

        [HttpPost("DeleteComplaint/{id}")]
        public async Task<ActionResult> DeleteComplaint(int id)
        {
            var result = await _complaintService.DeleteComplaint(id);
            return Ok(result);
        }

        //[HttpPost("CreateUpdateComplaint")]
        //public async Task<ActionResult<int>> CreateUpdateComplaint([FromBody] ComplaintDto complaintDto, [FromQuery] int? id = null)
        //{
        //    var result = await _complaintService.CreateUpdateComplaint(complaintDto, id);
        //    return Ok(result);
        //}

        [HttpPost("GetComplaintsByUser")]
        public async Task<ActionResult<Page<ComplaintDto>>> GetComplaintsByUser([FromBody] PageInfo<ComplaintDto> page)
        {
            var complaints = await _complaintService.GetComplaintbyUser(page);
            return Ok(complaints);
        }
    }

}
