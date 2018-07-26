using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Wonderbox.Exam.ViewModels
{
    //TODO: We are not applying inheritance for this class because we are not exposing anything about instructors. 
    public class StudentVM
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("FirstName")]
        [MaxLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstMidName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}
