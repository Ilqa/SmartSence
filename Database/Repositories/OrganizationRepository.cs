
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SmartSence.Database.Repositories;
using SmartSence.Databse.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Database.Repositories;

public class OrganizationRepository : IOrganizationRepository
{
    private readonly IRepositoryAsync<Organization> _repository;
   

    public OrganizationRepository(IRepositoryAsync<Organization> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;

      
    }


    public IQueryable<Organization> Organizations => _repository.Entities;

    public async Task AddOrganization(Organization company)
    {
        await _repository.AddAsync(company);
       
    }

    public Task<List<Organization>> GetAllOrganizations()
    {
        return Organizations.ToListAsync();
    }
}