using System.ComponentModel.DataAnnotations;

namespace EmployeeInfo.Model.dto
{
    public class empolyee
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmpCode { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
