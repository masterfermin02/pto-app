using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PtoApp.Models
{
	public class PaidTimeOff
	{
        [Key]
        [ForeignKey("Type")]
        public long Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
		public long Type { get; set; }
        [Required]
		public DateTime PtoDate { get; set; }

        public virtual PtoType? PtoType { get; set; } 
	}
}

