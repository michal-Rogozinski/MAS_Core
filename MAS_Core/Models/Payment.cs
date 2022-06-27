using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_Core.Models
{
    public class Payment
    {
        public virtual Form AttachedForm { get; set; }
        public int FormID { get; set; }
        public int PaymentID { get; set; }
        public double Amount { get; set; }
        public DateTime DateDue { get; set; }
        public string? Status { get; set; }
    }
}
