using AdessoCodeChallenge.ServiceCore.CommonRepository.Abstract;
using AdessoCodeChallenge.ServiceCore.CommonRepository.Concrete;
using AdessoCodeChallenge.ServiceCore.Repository.CountryRepository;
using AdessoCodeChallenge.ServiceCore.Repository.GroupRepository;
using AdessoCodeChallenge.ServiceCore.Repository.TeamRepository;
using AdessoCodeChallenge.ServiceCore.Repository.WLDrawInfoRepository;
using AdessoCodeChallenge.ServiceCore.Repository.WLDrawResultRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoCodeChallenge.ServiceCore
{
	public static class ServiceRegistration
	{
		public static void AddInfrastructure(this IServiceCollection services)
		{
			services.AddTransient<ICountryRepository, CountryRepository>();
			services.AddTransient<IGroupRepository, GroupRepository>();
			services.AddTransient<ITeamRepository, TeamRepository>();
			services.AddTransient<IWLDrawInfoRepository, WLDrawInfoRepository>();
			services.AddTransient<IWLDrawResultRepository, WLDrawResultRepository>();
			services.AddTransient<IUnitOfWork, UnitOfWork>();
		}
	}
}
