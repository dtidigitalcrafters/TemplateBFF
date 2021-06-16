using TemplateBFF.Domain.Models.Users;
using System.Threading.Tasks;

namespace TemplateBFF.Domain.Services
{
    public interface IListUsersService
    {
        Task<ListUsersOutput> ListUsers(ListUsersInput input);
    }
}
