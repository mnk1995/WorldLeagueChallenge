using AdessoCodeChallenge.DomainCommonCore.CustomClass;

namespace AdessoCodeChallenge.API.Helper
{
	public class LogProviderHelper
	{
		public static ILogger<Type> GetValue()
		{
			var lf = LogProvider.LogFactoryValue.CreateLogger<Type>();
			return lf;
		}
	}
}
