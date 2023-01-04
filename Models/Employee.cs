using System.ComponentModel.DataAnnotations;

namespace EmployeeInfo.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "FullName is required")]
    [StringLength(maximumLength: 20, ErrorMessage = "Name should be less than 20 characters")]
    [Display(Name = "Full Name")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Profile Image is Required")]
    [Display(Name = "Profile Picture")]
    public string ProfileUrl { get; set; }

    [Required(ErrorMessage = "Salary is Required")]
    [Display(Name = "Salary")]
    public double Salary { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "This field must be email address")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Display(Name = "Created At")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}