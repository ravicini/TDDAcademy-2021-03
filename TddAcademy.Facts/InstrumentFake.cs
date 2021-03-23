using System;

namespace TddAcademy.Facts
{
	public class InstrumentFake : IInstrument
	{
		#region Properties

		public string LastExecutedTask { get; set; }

		#endregion

		#region Events

		public event EventHandler<TaskEventArgs> Finished;
		public event EventHandler<TaskEventArgs> Error;

		#endregion

		#region Interface methods

		public void Execute(string task)
		{
			LastExecutedTask = task;
			if(task == null)
				throw new ArgumentNullException();
			else
			{
				var args = new TaskEventArgs(task);
				Finished?.Invoke(this, args);
			}
		}

		#endregion
	}
}
