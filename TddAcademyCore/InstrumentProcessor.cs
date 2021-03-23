namespace TddAcademy.Tests
{
	public class InstrumentProcessor : IInstrumentProcessor
	{
		#region Fields

		private ITaskDispatcher _dispatcher;
		private IInstrument _instrument;

		#endregion

		public InstrumentProcessor(ITaskDispatcher dispatcher, IInstrument instrument)
		{
			_dispatcher = dispatcher;
			_instrument = instrument;

			_instrument.Finished += InstrumentOnFinished;
		}

		#region Interface methods

		public void Process()
		{
			string task = _dispatcher.GetTask();
			_instrument.Execute(task);
		}

		#endregion

		private void InstrumentOnFinished(object? sender, TaskEventArgs e)
		{
			_dispatcher.FinishedTask(e.Task);
		}
	}
}
