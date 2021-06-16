using AutoMapper;
using Newtonsoft.Json;
using TemplateBFF.Domain.Adapters;
using TemplateBFF.Domain.Models.Users;
using TemplateBFF.DtiRoundAdapter.Clients.Users;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TemplateBFF.DtiRoundAdapter.Adapters.Users
{
    public class UserAdapter : IUserAdapter
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IMapper mapper;

        private const string USER_URI = "user";

        public UserAdapter(
           IHttpClientFactory httpClientFactory,
           IMapper mapper)
        {
            this.httpClientFactory = httpClientFactory;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<User>> ListUsers()
        {
            var client = GetClient();

            var response = await client.GetAsync(USER_URI);

            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();

                var resultModel = JsonConvert.DeserializeObject<IEnumerable<UserGetResult>>(stringResult);

                return mapper.Map<IEnumerable<UserGetResult>, IEnumerable<User>>(resultModel);
            }

            throw await response.ThrowHttpResponseException();
        }

        private HttpClient GetClient()
        {
            return httpClientFactory.CreateClient(Constants.RoundHttpClientName);
        }
    }
}
