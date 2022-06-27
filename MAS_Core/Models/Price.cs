using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_Core.Models
{
    public class Price
    {
        public int PriceID { get; set; }
        public string LoadType;
        public double LoadUnitPrice;
    }
}
