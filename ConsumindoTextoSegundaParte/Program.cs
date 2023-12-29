using ConsumindoTextoSegundaParte;
using System.Globalization;

Console.Write("Enter full file path: ");
string path = Console.ReadLine();

if (path is null)
    return;

using StreamReader file = new StreamReader(path);
List<Employee> employees = new List<Employee>();
string? line;

Console.Write("Enter salary: ");
double salary = double.Parse(Console.ReadLine());

while ((line = file.ReadLine()) is not null)
{
    string[] text = line.Split(',');
    string name = text[0];
    string email = text[1].Trim();
    double value = double.Parse(text[2], CultureInfo.InvariantCulture);

    Employee employee = new Employee(name, email, value);
    employees.Add(employee);
}

file.Close();

Console.WriteLine($"Email of people whose salary is more than {salary.ToString("F2")}: ");
employees.OrderBy(x => x.Name).Where(x => x.Salary > salary).ToList().ForEach(x => Console.WriteLine(x.Email));

Console.Write($"Sum of salary of people whose name starts with 'M': " +
    $"{employees.Where(x => x.Name.StartsWith("M", StringComparison.OrdinalIgnoreCase)).Sum(x => x.Salary).ToString("F2")}");

Console.ReadKey();