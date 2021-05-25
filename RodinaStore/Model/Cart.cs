using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RodinaStore.Model
{
    public class Cart
    {
        public Cart()
        {
            this.CartItems = new List<CartItem>();
        }

        public Client Client { get; set; }

        public List<CartItem> CartItems { get; set; }

        [Key]
        public int Id { get; set; }

        public int Count
        {
            get
            {
                int count = 0;
                foreach (var item in this.CartItems)
                    count += item.Count;
                return count;
            }
        }

        public decimal DiscountPrice
        {
            get
            {
                decimal amount = 0;
                foreach (var item in this.CartItems)
                    amount += item.PriceWithDiscount;
                return amount;
            }
        }
        
    }
}
