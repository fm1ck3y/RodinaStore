namespace RodinaStore.Model
{
    public class CartItem
    {
        public Product product { get; set; }

        public Client client = null;

        public int Count { get; set; }

        public string ProductName
        {
            get
            {
                return this.product.Name;
            }
        }

        public decimal PriceWithDiscount
        {
            get
            {
                return this.product.PriceWithDiscount(this.client) * this.Count;
            }
        }

        public string Size
        {
            get
            {
                return this.product.Sizes;
            }
        }

        public double Discount
        {
            get
            {
                return this.product.FullDiscount(this.client);
            }
        }

    }
}
