using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ETicaretAPI.Application.Repositories
{
    public interface ICustomerReadRepository : IReadRepository<Customer>
     {

     }
}
