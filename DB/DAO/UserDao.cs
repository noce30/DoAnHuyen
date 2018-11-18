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
            var result = db.Users.FirstOrDefault(m => m.UserName == userName && m.PassWord == passWord && 
            (m.Status.HasValue || m.Status.HasValue && m.Status.Value));
            if(result ==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public bool CheckUserExist (string userName)
        {
            var user = db.Users.FirstOrDefault(x => x.UserName.Equals(userName));
            return user != null;
        }
    }
}
