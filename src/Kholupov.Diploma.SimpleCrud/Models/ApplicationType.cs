using System.ComponentModel.DataAnnotations;

namespace Kholupov.Diploma.SimpleCrud.Models
{
    public class ApplicationType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
