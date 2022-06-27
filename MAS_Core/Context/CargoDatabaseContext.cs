using MAS_Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MAS_Core.Context
{
    public class CargoDatabaseContext : DbContext
    {
        public DbSet<CargoManifest> CargoManifests { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Price> Prices { get; set; }
        //Multiple
        public DbSet<Wagon> Wagons { get; set; }
        public DbSet<Loose> LooseWagons { get; set; }
        public DbSet<Liquid> LiquidWagons { get; set; }
        public DbSet<Gas> GasWagons { get; set; }
        public DbSet<Flatbed> FlatbedWagons { get; set; }

        //DO WHAT YOU WANT
        public DbSet<CustomerService> CustomerServices { get; set; }
        public DbSet<Dispatcher> Dispatchers { get; set; }
        public DbSet<Warehouseman> Warehousemen { get; set; }

        /*public DbSet<Individual> Individuals { get; set; }
        public DbSet<Company> Companys { get; set; }*/
        public DbSet<Clients> Clients { get; set; }
        public CargoDatabaseContext(DbContextOptions<CargoDatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CultureInfo provider = new CultureInfo("pl-PL");

            /*modelBuilder.Entity<Wagon>().Property(e => e.WagonID).UseIdentityColumn();
            modelBuilder.Entity<CustomerService>().Property(e => e.CustomerServiceID).UseIdentityColumn();*/
            modelBuilder.Entity<Form>().Property(e => e.FormID).UseIdentityColumn();
            modelBuilder.Entity<Payment>().Property(e => e.PaymentID).UseIdentityColumn();

            modelBuilder.Entity<Wagon>().
                HasDiscriminator<string>("WagonType")
                .HasValue<Loose>("Loose")
                .HasValue<Gas>("Gas")
                .HasValue<Liquid>("Liquid")
                .HasValue<Flatbed>("Flatbed");

            modelBuilder.Entity<CustomerService>().ToTable("CustomerService");
            modelBuilder.Entity<Dispatcher>().ToTable("Dispatcher");
            modelBuilder.Entity<Warehouseman>().ToTable("Warehouseman");

            modelBuilder.Entity<Clients>().
                HasDiscriminator<string>("Type")
                .HasValue<Individual>("Client")
                .HasValue<Company>("Company");
            //Realations
            modelBuilder.Entity<CargoManifest>().
                HasOne<Warehouseman>(e => e.Warehouseman)
                .WithMany(e => e.AssignedCargos)
                .HasForeignKey(e => e.EmployeeID)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Form>().
                HasOne(e => e.CustomerService)
                .WithMany(e => e.CreatedForms)
                .HasForeignKey(e => e.CustomerServiceID)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Form>().
                HasOne(e => e.Payment)
                .WithOne(e => e.AttachedForm)
                .HasForeignKey<Payment>(e => e.PaymentID)
                .OnDelete(DeleteBehavior.ClientNoAction);


            modelBuilder.Entity<Form>().
                HasOne<Dispatcher>(e => e.Dispatcher)
                .WithMany(e => e.AssignedForms)
                .HasForeignKey(e => e.DispatcherID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Form>().
                HasOne(e => e.Individual)
                .WithMany(e => e.Forms)
                .HasForeignKey(e => e.FormID)
                .OnDelete(DeleteBehavior.ClientNoAction);            
            modelBuilder.Entity<Form>().
                HasOne(e => e.Company)
                .WithMany(e => e.Forms)
                .HasForeignKey(e => e.FormID)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<CustomerService>().HasData(
                new CustomerService
                {
                    CustomerServiceID = 1,
                    Name = "Jan",
                    Surname = "Kowalski",
                    PESEL = 92010636232,
                    Address = "Testowa 1/3, Wąchock 27-215,Polska",
                    Phone = "123456789",
                    Login = "jkowalski",
                    Password = "abc123",
                    DOB = DateTime.ParseExact("06/01/1992", "dd/MM/yyyy", provider),
                    Salary = 6000.00
                },
                new CustomerService
                {
                    CustomerServiceID = 2,
                    Name = "Toamsz",
                    Surname = "Zieliński",
                    PESEL = 65032754459,
                    Address = "Testowa 10, Wąchock 27-215,Polska",
                    Phone = "777888999",
                    Login = "tzielinski",
                    Password = "abc123",
                    DOB = DateTime.ParseExact("27/03/1965", "dd/MM/yyyy", provider),
                    Salary = 9000.00
                }
                );
            modelBuilder.Entity<Dispatcher>().HasData(
                new Dispatcher
                {
                    DispatcherID = 1,
                    Name = "Jan",
                    Surname = "Kowalski",
                    PESEL = 92010636232,
                    Address = "Testowa 1/3, Wąchock 27-215,Polska",
                    Phone = "123456789",
                    Login = "jkowalski",
                    Password = "abc123",
                    DOB = DateTime.ParseExact("06/01/1992", "dd/MM/yyyy", provider),
                    Salary = 6000.00
                },
                new Dispatcher
                {
                    DispatcherID = 2,
                    Name = "Toamsz",
                    Surname = "Zieliński",
                    PESEL = 65032754459,
                    Address = "Testowa 10, Wąchock 27-215,Polska",
                    Phone = "777888999",
                    Login = "tzielinski",
                    Password = "abc123",
                    DOB = DateTime.ParseExact("27/03/1965", "dd/MM/yyyy", provider),
                    Salary = 9000.00
                }
                );
            modelBuilder.Entity<Warehouseman>().HasData(
                new Warehouseman
                {
                    WarehousemanID = 1,
                    Name = "Jan",
                    Surname = "Kowalski",
                    PESEL = 92010636232,
                    Address = "Testowa 1/3, Wąchock 27-215,Polska",
                    Phone = "123456789",
                    Login = "jkowalski",
                    Password = "abc123",
                    DOB = DateTime.ParseExact("06/01/1992", "dd/MM/yyyy", provider),
                    Salary = 6000.00
                },
                new Warehouseman
                {
                    WarehousemanID = 2,
                    Name = "Toamsz",
                    Surname = "Zieliński",
                    PESEL = 65032754459,
                    Address = "Testowa 10, Wąchock 27-215,Polska",
                    Phone = "777888999",
                    Login = "tzielinski",
                    Password = "abc123",
                    DOB = DateTime.ParseExact("27/03/1965", "dd/MM/yyyy", provider),
                    Salary = 9000.00
                }
                );
            modelBuilder.Entity<Individual>().HasData(
                new
                {
                    ClientsID = 1,
                    PhoneNumber = "122334566",
                    Email = "abc@gmail.com",
                    Type = "Individual",
                    Name = "Jan",
                    Surname = "Kowalski",
                    PESEL = (double)85092234933
                });
            modelBuilder.Entity<Company>().HasData(
                new
                {
                    ClientsID = 2,
                    PhoneNumber = "122334566",
                    Email = "abc@gmail.com",
                    Type = "Company",
                    CompanyName = "ACME",
                    CompanyAddress = "ABC123",
                    NIP = (long)1231273738
                }
            );
            modelBuilder.Entity<Liquid>().HasData(
                new
                {
                    WagonID = 1,
                    Code = "XYZ123",
                    Status = State.Available,
                    LoadType = LoadTypeEnum.Liquid,
                    LoadQty = 33000.0,
                    WagonType = "Liquid"
                },
                new
                {
                    WagonID = 2,
                    Code = "ZZZ310",
                    Status = State.Available,
                    LoadType = LoadTypeEnum.Liquid,
                    LoadQty = 33000.0,
                    WagonType = "Liquid"
                }, new
                {
                    WagonID = 3,
                    Code = "DSE223",
                    Status = State.Available,
                    LoadType = LoadTypeEnum.Liquid,
                    LoadQty = 33000.0,
                    WagonType = "Liquid"
                }, new
                {
                    WagonID = 11,
                    Code = "AAA123",
                    Status = State.Occupied,
                    LoadType = LoadTypeEnum.Liquid,
                    LoadQty = 33000.0,
                    WagonType = "Liquid"
                }, new
                {
                    WagonID = 12,
                    Code = "FFF123",
                    Status = State.OutOfOrder,
                    LoadType = LoadTypeEnum.Liquid,
                    LoadQty = 33000.0,
                    WagonType = "Liquid"
                });
            modelBuilder.Entity<Loose>().HasData(
                new
                {
                    WagonID = 4,
                    Code = "GFH030",
                    Status = State.Available,
                    LoadType = LoadTypeEnum.Loose,
                    LoadQty = 58.0,
                    WagonType = "Loose"
                }, new
                {
                    WagonID = 5,
                    Code = "KJH330",
                    Status = State.Available,
                    LoadType = LoadTypeEnum.Loose,
                    LoadQty = 58.0,
                    WagonType = "Loose"
                }, new
                {
                    WagonID = 6,
                    Code = "LLL330",
                    Status = State.Available,
                    LoadType = LoadTypeEnum.Loose,
                    LoadQty = 58.0,
                    WagonType = "Loose"
                },
                new
                {
                    WagonID = 14,
                    Code = "XYZ123",
                    Status = State.Maintenance,
                    LoadType = LoadTypeEnum.Loose,
                    LoadQty = 53.0,
                    WagonType = "Loose"
                });
            modelBuilder.Entity<Gas>().HasData(
                new
                {
                    WagonID = 7,
                    Code = "YYY123",
                    Status = State.Available,
                    LoadType = LoadTypeEnum.Gas,
                    LoadQty = 123.0,
                    WagonType = "Gas"
                }, new
                {
                    WagonID = 9,
                    Code = "XYX123",
                    Status = State.Available,
                    LoadType = LoadTypeEnum.Gas,
                    LoadQty = 123.0,
                    WagonType = "Gas"
                }, new
                {
                    WagonID = 10,
                    Code = "ZZY123",
                    Status = State.Available,
                    LoadType = LoadTypeEnum.Gas,
                    LoadQty = 131.0,
                    WagonType = "Gas"
                }, new
                {
                    WagonID = 13,
                    Code = "FAZ123",
                    Status = State.Maintenance,
                    LoadType = LoadTypeEnum.Gas,
                    LoadQty = 123.0,
                    WagonType = "Gas"
                });
            modelBuilder.Entity<Form>().HasData(
                new Form
                {
                    FormID = 1,
                    DepartureName = "Rzeszów",
                    DestinationName = "Gdańsk",
                    Distance = 3600,
                    DispatcherID = 2,
                    CustomerServiceID = 1,
                    ClientsID = 1
                }); ;
        }
    }
}
