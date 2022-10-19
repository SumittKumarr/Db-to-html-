using FromDatabaseToTemplate.Entities;

namespace FromDatabaseToTemplate.DAL.Repository.Interfaces
{
    public interface IUserRepository
    {

      
        Task<User> GetUserDetailsByPolicyNoAndProductCode(string policyNumber, string productCode);

        Task<Template> GetTemplateFromDatabaseAsync(string code);

        Task<IEnumerable<User>> GetUsers();


    }
}
