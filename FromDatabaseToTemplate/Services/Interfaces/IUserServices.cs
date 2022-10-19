using FromDatabaseToTemplate.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FromDatabaseToTemplate.Services.Interfaces
{
    public interface IUserServices
    {
        Task<string> GetUser(string policyNumber, string productCode);

        Task<string> GetUsers();
    }
}
