using AdessoCodeChallenge.DomainCore.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AdessoCodeChallenge.DomainCore
{
	public class Team:Base
	{
		[Required]
		[Column("Name")]
		public string Name { get; set; }

		[ForeignKey("Country")]
		[Required]
		[Column("CountryId")]
		public Guid CountryId { get; set; }

		[Required]
		[Column("IsThereInDraw")]
		public bool IsThereInDraw { get; set; }

		public Country Country { get; set; }
	}
}
