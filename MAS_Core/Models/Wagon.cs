using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace MAS_Core.Models
{
    public enum State
    {
        Available,
        Occupied,
        OutOfOrder,
        Maintenance
    }
    public enum LoadTypeEnum
    {
        Liquid,
        Gas,
        Loose,
        Flatbed
    }
    public abstract class Wagon
    {
        public int WagonID { get; set; }

        public string Code { get; set; }

        public State Status { get; set; }

        public double LoadQty { get; set; }

        public LoadTypeEnum LoadType { get; set; }
        public string WagonType { get; set; }
        public virtual ICollection<CargoManifest> CargoManifests { get; set; }
    }
    public class Loose : Wagon
    {
        public new string WagonType = "Loose";
    }
    public class Gas : Wagon
    {
        public new string WagonType = "Gas";
    }
    public class Liquid : Wagon
    {
        public new string WagonType = "Liquid";
    }
    public class Flatbed : Wagon
    {
        public new string WagonType = "Flatbed";
    }
}
