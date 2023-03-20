using System;
using PtoApp.Models;

namespace PtoApp.DTOs
{
	public class PaidTimeOffDTO
	{
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public PtoType? Type { get; set; }
        public DateTime PtoDate { get; set; }
    }
}

