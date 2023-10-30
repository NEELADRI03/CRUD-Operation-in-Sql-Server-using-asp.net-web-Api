using System.ComponentModel.DataAnnotations;

namespace SqlApiDemo.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(255)]
        public string Location { get; set; }

    }
}
