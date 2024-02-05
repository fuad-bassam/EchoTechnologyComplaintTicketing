using AutoMapper;
using EchoTechnologyComplaintTicketingApp.DTOS.Tickets;
using EchoTechnologyComplaintTicketingApp.DTOS.User;
using EchoTechnologyComplaintTicketingApp.Models.Tickets;
using EchoTechnologyComplaintTicketingApp.Models.User;

namespace EchoTechnologyComplaintTicketingApp.Common
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserModel, UserSignupDto>().ReverseMap();

            CreateMap<ComplaintModel, ComplaintDto>().ReverseMap();
            CreateMap<DemandModel, DemandDto>().ReverseMap();
        }
    }

}
