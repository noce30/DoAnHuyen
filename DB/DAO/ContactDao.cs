using DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.DAO
{
    public class ContactDao
    {
        ShopOnlineContext db = null;
        public ContactDao()
        {
            db = new ShopOnlineContext();
        }
        public long Insert(Feedback entity)
        {
            db.Feedbacks.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
    }
}
