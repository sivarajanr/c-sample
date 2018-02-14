using cSharpSamples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpSamples.BookOrder.WithoutDelegate
{

    public class DiscountPolicies
    {
        public decimal BuyOneGetOneFree(Order order)
        {
            var orderItems = order.OrderItems;
            if (orderItems.Count < 2)
            {
                return 0m;
            }
            return orderItems.Min(p => p.Price);
        }

        public decimal FivePercentOffMoreThanFiftyDollars(Order order)
        {
            decimal nonDiscounted = order.OrderItems.Sum(p => p.Price);
            return nonDiscounted >= 50 ? nonDiscounted * 0.05m : 0M;

        }

        public decimal FiveDollarsOffMicrosoftPublication(Order order)
        {
            return order.OrderItems.Sum(p => p.Publication == Publication.Microsoft ? 5m : 0m);
        }
    }


    public class BookOrderingSystem
    {
        private readonly DiscountPolicies _discountPolicies;

        public BookOrderingSystem()
        {
            _discountPolicies = new DiscountPolicies();
        }

        public decimal ComputePrice(Order order)
        {
            decimal total = order.OrderItems.Sum(p => p.Price);

            decimal[] discounts = new[] {
                _discountPolicies.BuyOneGetOneFree(order),
                _discountPolicies.FivePercentOffMoreThanFiftyDollars(order),
                _discountPolicies.FiveDollarsOffMicrosoftPublication(order),
            };

            decimal bestDiscount = discounts.Max(discount => discount);
            total = total - bestDiscount;
            return total;
        }
    }
}
