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
            user.IsActive = true;
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

        //public List<UserVm> GetUsers()
        //{
        //    var list = (from x in _db.Users
        //                join y in _db.Users
                
        //                select new UserVm
        //                {

        //                    Name = x.Name,
        //                    ManagerName = y.Name

        //                }).ToList();
        //    return list;
        //}

        List<User> GetUsers()
        {
            return _db.Users.ToList();
        }

        List<User> UserInterface.GetUsers()
        {
            return _db.Users.ToList();
        }

        public User Exists(string email, string password)
        {
            return _db.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}
