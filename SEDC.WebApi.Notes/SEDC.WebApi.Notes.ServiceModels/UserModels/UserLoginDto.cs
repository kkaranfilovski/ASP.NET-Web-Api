namespace SEDC.WebApi.Notes.ServiceModels.UserModels
{
    public class UserLoginDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
