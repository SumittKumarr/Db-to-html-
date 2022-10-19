using FromDatabaseToTemplate.DAL.DbContexts;
using FromDatabaseToTemplate.DAL.Repository.Interfaces;
using FromDatabaseToTemplate.Entities;
using FromDatabaseToTemplate.Extention.cs;
using Microsoft.EntityFrameworkCore;
using PuppeteerSharp;
using System.Reflection;

namespace FromDatabaseToTemplate.DAL.Repository.Implimentations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUserDetailsByPolicyNoAndProductCode(string policyNumber, string productCode)
        {
            return await context.Users
                .FirstOrDefaultAsync(t => t.PolicyNumber == policyNumber && t.ProductCode == productCode);                     
        }


        public async Task<Template> GetTemplateFromDatabaseAsync(string code)
        {
            return await context.Templates
                .Where(t => t.Code == code).FirstAsync();

        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

    }
}
