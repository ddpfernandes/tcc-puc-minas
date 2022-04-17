namespace User.Application.Queries
{
    public class UserViewModel
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string AccessType { get; set; }
    }

    public class TokenViewModel
    {
        public string AccessToken { get; set; }
    }

    public class AuthViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}