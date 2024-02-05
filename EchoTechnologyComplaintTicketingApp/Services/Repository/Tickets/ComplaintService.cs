using AutoMapper;
using EchoTechnologyComplaintTicketing.Data;
using EchoTechnologyComplaintTicketingApp.DTOS.Tickets;
using EchoTechnologyComplaintTicketingApp.Models;
using EchoTechnologyComplaintTicketingApp.Models.Generic;
using EchoTechnologyComplaintTicketingApp.Models.Tickets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EchoTechnologyComplaintTicketingApp.Common.Enums;

namespace EchoTechnologyComplaintTicketingApp.Services.Repository.Tickets
{
    public class ComplaintServices : IComplaintServices
    {
        private readonly EchoTechDbContext _context;
        private readonly IMapper _mapper;

        public ComplaintServices(EchoTechDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ComplaintDto> GetComplaintById(int id)
        {
            var complaint = await _context.Complaints.Include(c => c.Demands).FirstOrDefaultAsync(c => c.ComplaintId == id);
            return _mapper.Map<ComplaintDto>(complaint);
        }
        public async Task<Page<ComplaintDto>> GetComplaintbyUser(PageInfo<ComplaintDto> page)
        {
            IQueryable<ComplaintModel> query = _context.Complaints
                .Include(c => c.Demands)
                .OrderBy(c => c.ComplaintId);

            if (!string.IsNullOrWhiteSpace(page.content.UserId))
            {
                query = query.Where(c => c.UserId == page.content.UserId);
            }

            var totalElements = await query.CountAsync();
            //pagination
            var complaints = await query
                .Skip((page.pageNumber - 1) * page.pageSize)
                .Take(page.pageSize)
                .ToListAsync();

            var complaintDtos = _mapper.Map<List<ComplaintDto>>(complaints);

            return new Page<ComplaintDto>
            {
                totalElements = totalElements,
                content = complaintDtos
            };
        }

        public async Task<int> CreateComplaint(ComplaintDto complaintDto)
        {
            complaintDto.Status = ComplaintStatus.UnderProcessing;
            complaintDto.ComplaintDate = DateTime.Today;
            var complaint = _mapper.Map<ComplaintModel>(complaintDto);
            _context.Complaints.Add(complaint);
            await _context.SaveChangesAsync();
            return complaint.ComplaintId;
        }

        public async Task<bool> UpdateComplaint(ComplaintDto complaintDto)
        {
            var existingComplaint = await _context.Complaints
                .Include(c => c.Demands)
                .FirstOrDefaultAsync(c => c.ComplaintId == complaintDto.ComplaintId);

            if (existingComplaint == null)
            {
                return false;
            }

            _mapper.Map(complaintDto, existingComplaint);
            existingComplaint.Status = CheckStatus(complaintDto);
            _context.Entry(existingComplaint).State = EntityState.Modified;


            await _context.SaveChangesAsync();
            return true;
        }

        private ComplaintStatus CheckStatus(ComplaintDto complaintDto)
        {
            if (complaintDto.Demands == null)
            {
                return ComplaintStatus.Complete;
            }
            foreach (DemandDto demand in complaintDto.Demands)
            {
                if (demand.Status == DemandStatus.UnderProcessing)
                {
                    return ComplaintStatus.UnderProcessing;
                }
            }
            return ComplaintStatus.Complete;
        }

        //public async Task<int> CreateUpdateComplaint(ComplaintDto complaintDto, int? id = null)
        //{
        //    if (id.HasValue)
        //    {
        //        // Update existing complaint
        //        var existingComplaint = await _context.Complaints.FindAsync(id.Value);
        //        if (existingComplaint == null)
        //        {
        //            return -1; // Indicate that the complaint doesn't exist
        //        }

        //        _mapper.Map(complaintDto, existingComplaint);
        //        _context.Entry(existingComplaint).State = EntityState.Modified;
        //        await _context.SaveChangesAsync();
        //        return existingComplaint.ComplaintId;
        //    }
        //    else
        //    {
        //        // Create new complaint
        //        var newComplaint = _mapper.Map<ComplaintModel>(complaintDto);
        //        _context.Complaints.Add(newComplaint);
        //        await _context.SaveChangesAsync();
        //        return newComplaint.ComplaintId;
        //    }
        //}

        public async Task<bool> DeleteComplaint(int id)
        {
            var existingComplaint = await _context.Complaints.FindAsync(id);
            if (existingComplaint == null)
            {
                return false;
            }

            _context.Complaints.Remove(existingComplaint);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}


