using System;
using System.ComponentModel.DataAnnotations;

namespace RodinaStore.Model
{
    public class Client
    {

        [Key]
        public int Id { get; set; }

        public string FIO { get; set; }

        public int Points { get; set; }

        public double Discount { get; set; }

        public decimal Purchases { get; set; }

        public long Number { get; set; }

        public DateTime? LastVisit { get; set; }

       

    }
}
