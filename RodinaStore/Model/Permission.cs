using System.ComponentModel.DataAnnotations;

namespace RodinaStore.Model
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        public bool AddProduct { get; set; }

        public bool AddFirm { get; set; }

        public bool AddCategory { get; set; }

        public bool EditProduct { get; set; }

        public bool DeleteProduct { get; set; }

        public bool EditFirm { get; set; }

        public bool EditCategory { get; set; }

        public bool AddClient { get; set; }

        public bool EditClient { get; set; }

        public bool WithdrawalOfCash { get; set; }

        public bool ViewStats { get; set; }

        public bool ViewHistoryCart { get; set; }

        public bool DeleteClient { get; set; }

        public bool ReturnProduct { get; set; }

        public bool ViewHistoryChanged { get; set; }
    }
}
