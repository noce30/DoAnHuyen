using DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.DAO
{
    public class ProductDao
    {
        ShopOnlineContext db = null;
        public ProductDao()
        {
            db = new ShopOnlineContext();
        }

        // lay san pham theo id lay tu db
        public Product GetProductById(long id)
        {
            return db.Products.FirstOrDefault(x => x.ID == id);
        }

        public List<Product> GetProductsByCategory(long categoryId)
        {
            var result = db.Products.Where(x => x.CategoryID == categoryId && x.Status).ToList();
            return result;
        }
    }
}
