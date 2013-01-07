using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace ComplexCommerce.Models
{
    public class Customer
    {
        [AutoIncrement]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(80)]
        public string Company { get; set; }

        [StringLength(70)]
        [Alias("Address")]
        public string Street { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(10)]
        [Alias("PostalCode")]
        public string Zip { get; set; }

        [StringLength(24)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [StringLength(24)]
        [DataType(DataType.PhoneNumber)]
        public string Fax { get; set; }

        [Required]
        [StringLength(60)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [References(typeof(Employee))]
        public int SupportRepId { get; set; }
    }
}