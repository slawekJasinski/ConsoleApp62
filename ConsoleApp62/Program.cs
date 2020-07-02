using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp62
{
    public class Train
    {
        List<Car> cars = new List<Car>();
    }
    public class Car
    {
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
        List<Ticket_For_Seat> ticket_For_Seats = new List<Ticket_For_Seat>();
        Payment payment = new Payment();
        Customer customer = new Customer();        
    }
    public class Ticket_For_Seat
    {
        Seat seat = new Seat();
        Discount discount = new Discount();
        Customer customer = new Customer();

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
    }

    public class Discount
    {

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
            List<Person> list = new List<Person>();
            list.Add(new Person(1, "Jan", "Kowalski", 56, 2900));
            list.Add(new Person(2, "Joanna", "Kowalska", 34, 4900));
            list.Add(new Person(3, "Janina", "Kowal", 26, 1900));
            list.Add(new Person(4, "Tomasz", "Wawalski", 34, 3400));
            list.Add(new Person(5, "Oskar", "Janczyk", 36, 7900));
            list.Add(new Person(6, "Olgierd", "Lomik", 56, 3458));
            var query = list.Where(n => n.salary > 3000).OrderBy(n => n.surname).ToList();
            foreach(var item in query)
            {
                Console.WriteLine("{0} {1} - pensja {2}", item.name, item.surname, item.salary);
            }
            Console.ReadKey();
        }
    }
}
