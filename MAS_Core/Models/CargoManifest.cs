using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_Core.Models
{
    public enum PayloadType
    {
        Loose,
        Liquid,
        Gas,
        Container

    }
    public class CargoManifest
    {
        public int CargoManifestID { get; set; }
        public PayloadType PayloadType { get; set; }
        public double PayloadQty { get; set; }
        public string DeparturePlace { get; set; }
        public string DestinationPlace { get; set; }
        public string Status { get; set; }
        public virtual Warehouseman Warehouseman { get; set; }
        public virtual ICollection<Wagon> Wagons { get; set; }
        public int EmployeeID { get; set; }
    }
}
