
class Employee
{
    public Employee(string name, decimal salary, int yearsOfExperience)
    {
        Name = name;
        Salary = salary;
        YearsOfExperience = yearsOfExperience;
    }

    public Employee()
    {
    }

    public string Name { get; set; }
    public decimal Salary { get; set; }
    public int YearsOfExperience { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        const string filePath = "employees.txt";
        var employees = new List<Employee>();

        using (var reader = new StreamReader(filePath))
        {
            while (reader.ReadLine() is { } line)
            {
                var parts = line.Split(',');
                employees.Add(new Employee
                {
                    Name = parts[0],
                    Salary = decimal.Parse(parts[1]),
                    YearsOfExperience = int.Parse(parts[2])
                });
            }
        }
        employees = employees.OrderBy(e => e.Salary).ToList();
        
        foreach (var employee in employees)
        {
            Console.WriteLine("{0}\t{1}\t{2}", employee.Name, employee.Salary, employee.YearsOfExperience);
        }
    }
}