using AutoMapper;
using EchoTechnologyComplaintTicketing.Data;
using EchoTechnologyComplaintTicketingApp.DTOS.Tickets;
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
    public class DemandServices : IDemandServices
    {
        private readonly EchoTechDbContext _dbContext;
        private readonly IMapper _mapper;

        public DemandServices(EchoTechDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Page<DemandDto>> GetAllDemands(DemandDto demandDto)
        {
            var demands = await _dbContext.Demands
                .Where(d => d.ComplaintId == demandDto.ComplaintId)
                .ToListAsync();

            return _mapper.Map<Page<DemandDto>>(demands);
        }


        public async Task<DemandDto> GetDemandByIds(int demandId)
        {
            var demand = await _dbContext.Demands.FindAsync(demandId);

            return _mapper.Map<DemandDto>(demand);
        }

        public async Task AddDemandAsync(DemandDto demand)
        {
            demand.Status = DemandStatus.UnderProcessing;
            var demandEntity = _mapper.Map<DemandModel>(demand);
            _dbContext.Demands.Add(demandEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDemand(DemandDto demand)
        {
            var existingDemand = await _dbContext.Demands.FindAsync(demand.DemandId);

            if (existingDemand != null)
            {
                _mapper.Map(demand, existingDemand);
                _dbContext.Entry(existingDemand).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteDemand(int demandId)
        {
            var demand = await _dbContext.Demands.FindAsync(demandId);

            if (demand != null)
            {
                _dbContext.Demands.Remove(demand);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
