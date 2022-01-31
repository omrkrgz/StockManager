using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockManager.Entities
{
    public class Stocks
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [StringLength(50)]
        public string VariantCode { get; set; }

        [StringLength(100)]
        public string ProductCode { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}