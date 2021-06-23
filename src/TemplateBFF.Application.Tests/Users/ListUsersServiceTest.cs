using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateBFF.Application.Services.Users;
using TemplateBFF.Domain;
using TemplateBFF.Domain.Adapters;
using TemplateBFF.Domain.Models.Users;
using TemplateBFF.Domain.Services;
using Xunit;

namespace TemplateBFF.Application.Tests.Users
{
    public class ListUsersServiceTest
    {
        private readonly Mock<IUserAdapter> _userAdapter;
        private readonly IListUsersService _listUsersServices;

        public ListUsersServiceTest()
        {
            _userAdapter = new Mock<IUserAdapter>();
            _listUsersServices = new ListUsersService(_userAdapter.Object);
        }

        [Fact]
        public async Task ListUsersService_Success()
        {
            var expectedUsers = new List<User>()
                {
                    new User
                    {
                        Email = "teste",
                        Id = "12344",
                        Name = "Teste da Silva"
                    },
                    new User
                    {
                        Email = "teste",
                        Id = "12344",
                        Name = "Teste da Silva"
                    }
            };
            var input = new ListUsersInput
            {
                BirthdayMonth = 12
            };

            _userAdapter.Setup(x => x.ListUsers()).ReturnsAsync(expectedUsers);

            var users = await _listUsersServices.ListUsers(input);

            Assert.NotNull(expectedUsers);
            Assert.NotNull(users);
        }

        [Fact]
        public async Task ListUsersService_MaximumMonth()
        {

            var excecaoLancada = await Assert.ThrowsAsync<DomainException>(
            () => _listUsersServices.ListUsers(new ListUsersInput
            {
                BirthdayMonth = 13
            }));

            _userAdapter.Verify(x => x.ListUsers(), Times.Never());
            Assert.Equal("Mês inválido.", excecaoLancada.Message);
        }

        [Fact]
        public async Task ListUsersService_MinimumMonth()
        {

            var excecaoLancada = await Assert.ThrowsAsync<DomainException>(
            () => _listUsersServices.ListUsers(new ListUsersInput
            {
                BirthdayMonth = 0
            }));

            _userAdapter.Verify(x => x.ListUsers(), Times.Never());
            Assert.Equal("Mês inválido.", excecaoLancada.Message);
        }

    }
}
