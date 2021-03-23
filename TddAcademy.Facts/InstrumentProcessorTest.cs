using System;
using FluentAssertions;
using Xunit;

namespace TddAcademy.Tests
{
	public class InstrumentProcessorTest
	{
		// todo: implement InstrumentProcessor test first 

		[Fact]
		public void GetTaskFromDispatcher()
		{
			string taskName = "Task1";

			FakeTaskDispatcher fakeDispatcher = new FakeTaskDispatcher(taskName);
			IInstrument fakeInstrument = new FakeInstrument();

			IInstrumentProcessor testee = new InstrumentProcessor(fakeDispatcher, fakeInstrument);

			testee.Process();

			fakeDispatcher.ExecutedTask.Should().Be(taskName);
		}

		[Fact]
		public void InstrumentSchouldThrowException()
		{
			string taskName = "Exception1";

			FakeTaskDispatcher fakeDispatcher = new FakeTaskDispatcher(taskName);
			IInstrument fakeInstrument = new FakeInstrument();

			IInstrumentProcessor testee = new InstrumentProcessor(fakeDispatcher, fakeInstrument);

			Action act = () => testee.Process();

			act.Should().Throw<Exception>()
			   .WithMessage("Exception in fakeInstrument");
		}
	}

	internal class FakeInstrument : IInstrument
	{
		#region Events

		public event EventHandler<TaskEventArgs> Finished;
		public event EventHandler<TaskEventArgs> Error;

		#endregion

		#region Interface methods

		public void Execute(string task)
		{
			if(task.Contains("Exception1"))
				throw new Exception("Exception in fakeInstrument");
			else
				Finished.Invoke(this, new TaskEventArgs(task));
		}

		#endregion
	}

	internal class FakeTaskDispatcher : ITaskDispatcher
	{
		#region Fields

		private readonly string _taskName;
		private string _executedTask;

		#endregion

		#region Properties

		public string ExecutedTask => _executedTask;

		#endregion

		public FakeTaskDispatcher(string taskName)
		{
			_taskName = taskName;
		}

		#region Interface methods

		public void FinishedTask(string task)
		{
			_executedTask = task;
		}

		public string GetTask()
		{
			return _taskName;
		}

		#endregion
	}
}
