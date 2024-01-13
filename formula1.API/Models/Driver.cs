
using System.ComponentModel.DataAnnotations;

namespace formula1.API.Models
{
    public class Driver
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "DriverNumber is required")]
        public string DriverNumber { get; set; }

        [Required(ErrorMessage = "Team is required")]
        public string Team { get; set; }

    }
}
