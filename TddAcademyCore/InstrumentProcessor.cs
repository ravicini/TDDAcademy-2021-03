namespace TddAcademy.Tests
{
	public class InstrumentProcessor : IInstrumentProcessor
	{
		#region Fields

		private readonly ITaskDispatcher _dispatcher;
		private readonly IInstrument _instrument;
		private readonly ILogger _logger;

		#endregion

		public InstrumentProcessor(ITaskDispatcher dispatcher, IInstrument instrument, ILogger logger)
		{
			_dispatcher = dispatcher;
			_instrument = instrument;
			_logger = logger;
			_instrument.Finished += InstrumentOnFinished;
			_instrument.Error += InstrumentOnError;
		}

		#region Interface methods

		public void Process()
		{
			var task = _dispatcher.GetTask();
			_instrument.Execute(task);
		}

		#endregion

		private void InstrumentOnError(object? sender, TaskEventArgs e)
		{
			_logger.Log("Error occurred");
		}

		private void InstrumentOnFinished(object? sender, TaskEventArgs e)
		{
			_dispatcher.FinishedTask(e.Task);
		}
	}
}
