using System;

namespace StationariesShopDB
{
    class Program
    {
        static void Main(string[] args)
        {
            TableCreator foodTable = new TableCreator(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = StationaryDB;Integrated Security=True;");
            if (foodTable.CreateTables())
            {
                
                Console.WriteLine("Tables were created!");
            }
            else
            {
                Console.WriteLine("Tables already exists!");

            }
            foodTable.SeedData();
            Console.WriteLine("Data was seed!");
        }
    }
}
