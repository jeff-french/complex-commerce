using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace ComplexCommerce.Models
{
    public class Invoice
    {
        [AutoIncrement]
        public int InvoiceId { get; set; }

        [Required]
        [References(typeof(Customer))]
        public int CustomerId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }

        [StringLength(70)]
        [Alias("BillingAddress")]
        public string BillingStreet { get; set; }

        [StringLength(40)]
        public string BillingCity { get; set; }

        [StringLength(40)]
        public string BillingState { get; set; }

        [StringLength(40)]
        public string BillingCountry { get; set; }

        [StringLength(10)]
        [Alias("BillingPostalCode")]
        public string BillingZip { get; set; }

        [Required]
        [DecimalLength(10,2)]
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

    }
}