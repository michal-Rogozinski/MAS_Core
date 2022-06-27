using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_Core.Models
{
    public abstract class Clients
    {
        public int ClientsID { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Type { get; set; }
        public virtual ICollection<Form>? Forms { get; set; }
    }
    public class Individual : Clients
    {
        public new string Type = "Individual";
#nullable enable
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public double? PESEL { get; set; }
#nullable disable
    }
    public class Company : Clients
    {
        public new string Type = "Company";
#nullable enable
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public long? NIP { get; set; }
#nullable disable
    }
}
