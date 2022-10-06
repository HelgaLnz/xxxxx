using System;
using System.Collections.Generic;

#nullable disable

namespace WpfEntityCore.Model.Entities
{
    public partial class CarRegionNumber
    {
        public string RegionNumberId { get; set; }
        public int CarId { get; set; }

        public virtual Car Car { get; set; }
        public virtual Region RegionNumber { get; set; }
    }
}
