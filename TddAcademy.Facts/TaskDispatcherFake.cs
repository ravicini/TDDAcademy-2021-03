namespace TddAcademy.Facts
{
	public class TaskDispatcherFake : ITaskDispatcher
	{
		public bool GetTaskWasCalled = false;

		public string GetTask()
		{
			GetTaskWasCalled = true;
			return "task1";
		}

		public void FinishedTask(string task)
		{
			throw new System.NotImplementedException();
		}
	}
}
