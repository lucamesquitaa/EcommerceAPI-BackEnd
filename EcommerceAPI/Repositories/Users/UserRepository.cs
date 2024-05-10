using EcommerceAPI.Models;

namespace EcommerceAPI.Repositories.Users
{
    public class UserRepository
    {
        public static User Get(User user)
        {
            var builder = WebApplication.CreateBuilder();
            var admin = new User { Id = 1, Username = "admin", Password = builder.Configuration["passwordV1"] };
            if(admin.Password.ToLower() == user.Password.ToLower() && admin.Username.ToLower() == user.Username.ToLower()) 
            {
                return admin;
            }
            return null;
        }
    }
}
