using System.ComponentModel.DataAnnotations;

namespace Management.Web.Models
{
    public class MyControlTypeVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Default Number Of Days")]
        public int DefaultDays { get; set; }
    }
}
