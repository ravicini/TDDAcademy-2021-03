namespace TddAcademy
{
	public class InstrumentProcessor : IInstrumentProcessor
	{
		#region Fields

		private readonly ITaskDispatcher _taskDispatcher;
		private readonly IInstrument _instrument;

		#endregion

		public InstrumentProcessor(ITaskDispatcher taskDispatcher, IInstrument instrument)
		{
			_taskDispatcher = taskDispatcher;
			_instrument = instrument;
			_instrument.Finished += OnFinished;
		}

		#region Interface methods

		public void Process()
		{
			var task = _taskDispatcher.GetTask();
			_instrument.Execute(task);
		}

		#endregion

		private void OnFinished(object o, TaskEventArgs args)
		{
			_taskDispatcher.FinishedTask(args.Task);
		}
	}
}
