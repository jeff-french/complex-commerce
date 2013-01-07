using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ServiceStack.DataAnnotations;

namespace ComplexCommerce.Models
{
    public class InvoiceLine
    {
        [AutoIncrement]
        public int InvoiceLineId { get; set; }

        [Required]
        [References(typeof(Invoice))]
        public int InvoiceId { get; set; }

        [Required]
        [References(typeof(Track))]
        public int TrackId { get; set; }

        [Required]
        [DecimalLength(10,2)]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
