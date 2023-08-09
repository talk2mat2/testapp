using System.ComponentModel.DataAnnotations;

namespace testapp.Dtos
{
    public class TeachetsDto
    {
        public required string NationalIDnumber { get; set; }

        [RegularExpression("Mr|Mrs|Miss|Dr|Prof", ErrorMessage = "Invalid Title supplied")]
        public required string Title { get; set; }
        public required string Name { get; set; }

        public required string Surname { get; set; }
        public required string DateOfBirth { get; set; }

        public required string TeacherNumber { get; set; }

        public required Double Salary { get; set; }
    }
}
