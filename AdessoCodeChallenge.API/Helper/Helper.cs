namespace AdessoCodeChallenge.API.Helper
{
	public class Logger : ILogger
	{
		IWebHostEnvironment _hostingEnvironment;
		public Logger(IWebHostEnvironment hostingEnvironment) => _hostingEnvironment = hostingEnvironment;
		public IDisposable BeginScope<TState>(TState state) => null;
		public bool IsEnabled(LogLevel logLevel) => true;
		public async void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			using (StreamWriter streamWriter = new StreamWriter($"{_hostingEnvironment.ContentRootPath}/log.txt", true))
			{
				await streamWriter.WriteLineAsync($"Log Level : {logLevel.ToString()} | Event ID : {eventId.Id} | Event Name : {eventId.Name} | Formatter : {formatter(state, exception)} | Time of Process : {DateTime.Now}");
				streamWriter.Close();
				await streamWriter.DisposeAsync();
			}
		}
	}
}
