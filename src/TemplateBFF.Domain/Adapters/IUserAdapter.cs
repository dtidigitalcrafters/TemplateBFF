using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateBFF.Domain.Models.Users;

namespace TemplateBFF.Domain.Adapters
{
    public interface IUserAdapter
    {
        Task<IEnumerable<User>> ListUsers();
    }
}
