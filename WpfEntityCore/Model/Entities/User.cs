using System;
using System.Collections.Generic;

#nullable disable

namespace WpfEntityCore.Model.Entities
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            UserHasCars = new HashSet<UserHasCar>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MidleName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Passport { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<UserHasCar> UserHasCars { get; set; }
    }
}
