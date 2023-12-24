using AdessoCodeChallenge.DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoCodeChallenge.DomainCommonCore.ResponseResult
{
	public class Result
	{
		public bool Success { get; set; }

		public string Message { get; set; }
	}

	public class Result<T> : Result
	{
		public T Data { get; set; }

		public List<T> DataList { get; set; }

	}

	public class WorldLeagueDrawResult : Result
	{
		public string DrawYear { get; set; }
		public string DrawPlace { get; set; }
		public string Drawer { get; set; }
		public int GroupCount { get; set; }
		public Group[] Groups { get; set; }

		public Dictionary<string, List<string>> GroupTeams { get; set; }
	}

	public class Group
	{
      public string GroupName { get; set; }
      public Team[] Teams { get; set; }
    }

	public class Team
	{
        public string Name { get; set; }
    }
}
