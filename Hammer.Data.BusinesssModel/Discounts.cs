using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hammer.Data.BusinesssModel
{
    public class Discounts
    {
        public string discountName { get; set; }
        public DiscountType discountType { get; set; }
        public float discountUnitValue { get; set; }
    }

    public enum DiscountType
    {
        Flat,
        Percentage
    }
}
