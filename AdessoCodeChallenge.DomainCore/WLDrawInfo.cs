using AdessoCodeChallenge.DomainCore.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoCodeChallenge.DomainCore
{
	public class WLDrawInfo:Base
	{
		[Required]
		[Column("Year")]
		public string Year { get; set; }

		[Required]
		[Column("DrawCount")]
		public int DrawCount { get; set; }

		[Required]
		[Column("DrawPlace")]
		public string DrawPlace { get; set; }

		[Required]
		[Column("Drawer")]
		public string Drawer { get; set; }

		[Required]
		[Column("GroupCount")]
		public int GroupCount { get; set; }
	}
}
