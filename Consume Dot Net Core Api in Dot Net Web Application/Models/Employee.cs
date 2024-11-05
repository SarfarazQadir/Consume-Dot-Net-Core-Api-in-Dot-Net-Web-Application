using System.ComponentModel.DataAnnotations;

namespace Consume_Dot_Net_Core_Api_in_Dot_Net_Web_Application.Models
{
    public class Employee
    {
        public int e_Id { get; set; }
        [Required]
        public string e_Name { get; set; }
        [Required]
        public string e_Age { get; set; }
        [Required]
        public string e_City { get; set; }
    }
}
