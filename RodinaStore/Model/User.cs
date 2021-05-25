using RodinaStore.Model;
using System;
using System.ComponentModel.DataAnnotations;


namespace RodinaStore
{
    public class User
    {

        [Key]
        public int Id { get; set; }
        public string NickName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public virtual Permission Permission { get; set; }

        public DateTime? LastVisit { get; set; }

        public bool LockUser { get; set; }

    }
}
