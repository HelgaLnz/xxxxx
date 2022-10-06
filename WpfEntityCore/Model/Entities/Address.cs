using System;
using System.Collections.Generic;

#nullable disable

namespace WpfEntityCore.Model.Entities
{
    public partial class Address
    {
        public int UserId { get; set; }
        public string RegionId { get; set; }
        public int CityId { get; set; }
        public int StreetId { get; set; }

        public virtual City City { get; set; }
        public virtual Region Region { get; set; }
        public virtual Street Street { get; set; }
        public virtual User User { get; set; }
    }
}
