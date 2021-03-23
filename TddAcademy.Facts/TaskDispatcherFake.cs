namespace TddAcademy.Facts
{
	public class TaskDispatcherFake : ITaskDispatcher
	{
		#region Fields

		public string LastReturnedTask = "";
		private readonly string _task;

		#endregion

		#region Properties

		public string LastFinishedTask { get; set; }

		#endregion

		public TaskDispatcherFake(string task)
		{
			_task = task;
		}

		#region Interface methods

		public string GetTask()
		{
			LastReturnedTask = _task;
			return _task;
		}

		public void FinishedTask(string task)
		{
			LastFinishedTask = task;
		}

		#endregion
	}
}
