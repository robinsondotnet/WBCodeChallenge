using Wonderbox.Exam.Infrastructure;

namespace Wonderbox.Exam.Data.Models
{
    public class Person : IModel
    {
        public int Id { get; set; }

        public string FirstMidName { get; set; }

        public string LastName { get; set; }    
    }
}
