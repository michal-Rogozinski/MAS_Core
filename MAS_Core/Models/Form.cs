using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_Core.Models
{
    public class Form
    {
#nullable enable
        public virtual Payment? Payment { get; set; }
        public virtual Individual? Individual { get; set; }
        public virtual Company? Company { get; set; }
        public virtual CustomerService? CustomerService { get; set; }
        public virtual Dispatcher? Dispatcher { get; set; }
        public int? PaymentID { get; set; }
        public int? ClientsID { get; set; }
        public int? CustomerServiceID { get; set; }
        public int? DispatcherID { get; set; }
#nullable disable
        public int FormID { get; set; }

        public string DepartureName { get; set; }

        public string DestinationName { get; set; }

        public int Distance { get; set; }

        public PayloadType PayloadType { get; set; }
 
    }
}
