using TemplateBFF.Domain.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemplateBFF.Domain.Adapters
{
    public interface IUserAdapter
    {
        Task<IEnumerable<User>> ListUsers();
    }
}
