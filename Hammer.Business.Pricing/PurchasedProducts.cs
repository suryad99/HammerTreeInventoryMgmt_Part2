using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hammer.Data.BusinesssModel;

namespace Hammer.Business.Pricing
{
    public class PurchasedProducts
    {
        //Product left in shopping cart are the one still not purchased so need to get all recommended products
        // which are not part of shopping cart which will give purchased products.
        public IList<Products> GetPurchasedProducts(IList<Products> cartList, IList<Products> RecommendedProducts)
        {
            var result = RecommendedProducts.Where(p => cartList.All(p2 => p2.ProductId != p.ProductId));
            return result.ToList();
        }
    }
}
