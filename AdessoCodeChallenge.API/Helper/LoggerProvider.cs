namespace AdessoCodeChallenge.API.Helper
{
	public class LoggerProvider : ILoggerProvider
	{
		public IWebHostEnvironment _hostingEnvironment;
		public LoggerProvider(IWebHostEnvironment hostingEnvironment)
		{
			_hostingEnvironment = hostingEnvironment;
		}
		public ILogger CreateLogger(string categoryName) => new Logger(_hostingEnvironment);
		public void Dispose() => throw new NotImplementedException();
	}
}
