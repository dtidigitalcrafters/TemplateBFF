using System.Collections.Generic;

namespace TemplateBFF.WebApi.Dtos.Users
{
    public class ListUsersGetResult
    {
        public IEnumerable<UserDto> Users { get; set; }
    }
}
