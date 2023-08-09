using System.ComponentModel.DataAnnotations;

namespace testapp.Models
{
    public class Students
    {
        public int Id { get; set; }
        public required string NationalIDNumber { get; set; }
        public required string  Name { get; set; }
        public required string Surname { get; set; }
        public required string DateofBirth { get; set; }
        public required string StudentNumber { get; set; }
    }
}
