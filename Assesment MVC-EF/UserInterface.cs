using Assesment_MVC_EF.Models;

namespace Assesment_MVC_EF
{
    public interface UserInterface
    {

        List<User> GetUsers();
        User Create(User user);
        User GetUserById(int id);
        int Delete(int id);
        int Edit(int id, User user);
        
    }
}
