using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var filePath = "products.txt";
        var products = new List<Product>();

        using (var reader = new StreamReader(filePath))
        {
            while (reader.ReadLine() is { } line)
            {
                var parts = line.Split(',');
                products.Add(new Product
                {
                    Name = parts[0],
                    Category = parts[1],
                    Price = decimal.Parse(parts[2])
                });
            }
        }
        
        var groupedProducts = products.GroupBy(p => p.Category);
        
        foreach (var group in groupedProducts)
        {
            Console.WriteLine("Category: {0}", group.Key);

            foreach (var product in group)
            {
                Console.WriteLine("\t{0}\t{1}", product.Name, product.Price);
            }
        }
    }
}