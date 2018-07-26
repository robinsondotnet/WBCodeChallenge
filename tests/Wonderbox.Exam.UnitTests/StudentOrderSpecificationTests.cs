using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Exceptions;
using Wonderbox.Exam.Data;
using Wonderbox.Exam.Data.Models;
using Wonderbox.Exam.Data.Specs;
using Wonderbox.Exam.Infrastructure;
using Xunit;

namespace Wonderbox.Exam.UnitTests
{
    public class StudentOrderSpecificationTests
    {
        private static ISpecification<Student> Specification(string propName, string orderDirection = null)
            => OrderSpecification<Student>.FromPropertyName(propName, orderDirection);

        private static IEnumerable<Student> DataSet => new List<Student>
        {
            new Student{ Id = 1, Enrollmentdate = DateTime.Now,  FirstMidName = "A_Foo", LastName = "Z_Bar"},
            new Student{ Id = 2, Enrollmentdate = DateTime.Now.AddDays(-1),  FirstMidName = "B_Foo", LastName = "X_Bar"},
            new Student{ Id = 3, Enrollmentdate = DateTime.Now.AddDays(6),  FirstMidName = "C_Foo", LastName = "C_Bar"},
        };

        private readonly IQueryable<Student> _projection;

        public StudentOrderSpecificationTests() => _projection = DataSet.AsQueryable();

        [Fact]
        public void ShouldThrowException_WhenNotExistingPropNamePassed()
        {
            var randomPropName = Guid.NewGuid().ToString();

            var spec = Specification(randomPropName, null);

            Assert.Throws<ParseException>(() =>
            {
                var _ = spec.Execute(_projection).First();
            });
        }

        [Fact]
        public void ShouldOrderByPropNameAndAsc_WhenPropNamePassedAndDirectionParamIsNull()
        {
            var spec = Specification(nameof(Student.LastName));

            var sortedFirstStudent = spec.Execute(_projection).First();

            var expectedStudent = DataSet.OrderBy(d => d.LastName).First();

            Assert.Equal(expectedStudent.Id, sortedFirstStudent.Id);
        }

        [Fact]
        public void ShouldOrderByLastNameDesc_WhenSortOrderPassed()
        {
            var spec = Specification(nameof(Student.LastName), Constants.SORT_DESC);

            var sortedFirstStudent = spec.Execute(_projection).First();

            var expectedStudent = DataSet.OrderByDescending(d => d.LastName).First();

            Assert.Equal(expectedStudent.Id, sortedFirstStudent.Id);
        }

        [Fact]
        public void ShouldOrderByEnrollmentDateAsc_WhenSortOrderPassed()
        {
            var spec = Specification(nameof(Student.Enrollmentdate), Constants.SORT_ASC);

            var sortedFirstStudent = spec.Execute(_projection).First();

            var expectedStudent = DataSet.OrderBy(d => d.Enrollmentdate).First();

            Assert.Equal(expectedStudent.Id, sortedFirstStudent.Id);
        }

        [Fact]
        public void ShouldOrderByEnrollmentDateDesc_WhenSortOrderPassed()
        {
            var spec = Specification(nameof(Student.Enrollmentdate), Constants.SORT_DESC);

            var sortedFirstStudent = spec.Execute(_projection).First();

            var expectedStudent = DataSet.OrderByDescending(d => d.Enrollmentdate).First();

            Assert.Equal(expectedStudent.Id, sortedFirstStudent.Id);
        }
    }
}
