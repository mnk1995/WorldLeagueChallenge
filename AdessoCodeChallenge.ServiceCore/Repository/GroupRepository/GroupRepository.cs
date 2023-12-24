using AdessoCodeChallenge.DataAccessCore;
using AdessoCodeChallenge.DomainCore;
using AdessoCodeChallenge.ServiceCore.CommonRepository.Concrete;
using AdessoCodeChallenge.ServiceCore.Repository.CountryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoCodeChallenge.ServiceCore.Repository.GroupRepository
{
	public class GroupRepository : GenericRepository<Group>, IGroupRepository
	{
		public GroupRepository(AdessoCodeChallengeDBContext dBContext) : base(dBContext)
		{

		}
	}
}
