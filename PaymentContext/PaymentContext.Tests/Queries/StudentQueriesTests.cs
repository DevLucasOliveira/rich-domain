using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace Paymentcontext.Tests
{
    [TestClass]
    public class StudentQueriesTests
    {
        // // Red, Green, Refactor
        private IList<Student> _students;
        private readonly Name _name = new Name("Alu35no", "246345");
        private readonly Document _document = new Document("1115461111111", EDocumentType.CPF);
        private readonly Email _email = new Email("@balt535a.io");

        public StudentQueriesTests()
        {
            _students.Add(new Student(
                _name,
                _document,
                _email
                ));
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345678911");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, studn);
        }


        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("1111111111");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(exp, studn);
        }

    }
}