namespace Sat.Recruitment.Api.Models
{
    public class UserResult
    {
        public User User { get; set; }
        public string Errors { get; set; }
        public bool IsSuccess { get; set; }
    }
}
