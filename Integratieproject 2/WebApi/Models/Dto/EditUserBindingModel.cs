using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Dto
{
    public class EditUserBindingModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

    }
}