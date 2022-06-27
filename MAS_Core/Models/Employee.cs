using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_Core.Models
{
    public abstract class Employee
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public double? PESEL { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public DateTime DOB { get; set; }
        public double Salary { get; set; }
    }
    public class CustomerService : Employee
    {
        public int CustomerServiceID { get; set; }
        public ICollection<Form>? CreatedForms { get; set; }
    }
    public class Dispatcher : Employee
    {
        public int DispatcherID { get; set; }
        public virtual ICollection<Form>? AssignedForms { get; set; }
        
        public virtual ICollection<CargoManifest>? CreatedManifests { get; set; }
    }
    public class Warehouseman : Employee
    {
        public int WarehousemanID { get; set; }
        public ICollection<CargoManifest>? AssignedCargos { get; set; }
    }
}
