using System.Threading.Tasks;
using TemplateBFF.Domain.Models.Users;

namespace TemplateBFF.Domain.Services
{
    public interface IListUsersService
    {
        Task<ListUsersOutput> ListUsers(ListUsersInput input);
    }
}
