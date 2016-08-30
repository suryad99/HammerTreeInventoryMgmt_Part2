using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hammer.Data.BusinesssModel
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }

    public class CategoryPricingDTO : CategoryDTO
    {
        public float UnitCost { get; set; }

        //Assuming only USD. Can be used for exchange conversion if required
        public string Currency {
            get { return "USD"; }
        }
    }
}
