using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystem1.Models
{
    public class User
    {
        public int Id { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage ="This field is required")]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }
        public string LoginErrorMsg { get; set; }
    }
}
