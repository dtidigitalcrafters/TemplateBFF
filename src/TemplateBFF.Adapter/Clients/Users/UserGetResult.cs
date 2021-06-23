namespace TemplateBFF.Adapter.Clients.Users
{
    public class UserValueGetResult
    {
        public UserGetResult user { get; set; }
    }
    public class UserGetResult
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
