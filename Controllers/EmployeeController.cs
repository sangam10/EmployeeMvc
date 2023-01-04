
using EmployeeInfo.Data;
using EmployeeInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInfo.Controllers;

public class EmployeeController : Controller
{
    private readonly EmployeeContext _context;

    public EmployeeController(EmployeeContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var employees = _context.Employees.OrderByDescending(m => m.Id).ToList();
        return View(employees);
    }
    public IActionResult Create()
    {
        return View();
    }
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var employee = _context.Employees.FirstOrDefault(m => m.Id == id);
        return View(employee);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id", "ProfileUrl", "FullName", "Salary", "Email")] Employee employee)
    {
        if (ModelState.IsValid)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            TempData["success"] = "Employee Created Successfully!!";
        }
        else
        {
            TempData["error"] = "Failed to Create!!";
            return View(employee);
        }
        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        Console.WriteLine("post delete");
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        try
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            TempData["success"] = "Employee deleted Successfully!!";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {
            Console.Write("error is =>" + e);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id", "ProfileUrl", "FullName", "Salary", "Email")] Employee employee)
    {

        if (id != employee.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                TempData["success"] = "successfully updated";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine("error is :" + e);
                TempData["error"] = "Failed to update";
            }
        }
        return View(employee);
    }
}