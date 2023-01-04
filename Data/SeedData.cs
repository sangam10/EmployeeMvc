
using EmployeeInfo.Models;
using Microsoft.EntityFrameworkCore;
namespace EmployeeInfo.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new EmployeeContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<EmployeeContext>>()))
        {
            // Look for any movies.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }
            context.Employees.AddRange(
                new Employee
                {
                    FullName = "sangam rimal",
                    ProfileUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ4lT6c3OEoasZOhpZmzNUMBuE73eW7TBuCgg&usqp=CAU",
                    Salary = 99990.0,
                    Email = "sangam@email.com",
                },
                new Employee
                {
                    FullName = "tanka rimal",
                    ProfileUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ4lT6c3OEoasZOhpZmzNUMBuE73eW7TBuCgg&usqp=CAU",
                    Salary = 589898.00,
                    Email = "tanka@email.com",
                },
                new Employee
                {
                    FullName = "dinesh rimal",
                    ProfileUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ4lT6c3OEoasZOhpZmzNUMBuE73eW7TBuCgg&usqp=CAU",
                    Salary = 788787.00,
                    Email = "dinesh@email.com",
                },
                new Employee
                {
                    FullName = "subash bhattarai",
                    ProfileUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ4lT6c3OEoasZOhpZmzNUMBuE73eW7TBuCgg&usqp=CAU",
                    Salary = 284839309.00,
                    Email = "subash@email.com",
                },
                new Employee
                {
                    FullName = "rakesh kulung",
                    ProfileUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ4lT6c3OEoasZOhpZmzNUMBuE73eW7TBuCgg&usqp=CAU",
                    Salary = 4837487.00,
                    Email = "rakesh@email.com",
                }

            );
            context.SaveChanges();
        }
    }
}