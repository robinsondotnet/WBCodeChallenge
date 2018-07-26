using System;
using System.Collections.Generic;
using System.Linq;
using Wonderbox.Exam.Data.Models;
using Wonderbox.Exam.Data.Specs;
using Wonderbox.Exam.Infrastructure;
using Xunit;

namespace Wonderbox.Exam.UnitTests
{
    public class StudentSearchTextSpecificationTests
    {
        private static ISpecification<Student> Specification(string searchText) =>
            new StudentSearchTextSpecification(searchText);

        private static IEnumerable<Student> DataSet => new List<Student>
        {
            new Student{ Id = 1, Enrollmentdate = DateTime.Now,  FirstMidName = "A_Foo", LastName = "Z_Bar"},
            new Student{ Id = 2, Enrollmentdate = DateTime.Now.AddDays(-1),  FirstMidName = "B_Foo", LastName = "X_Bar"},
            new Student{ Id = 3, Enrollmentdate = DateTime.Now.AddDays(6),  FirstMidName = "C_Foo", LastName = "C_Bar"},
        };

        private readonly IQueryable<Student> _projection;

        public StudentSearchTextSpecificationTests() => _projection = DataSet.AsQueryable();

        [Fact]
        public void ShouldReturnEmptyList_WhenSearchStringIsNotFound()
        {
            var randomSearchText = Guid.NewGuid().ToString();

            var rerievedStudents = Specification(randomSearchText).Execute(_projection).ToList();

            Assert.Empty(rerievedStudents);
        }

        [Fact]
        public void ShouldReturnMatchedCriteria_WithCaseInsensitiveCriteria()
        {

            var expectedStudent = DataSet.Last();
            var searchText = expectedStudent.LastName.ToUpper();

            var rerievedStudents = Specification(searchText).Execute(_projection).ToList();

            Assert.Contains(rerievedStudents, student => student.Id.Equals(expectedStudent.Id));
            Assert.NotEmpty(rerievedStudents);
        }
    }
}
