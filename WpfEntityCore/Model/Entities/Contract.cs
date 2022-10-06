using System;
using System.Collections.Generic;

#nullable disable

namespace WpfEntityCore.Model.Entities
{
    public partial class Contract
    {
        public int ContractNum { get; set; }
        public int CarId { get; set; }
        public DateTime? Date { get; set; }
        public bool? Сonsideration { get; set; }
        public int? Price { get; set; }

        public virtual Car Car { get; set; }
    }
}
