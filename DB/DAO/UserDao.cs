using DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.DAO
{
    public class UserDao
    {
        ShopOnlineContext db = null;
        public UserDao()
        {
            db = new ShopOnlineContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Login(string userName, string passWord)
        {
            var result = db.Users.FirstOrDefault(x => x.UserName == userName && x.PassWord == passWord
                                                      && (x.Status.HasValue || x.Status.HasValue && x.Status.Value));
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckUserExist (string userName)
        {
            var user = db.Users.FirstOrDefault(x => x.UserName.Equals(userName));
            return user != null;
        }
    }
}
