using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hammer.Data.BusinesssModel
{
    public class Order
    {
        public int OrderID { get; set; }
        public List<HammerPricingDTO> HammerPricingDTO { get; set; }
        public int Status { get; set; }
        public string ShippingState { get; set; }
        public float StateSalesTaxinPercentage { get; set; }
        public List<Discounts> discounts {get; set; }
        public float TotalAmount { get; set; }
        public Order(int OrderID, List<HammerPricingDTO> hammerPricingDTO, decimal Amount, int Status)
        {
            this.OrderID = OrderID;
            this.HammerPricingDTO = hammerPricingDTO;
            this.Amount = Amount;
            this.Status = Status;
            //this.CategoryUnitPricing = /*Get this unit pricing list from DB */
        }
    }
}
