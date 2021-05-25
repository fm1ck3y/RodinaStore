using RodinaStore.Forms;
using System;
using System.Drawing;

namespace RodinaStore.Model
{
    public class Product : BaseObject
    {
        private double _discount;
        private decimal _price;
        private int _stock;
        private int _sold;

        public Product() { this.Changed += OnChanged; }

        public string Name { get; set; }

        public int Barcode { get; set; }

        public string Floor { get; set; }

        public string Sizes { get; set; }

        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (_price != value)
                {
                    SetPropertyValue(_price, value, "_price", AuthForm.user != null ? AuthForm.user.Login : "");
                }

            }
        }

        public int Stock
        {
            get
            {
                return _stock;
            }
            set
            {
                if (_stock != value)
                {
                    if (!IsLoading)
                    {
                        _sold += _stock - value;
                    }
                    SetPropertyValue(_stock, value, "_stock", AuthForm.user != null ? AuthForm.user.Login : "");
                }
            }
        }

        public virtual Firm Firm { get; set; }

        public string AgeGroup { get; set; }

        public virtual Category Category { get; set; }

        public double Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                SetPropertyValue(_discount, value, "_discount", AuthForm.user != null ? AuthForm.user.Login : "");
            }
        }

        public string Material { get; set; }

        public virtual Color Color
        {
            get
            {
                return Color.FromArgb(ColorInt);
            }
        }


        public int ColorInt { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public int Sold
        {
            get
            {
                return _sold;
            }
            set
            {
                _sold = value;
            }
        }

        public string[] Tags
        {
            get
            {
                return Name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public decimal PriceWithDiscount(Client client)
        {
            double discount = this.FullDiscount(client);
            if (discount == 0) return this.Price;
            return this.Price - this.Price * decimal.Parse(discount.ToString()) ;
        }

        public double FullDiscount(Client client) {
            if (client == null)
                return this.Discount + this.Category.Discount;
            return this.Discount + this.Category.Discount + client.Discount;
        }
    }
}
