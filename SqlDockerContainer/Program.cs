using SqlDockerContainer.Data;
using SqlDockerContainer.Entities;
using System;
using System.Linq;

namespace SqlDockerContainerW
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new PersonDbContext();
            Console.WriteLine("For insert a new person you need to digit '1' ");
            if (Console.ReadLine() == "1")
            {
                Console.WriteLine("How much people do you like to insert?");
                int quantity = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < quantity; i++)
                {
                    dbContext.Add(PersonFill());
                }
                dbContext.SaveChanges();
            }
            else
            {
                var lista = dbContext.Person.AsQueryable();
                lista = lista.OrderByDescending(x => x.FirstName);
                foreach (var person in lista)
                {
                    Console.WriteLine($" FirstName: {person.FirstName} LastName: {person.LastName} Age: {person.Age}");
                }
            }
        }
        static Person PersonFill()
        {
            Console.WriteLine("Digit FirstName: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Digit LastName: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Digit your Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            return new Person(firstName,lastName,age);
        }
    }
}
