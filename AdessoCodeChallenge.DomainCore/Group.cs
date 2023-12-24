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
	public class Group:Base
	{
		[Required]
		[Column("Name")]
		public string Name { get; set; }
	}
}
