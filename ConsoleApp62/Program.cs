using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp62
{
    public class Train
    {
        public int id { get; set; }
        public string Title { get; set; }
        public int RelationID { get; set; }
        public int CarsID { get; set; }
        List<City> stations = new List<City>();
        List<Car> cars = new List<Car>();
    }

    public class TrainDbContext : DbContext
    {
        public DbSet<Train> Trains { get; set; }
    }

    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class CityDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
    }

    public class Car
    {
        public int id { get; set; }
        List<Seat> seats = new List<Seat>();
    }
    public class Seat
    {
        public int id { get; set; }
        public bool isTaken { get; set; }
    }
    public class Payment
    {
        public int id { get; set; }
        public double price;
        public enum Status {Accepted, Processing, Rejected};
    }
    public class Ticket
    {
        public int id { get; set; }
        List<Ticket_For_Seat> ticket_For_Seats = new List<Ticket_For_Seat>();
        Payment payment = new Payment();
        Customer customer = new Customer("Jan", "Kowalski", "jankowalski@gmail.com", "admin");        
    }
    public class TicketDbContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
    }
    public class Ticket_For_Seat
    {
        Seat seat = new Seat();
        Discount discount = new Discount();
        Customer customer = new Customer("Marcin", "Kotecki");

    }

    public class Customer
    {
        private int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        protected string email { get; set; }
        protected string password { get; }
        public Customer(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
        public Customer(string name, string surname, string email, string password)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.password = password;
        }
    }
    public class Discount
    {
            public enum wage {Student = 51, Uczen = 37, Krwiodawca = 95}
    }

    public class Person
    {
        private int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        private int age { get; set; }
        public double salary { get; set; }
        public Person(int id, string name, string surname, int age, double salary)
        {
            this.name = name;
            this.id = id;
            this.surname = surname;
            this.age = age;
            this.salary = salary;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Train train2 = new Train();
            train2.id = 2;
            train2.Title = "Pociag2";
            train2.RelationID = 2;
            train2.CarsID = 2;
            City poznan = new City();
            poznan.id = 1;
            poznan.name = "Poznan";
            using (var context = new TrainDbContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    context.Trains.Add(train2);
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    Console.ReadKey();
                }
            }
        }
    }
}
