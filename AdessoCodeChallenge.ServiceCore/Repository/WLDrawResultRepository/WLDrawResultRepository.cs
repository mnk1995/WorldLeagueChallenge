using AdessoCodeChallenge.DataAccessCore;
using AdessoCodeChallenge.DomainCommonCore.CustomClass;
using AdessoCodeChallenge.DomainCommonCore.ResponseResult;
using AdessoCodeChallenge.DomainCore;
using AdessoCodeChallenge.ServiceCore.CommonRepository.Concrete;
using AdessoCodeChallenge.ServiceCore.Repository.CountryRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoCodeChallenge.ServiceCore.Repository.WLDrawResultRepository
{
	public class WLDrawResultRepository : GenericRepository<WLDrawResult>, IWLDrawResultRepository
	{
		private readonly AdessoCodeChallengeDBContext dBContext;
		public WLDrawResultRepository(AdessoCodeChallengeDBContext dBContext) : base(dBContext)
		{
			this.dBContext = dBContext;
		}

		public async Task<List<WLDrawResult>> GetLastWorldLeagueGroups()
		{
			try
			{
				var lastWLInfo = dBContext.WLDrawInfos.Where(x => x.Year == DateTime.Now.Year.ToString()).OrderByDescending(x => x.DrawCount).Take(1).FirstOrDefault();
				var lastTeamGroupsLst = dBContext.WLDrawResults.Where(x => x.WLDInfoId == lastWLInfo.Id).Include(x=>x.WLDrawInfo).Include(x=>x.Group).Include(x=>x.Team).AsNoTracking().ToList();
				return lastTeamGroupsLst;
			}
			catch (Exception)
			{

				return null;
			}
		}

		public async Task<WorldLeagueDrawResult> SetWorldLeagueGroups(WorldLeagueRequestModel worldLeagueRequestModel)
		{
			var resultModel = new WorldLeagueDrawResult();
			var transaction = dBContext.Database.BeginTransaction();
			var rnd = new Random();
			try
			{
				if (worldLeagueRequestModel.GroupCount != 4 && worldLeagueRequestModel.GroupCount != 8)
				{
					resultModel.Success = false;
					resultModel.Message = "Group Count Should be 4 or 8";
				}

				var WLDrawInfoModel = new WLDrawInfo();

				var checkLastDrawInfo = dBContext.WLDrawInfos.Where(x => x.Year == DateTime.Now.Year.ToString()).Count();
				WLDrawInfoModel.Year = DateTime.Now.Year.ToString();
				WLDrawInfoModel.DrawCount = checkLastDrawInfo + 1;
				WLDrawInfoModel.DrawPlace = worldLeagueRequestModel.DrawPlace;
				WLDrawInfoModel.Drawer = worldLeagueRequestModel.Drawer;
				WLDrawInfoModel.GroupCount = worldLeagueRequestModel.GroupCount;

				var addedWLDrawInfoEntity = await dBContext.WLDrawInfos.AddAsync(WLDrawInfoModel);
				await dBContext.SaveChangesAsAsync();

				Dictionary<string, List<string>> countryAndTeams = new Dictionary<string, List<string>>
				{
					{"Türkiye", new List<string>{"Adesso İstanbul", "Adesso Ankara", "Adesso İzmir", "Adesso Antalya"}},
					{"Almanya", new List<string>{"Adesso Berlin", "Adesso Frankfurt", "Adesso Münih", "Adesso Dortmund"}},
					{"Fransa", new List<string>{"Adesso Paris", "Adesso Marsilya", "Adesso Nice", "Adesso Lyon"}},
					{"Hollanda", new List<string>{"Adesso Amsterdam", "Adesso Rotterdam", "Adesso Lahey", "Adesso Eindhoven"}},
					{"Portekiz", new List<string>{"Adesso Lisbon", "Adesso Porto", "Adesso Braga", "Adesso Coimbra"}},
					{"İtalya", new List<string>{"Adesso Roma", "Adesso Milano", "Adesso Venedik", "Adesso Napoli"}},
					{"İspanya", new List<string>{"Adesso Sevilla", "Adesso Madrid", "Adesso Barselona", "Adesso Granada"}},
					{"Belçika", new List<string>{"Adesso Brüksel", "Adesso Brugge", "Adesso Gent", "Adesso Anvers"}}
				};

				List<string> groups = worldLeagueRequestModel.GroupCount == 4 ? new List<string> { "A", "B", "C", "D" } : new List<string> { "A", "B", "C", "D", "E", "F", "G", "H" };
				Dictionary<string, List<string>> groupsAndTeams = new Dictionary<string, List<string>>();

				foreach (var group in groups)
				{
					List<string> selectedTeams = new List<string>();

					foreach (var country in countryAndTeams.Keys)
					{
						var availableTeams = countryAndTeams[country].Except(selectedTeams).ToList();

						if (availableTeams.Any())
						{
							var randomSelectedTeam = availableTeams[new Random().Next(availableTeams.Count)];
							selectedTeams.Add(randomSelectedTeam);

							var wlDrawResultModel = new WLDrawResult();
							wlDrawResultModel.WLDInfoId = addedWLDrawInfoEntity.Entity.Id;
							wlDrawResultModel.GroupId = dBContext.Groups.FirstOrDefault(x => x.Name == group).Id;
							wlDrawResultModel.TeamId = dBContext.Teams.FirstOrDefault(x => x.Name == randomSelectedTeam).Id;
							
							await dBContext.WLDrawResults.AddAsync(wlDrawResultModel);
							await dBContext.SaveChangesAsAsync();
						}
					}
					groupsAndTeams.Add(group, selectedTeams);
				}

				resultModel.Success = true;
				resultModel.Message = "Operation of Group Draw is succesfull";
				resultModel.Drawer = worldLeagueRequestModel.Drawer;
				resultModel.DrawYear = DateTime.Now.Year.ToString();
				resultModel.DrawPlace = worldLeagueRequestModel.DrawPlace;
				resultModel.GroupCount = worldLeagueRequestModel.GroupCount;
				resultModel.GroupTeams = groupsAndTeams;

				transaction.Commit();
			}
			catch (Exception ex)
			{
				transaction.Rollback();
				resultModel.Success = false;
				resultModel.Message = ex.Message;
			}
			return resultModel;
		}
	}
}
