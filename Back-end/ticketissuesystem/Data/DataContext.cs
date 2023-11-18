using Microsoft.EntityFrameworkCore;
using ticketissuesystem.Models;

namespace ticketissuesystem.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 

        }

        public DbSet<Employee> Employees => Set<Employee>();


        public DbSet<User> Users => Set<User>();

        public DbSet<Items> Itemms => Set<Items>();



        public DbSet<Inventory> Inventory  => Set<Inventory>();

        //public DbSet<Civilstatus> Civilstatus => Set<Civilstatus>();


       


    }
}
