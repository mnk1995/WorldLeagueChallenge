using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoCodeChallenge.DomainCommonCore.CustomClass
{
	public class WorldLeagueRequestModel
	{
		[Required]
		public int GroupCount { get; set; }
		[Required]
		public string DrawPlace { get; set; }
		[Required]
		public string Drawer { get; set; }
	}
}
