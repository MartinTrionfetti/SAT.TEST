namespace Sat.Recruitment.Api.Models
{
    public class User
    {        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }
        public User(string name, string email, string address, string phone, string UserType, decimal money)
        {
            this.Name = name;
            this.Email = email;
            this.Address = address;
            this.Phone = phone;
            this.UserType = UserType;
            this.Money = money;
        }

        public User() { }
    }
}
