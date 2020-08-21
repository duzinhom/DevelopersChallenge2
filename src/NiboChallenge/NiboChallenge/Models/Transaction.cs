using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NiboChallenge.Models
{
    public class Transaction
    {
        [Key]
        public int ID { get; set; }
        public string Type { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Value { get; set; }

        public string Memo { get; set; }
    }
}