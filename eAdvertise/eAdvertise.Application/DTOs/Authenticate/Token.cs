namespace eAdvertise.Application.DTOs.Authenticate
{
    public class Token
    {
        public Token(string id, string userName, string roles)
        {
            Id = id;
            UserName = userName;
            Roles = roles;
        }
        public string Id { get; init; }
        public string UserName { get; init; }
        public string Roles { get; init; }
    }
}
