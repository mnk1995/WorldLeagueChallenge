using AdessoCodeChallenge.DataAccessCore;
using AdessoCodeChallenge.DomainCore;
using AdessoCodeChallenge.ServiceCore.CommonRepository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoCodeChallenge.ServiceCore.Repository.TeamRepository
{
	public class TeamRepository : GenericRepository<Team>, ITeamRepository
	{
		public TeamRepository(AdessoCodeChallengeDBContext dBContext) : base(dBContext)
		{

		}
	}
}
