using AdessoCodeChallenge.DomainCommonCore.CustomClass;
using AdessoCodeChallenge.DomainCommonCore.ResponseResult;
using AdessoCodeChallenge.DomainCore;
using AdessoCodeChallenge.ServiceCore.CommonRepository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoCodeChallenge.ServiceCore.Repository.WLDrawResultRepository
{
	public interface IWLDrawResultRepository : IGenericRepository<WLDrawResult>
	{
		Task<WorldLeagueDrawResult> SetWorldLeagueGroups(WorldLeagueRequestModel worldLeagueRequestModel);

		Task<List<WLDrawResult>> GetLastWorldLeagueGroups();
	}
}
