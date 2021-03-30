using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Surname { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }
        [Required]
        [StringLength(255)]
        public string Position { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
    }
}
