using System;

namespace TddAcademy.Facts
{
	public class InstrumentFake : IInstrument
	{
		public event EventHandler<TaskEventArgs> Finished;
		public event EventHandler<TaskEventArgs> Error;

		public bool ExecuteWasCalled = false;

		public void Execute(string task)
		{
			ExecuteWasCalled = true;
		}
	}
}
