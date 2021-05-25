using System;
using System.ComponentModel.DataAnnotations;

namespace RodinaStore.Model
{
    public class Firm
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? DateBorn { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }

    }
}
