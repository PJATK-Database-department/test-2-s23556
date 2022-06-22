using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestExample2.Models
{
    public class OrderDBContext : DbContext
    {
        public OrderDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientOrder> ClientOrders { get; set; }
        public DbSet<Confectionery> Confectioneries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Confectionery_ClientOrder> Confectionery_ClientOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ClientList = new List<Client> { new Client { IdClient = 1, FirstName = "Mateusz", LastName = "Kowalski" } };
            var ClientOrderList = new List<ClientOrder> { new ClientOrder { IdClientOrder = 1, Comments = "nice", IdClient=1,IdEmployee=1 } };
            var EmployeeList = new List<Employee> { new Employee { IdEmployee = 1, FirstName = "Przemek", LastName = "Kowal" } };
            var ConfectioneryList = new List<Confectionery> { new Confectionery { IdConfectionery = 1, Name = "Shoe", PricePerOne = 2 } };
            var Confectionery_ClientOrderList = new List<Confectionery_ClientOrder> { new Confectionery_ClientOrder { IdClientOrder = 1, IdConfectionary = 1, Amount = 2 } };

            modelBuilder.Entity<Client>(x =>
            {
                x.HasKey(y => y.IdClient);
                x.Property(y => y.FirstName).HasMaxLength(50).IsRequired();
                x.Property(y => y.LastName).HasMaxLength(60).IsRequired();
                x.HasData(ClientList);
                x.ToTable("Client");
            });

            modelBuilder.Entity<ClientOrder>(x =>
            {
                x.HasKey(y => y.IdClientOrder);
                x.Property(y => y.OrderDate).IsRequired();
                x.Property(y => y.CompletionDate).IsRequired();
                x.HasOne(y => y.client).WithMany(y => y.Orders).HasForeignKey(y => y.IdClient).OnDelete(DeleteBehavior.ClientCascade);
                x.HasOne(y => y.employee).WithMany(y => y.Orders).HasForeignKey(y => y.IdEmployee).OnDelete(DeleteBehavior.ClientCascade);
                x.HasData(ClientOrderList);
                x.ToTable("ClientOrder");
            });

            modelBuilder.Entity<Employee>(x =>
            {
                x.HasKey(y => y.IdEmployee);
                x.Property(y => y.FirstName).HasMaxLength(50).IsRequired(); 
                x.Property(y => y.LastName).HasMaxLength(600).IsRequired();
                x.HasData(EmployeeList);
                x.ToTable("Employee");
            });

            modelBuilder.Entity<Confectionery>(x =>
            {
                x.HasKey(y => y.IdConfectionery);
                x.Property(y => y.Name).HasMaxLength(100).IsRequired();
                x.Property(y => y.PricePerOne).IsRequired();
                x.HasData(ConfectioneryList);
                x.ToTable("Confectionery");
            });

            modelBuilder.Entity<Confectionery_ClientOrder>(x =>
            {
                x.HasKey(y => new { y.IdClientOrder, y.IdConfectionary });
                x.HasOne(y => y.confectionery).WithMany(y => y.Confectionery_ClientOrders).HasForeignKey(y => y.IdConfectionary).OnDelete(DeleteBehavior.ClientCascade);
                x.HasOne(y => y.clientOrder).WithMany(y => y.Confectionery_ClientOrders).HasForeignKey(y => y.IdClientOrder).OnDelete(DeleteBehavior.ClientCascade);
                x.Property(y => y.Comments).HasMaxLength(300);
                x.HasData(Confectionery_ClientOrderList);
                x.ToTable("Confectionery_ClientOrder");
            });
        }
    }
}
