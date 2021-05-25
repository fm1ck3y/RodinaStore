using System;

namespace RodinaStore.Model
{
    public class Till : BaseObject
    {
        private decimal _money;

        public Till() { this.Changed += OnChanged; }

        public decimal Money
        {
            get
            {
                return _money;
            }
            set
            {
                if (!Product.IsLoading)
                {
                    _money = value;
                    if(SoldItem.CheckIsReturn)
                        RodinaStore.Properties.Settings.Default.Money = (decimal.Parse(RodinaStore.Properties.Settings.Default.Money) - _money).ToString();
                    else
                        RodinaStore.Properties.Settings.Default.Money = (decimal.Parse(RodinaStore.Properties.Settings.Default.Money) + _money).ToString();
                    RodinaStore.Properties.Settings.Default.Save();
                    _money = 0;
                }
            }
        }

        public DateTime Date { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }

        public int Stock { get; set; }


    }
}
