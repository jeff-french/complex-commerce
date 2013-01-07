using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace ComplexCommerce.Models
{
    public class Employee
    {
        [AutoIncrement]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string Title { get; set; }

        [References(typeof(Employee))]
        public int ReportsTo { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [StringLength(70)]
        [Alias("Address")]
        public string Street { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(10)]
        [Alias("PostalCode")]
        public string Zip { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(24)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [StringLength(24)]
        [DataType(DataType.PhoneNumber)]
        public string Fax { get; set; }

        [StringLength(60)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


    }
}