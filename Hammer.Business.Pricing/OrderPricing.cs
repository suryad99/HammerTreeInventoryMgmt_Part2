using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hammer.Data.BusinesssModel;

namespace Hammer.Business.Pricing
{
    public class OrderPricing
    {
        public float TotalPricing(Order order)
        {
            float TotalCost = 0;

            //Sum the cost of all the hammers as per the category unit pricing.
            TotalCost = order.HammerPricingDTO.Sum(h => h.categoryPricingDTO.UnitCost);

            //If the total order of hammers is more than 50 then give discount 20%
            foreach (var d in order.discounts)
            {
                //Apply high volume discount by checking volume.
                if (d.discountName == "HighVolumeDiscount" && order.HammerPricingDTO.Count > 50)
                {
                    if (d.discountType == DiscountType.Percentage)
                    {
                        TotalCost = TotalCost * (100 - d.discountUnitValue) / 100;
                    }
                    else if(d.discountType == DiscountType.Flat)
                    {
                        TotalCost = TotalCost - d.discountUnitValue;
                    }
                }
                else // Apply other generic discounts 
                {
                    if (d.discountType == DiscountType.Percentage)
                    {
                        TotalCost = TotalCost * (100 - d.discountUnitValue) / 100;
                    }
                    else if (d.discountType == DiscountType.Flat)
                    {
                        TotalCost = TotalCost - d.discountUnitValue;
                    }
                }
            }

            if(order.ShippingState != "CA") // in-state is CA
            {
                TotalCost = TotalCost * (1 + order.StateSalesTaxinPercentage / 100); 
            }

            order.TotalAmount = TotalCost;

            return TotalCost;
        }
    }
}
