using System.Collections.Generic;

namespace TemplateBFF.Domain.Models.Users
{
    public class ListUsersOutput
    {
        public IEnumerable<User> Users { get; set; }
    }
}
