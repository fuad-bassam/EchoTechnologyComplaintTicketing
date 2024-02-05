namespace EchoTechnologyComplaintTicketingApp.Services.Repository.Generic
{
    public interface IJwtTokenService
    {
        string GenerateToken(string email);
    }
}