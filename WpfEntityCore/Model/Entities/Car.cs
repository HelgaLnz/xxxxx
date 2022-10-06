using System;
using System.Collections.Generic;

#nullable disable

namespace WpfEntityCore.Model.Entities
{
    public partial class Car
    {
        public Car()
        {
            CarRegionNumbers = new HashSet<CarRegionNumber>();
            Contracts = new HashSet<Contract>();
            UserHasCars = new HashSet<UserHasCar>();
        }

        public int Id { get; set; }
        public string CarModel { get; set; }
        public string Mark { get; set; }
        public string Number { get; set; }
        public string Image { get; set; }
        public bool Insurance { get; set; }
        public bool IsDamaged { get; set; }
        public int Mileage { get; set; }
        public DateTime ManufactureDate { get; set; }

        public virtual ICollection<CarRegionNumber> CarRegionNumbers { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<UserHasCar> UserHasCars { get; set; }
    }
}
