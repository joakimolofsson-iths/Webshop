using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class Checkout
	{
		[Required(ErrorMessage = "First name is required")]
		public string? FirstName { get; set; }

		[Required(ErrorMessage = "Last name is required")]
		public string? LastName { get; set; }

		[Required(ErrorMessage = "E-mail address is required")]
		[EmailAddress(ErrorMessage = "Please enter a valid email address.")]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Phone number is required")]
		public string? Phone { get; set; }

		[Required(ErrorMessage = "City is required")]
		public string? City { get; set; }

		[Required(ErrorMessage = "Street address is required")]
		public string? Street { get; set; }

		[Required(ErrorMessage = "ZIP code is required")]
		public string? ZipCode { get; set; }
	}
}
