
using Microsoft.AspNetCore.Http;
using SmartSence.Databse.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSence.Database.Repositories
{
    public interface IOrganizationRepository
    {
        IQueryable<Organization> Organizations { get; }

        Task AddOrganization(Organization organization);
      
        Task<List<Organization>> GetAllOrganizations();
    }
}