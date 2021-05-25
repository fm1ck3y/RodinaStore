using System;
using System.ComponentModel.DataAnnotations;

namespace RodinaStore.Model
{

    public class AuditItem
    {
        [Key]
        public int Id { get; set; }
        public string NewValue { get; set; }
        public string OldValue { get; set; }
        public string PropertyName { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }
    }
}
