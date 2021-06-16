using TemplateBFF.Domain;
using TemplateBFF.Domain.Adapters;
using TemplateBFF.Domain.Models.Users;
using TemplateBFF.Domain.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateBFF.Application.Services.Users
{
    public class ListUsersService: IListUsersService
    {
        private readonly IUserAdapter userAdapter;

        public ListUsersService(IUserAdapter userAdapter)
        {
            this.userAdapter = userAdapter ??
                   throw new ArgumentNullException(nameof(userAdapter));
        }

        public async Task<ListUsersOutput> ListUsers(ListUsersInput input)
        {
            ValidarInput(input);            

            var users = await userAdapter.ListUsers();

            return new ListUsersOutput
            {
                Users = users
            };
        }

        private void ValidarInput(ListUsersInput input)
        {
            if (input.BirthdayMonth.HasValue && (input.BirthdayMonth > 12 || input.BirthdayMonth < 1))
                throw new DomainException($"Mês inválido.");
        }
    }
}
