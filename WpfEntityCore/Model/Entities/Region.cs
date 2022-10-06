using System;
using System.Collections.Generic;

#nullable disable

namespace WpfEntityCore.Model.Entities
{
    public partial class Region
    {
        public Region()
        {
            Addresses = new HashSet<Address>();
            CarRegionNumbers = new HashSet<CarRegionNumber>();
        }

        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<CarRegionNumber> CarRegionNumbers { get; set; }
    }
}
