using System;
using System.Collections.Generic;

#nullable disable

namespace WpfEntityCore.Model.Entities
{
    public partial class UserHasCar
    {
        public int UserId { get; set; }
        public int CarId { get; set; }

        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
    }
}
