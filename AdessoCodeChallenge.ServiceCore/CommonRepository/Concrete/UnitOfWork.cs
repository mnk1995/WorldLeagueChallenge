using AdessoCodeChallenge.ServiceCore.CommonRepository.Abstract;
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

namespace AdessoCodeChallenge.ServiceCore.CommonRepository.Concrete
{
	public class UnitOfWork:IUnitOfWork
	{
		public ICountryRepository Countries { get; }
		public IGroupRepository Groups { get; }
		public ITeamRepository Teams { get; }
		public IWLDrawInfoRepository WLDrawInfos { get; }
		public IWLDrawResultRepository WLDrawResults { get; }

		public UnitOfWork(ICountryRepository countryRepository, IGroupRepository groupRepository, ITeamRepository teamRepository,
			IWLDrawInfoRepository wLDrawInfoRepository, IWLDrawResultRepository wLDrawResultRepository)
		{
			Countries = countryRepository;
			Groups = groupRepository;
			Teams = teamRepository;
			WLDrawInfos = wLDrawInfoRepository;
			WLDrawResults = wLDrawResultRepository;
		}
	}
}
