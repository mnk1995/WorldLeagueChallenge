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
	public class WLDrawResult:Base
	{
		[ForeignKey("WLDrawInfo")]
		[Required]
		[Column("WLDInfoId")]
		public Guid WLDInfoId { get; set; }

		[ForeignKey("Group")]
		[Required]
		[Column("GroupId")]
		public Guid GroupId { get; set; }

		[ForeignKey("Team")]
		[Required]
		[Column("TeamId")]
		public Guid TeamId { get; set; }


		public WLDrawInfo WLDrawInfo { get; set; }
		public Group Group { get; set; }
		public Team Team { get; set; }
	}
}
