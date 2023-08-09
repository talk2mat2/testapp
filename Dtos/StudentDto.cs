using System.ComponentModel.DataAnnotations;

namespace testapp.Dtos
{
    public class StudentDto
    {
        public required string NationalIDNumber { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string DateofBirth { get; set; }
        public required string StudentNumber { get; set; }

    }
}
