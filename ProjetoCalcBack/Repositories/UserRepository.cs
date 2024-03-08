using ProjetoCalcBack.Models;

namespace ProjetoCalcBack.Repositories
{
    public class UserRepository
    {
        public static User Get(string username, string password) 
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "Tiago", Password = "123", Role = "manager" });
            users.Add(new User { Id = 2, Username = "Ramos",Password = "423", Role = "employee" });
            
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}
