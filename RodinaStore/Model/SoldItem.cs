using RodinaStore.DateBase;
using System;
using System.ComponentModel.DataAnnotations;

namespace RodinaStore.Model
{

    public class SoldItem
    {
        public static bool CheckIsReturn = false;

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Username { get; set; }

        public string Firm { get; set; }

        public string Category { get; set; }

        public double Discount { get; set; }

        public string Client { get; set; }

        public int Points { get; set; }

        public bool IsReturn { get; set; }

        public int IdReturnSoldItem { get; set; }

        public DateTime Date { get; set; }
        public int Stock { get; set; }

        public static void UpdateSold(Product soldItem, User user, int stock, Client client = null, int IdReturnSoldItem = -1)
        {
            SoldItem sold = new SoldItem();
            sold.Username = user.Login;
            sold.Category = soldItem.Category.Name;
            sold.Firm = soldItem.Firm.Name;
            sold.Price = soldItem.Price;
            sold.Date = DateTime.Now;
            sold.Name = soldItem.Name;
            sold.Stock = stock;
            sold.Discount = soldItem.FullDiscount(client);
            sold.IsReturn = SoldItem.CheckIsReturn;
            sold.IdReturnSoldItem = IdReturnSoldItem;
            RodinaStoreController.Instance.UpdateSolds(sold);
            soldItem.Stock += (SoldItem.CheckIsReturn ? 1 : -1) * stock;
            RodinaStoreController.Instance.Update(soldItem);
        }

        public decimal PriceWithDiscount
        {
            get
            {
                return this.Price - this.Price * decimal.Parse(this.Discount.ToString());
            }
        }
    }
}
