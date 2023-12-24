using AdessoCodeChallenge.ServiceCore.Repository.CountryRepository;
using AdessoCodeChallenge.ServiceCore.Repository.GroupRepository;
using AdessoCodeChallenge.ServiceCore.Repository.TeamRepository;
using AdessoCodeChallenge.ServiceCore.Repository.WLDrawInfoRepository;
using AdessoCodeChallenge.ServiceCore.Repository.WLDrawResultRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoCodeChallenge.ServiceCore.CommonRepository.Abstract
{
	public interface IUnitOfWork
	{
		ICountryRepository Countries { get; }
		IGroupRepository Groups { get; }
		ITeamRepository Teams { get; }
		IWLDrawInfoRepository WLDrawInfos { get; }
		IWLDrawResultRepository WLDrawResults { get; }
	}
}
