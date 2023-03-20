using System;
using System.ComponentModel.DataAnnotations;

namespace PtoApp.Models
{
	public class PtoType
	{
		public long Id { get; set; }
		[Required]
		public string? Description { get; set; }

		public virtual ICollection<PaidTimeOff>? PaidTimeOffs { get; set; }
    }
}

