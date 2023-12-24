using AdessoCodeChallenge.DomainCommonCore.CustomClass;
using AdessoCodeChallenge.ServiceCore.CommonRepository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdessoCodeChallenge.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WLDrawResultController : ControllerBase
	{
		private readonly ILogger<WLDrawResultController> logger;
		private readonly IUnitOfWork unitOfWork;

		public WLDrawResultController(ILogger<WLDrawResultController> logger, IUnitOfWork unitOfWork)
		{
			this.logger = logger;
			this.unitOfWork = unitOfWork;
		}


		[HttpGet(Name = "GetLastWorldLeagueGroups")]
		public async Task<IActionResult> GetLastWorldLeagueGroups()
		{
			try
			{
				var result = await unitOfWork.WLDrawResults.GetLastWorldLeagueGroups();
				return new JsonResult(new { success = true, message = "İşlem Başarılı!", dataCount = result.Count, data = result });
			}
			catch (Exception ex)
			{

				logger.LogError($"{DateTime.Now} --- Sistemsel Hata Mesajı: {ex.Message}");
				return new JsonResult(new { success = false, message = ex.Message });
			}
		
		}

		[HttpPost(Name = "SetLastWorldLeagueGroups")]
		public async Task<IActionResult> SetLastWorldLeagueGroups([FromBody] WorldLeagueRequestModel worldLeagueRequestModel)
		{
			try
			{
				var result = await unitOfWork.WLDrawResults.SetWorldLeagueGroups(worldLeagueRequestModel);
				return new JsonResult(new { success = true, message = "İşlem Başarılı!", data = result });
			}
			catch (Exception ex)
			{

				logger.LogError($"{DateTime.Now} --- Sistemsel Hata Mesajı: {ex.Message}");
				return new JsonResult(new { success = false, message = ex.Message });
			}
		}
	}
}
