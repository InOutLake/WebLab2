using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weblab2.Models.ViewModels
{
    public class StudentVM
    {
        [Key]
        public Guid StudentId { get; set; }
        [Required]
        [DisplayName("Last name")]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = null!;
        [Required]
        [DisplayName("First name")]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;
        [Required]
        [DisplayName("Middle name")]
        [StringLength(100, MinimumLength = 2)]
        public string MiddleName { get; set; } = null!;
        [Required]
        [Range(0, 1)]
        public int Gender { get; set; }
        [Required]
        [StringLength(150)]
        public string Address { get; set; } = null!;
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public string EnglishLevel { get; set; } = null!;

        public virtual ICollection<GradeSheet> GradeSheets { get; set; } = new List<GradeSheet>();

        public virtual ICollection<StudentInGroup> StudentInGroups { get; set; } = new List<StudentInGroup>();
    }
}
