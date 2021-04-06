using System.ComponentModel.DataAnnotations;

namespace Kholupov.Diploma.TodoApp.Models
{
    public class TodoList
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
