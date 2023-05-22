using Assesment_MVC_EF.Context;
using Assesment_MVC_EF.Models;

namespace Assesment_MVC_EF.Repository
{
    public class UserRepo : UserInterface
    {

        UserDbContext _db;
        public UserRepo(UserDbContext db)
        {
            _db = db;
        }
        public User Create(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;

        }

        public int Delete(int id)
        {
            User obj = GetUserById(id);
            if (obj != null)
            {
                _db.Users.Remove(obj);
                _db.SaveChanges();
                return 0;
            }
            else

                return 1;
        }

        public int Edit(int id, User user)
        {
            User obj = GetUserById(id);
            if (obj != null)
            {
                foreach(User temp in _db.Users)
                {
                    if(temp.UserID == id)
                    {
                        temp.Name = user.Name;
                        temp.Email = user.Email;
                        temp.Address = user.Address;
                        temp.Phone = user.Phone;
                    }
                }
                _db.SaveChanges();
                return 0;
            }

            return 1;
            
        }

        public User GetUserById(int id)
        {
            return _db.Users.FirstOrDefault(x => x.UserID == id);
        }

        public List<User> GetUsers()
        {
            return _db.Users.ToList();
        }
    }
}
