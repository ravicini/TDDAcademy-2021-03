using System;
using FluentAssertions;
using Xunit;

namespace TddAcademy.Tests
{
	public class InstrumentProcessorManualTest
	{
		#region Fields

		private readonly DispatcherFake _dispatcher;
		private readonly InstrumentFake _instrument;
		private readonly LoggerFake _logger;
		private readonly InstrumentProcessor _testee;

		#endregion

		public InstrumentProcessorManualTest()
		{
			_dispatcher = new DispatcherFake();
			_instrument = new InstrumentFake();
			_logger = new LoggerFake();
			_testee = new InstrumentProcessor(_dispatcher, _instrument, _logger);
		}

		[Fact]
		public void InstrumentProcessor_DispatcherGetTaskWasCalled()
		{
			_dispatcher.SetNextTaskName("TestTask");

			_testee.Process();

			_dispatcher.GetTaskWasCalled.Should().BeTrue();
		}

		[Fact]
		public void InstrumentProcessor_InstrumentExecuteCorrectTask()
		{
			var taskName = "Supertask";
			_dispatcher.SetNextTaskName(taskName);

			_testee.Process();

			_instrument.ExecutingTask.Should().Be(taskName);
		}

		[Fact]
		public void InstrumentProcessor_InstrumentWithNullTaskName_ThrowsException()
		{
			Action act = () =>
			{
				_testee.Process();
			};

			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void InstrumentProcessor_Instrument_ShouldThrowFinishedEvent()
		{
			var taskName = "Supertask";
			_dispatcher.SetNextTaskName(taskName);

			_instrument.RaiseFinishedEvent(taskName);

			_dispatcher.FinishedEventTaskName.Should().Be(taskName);
		}

		[Fact]
		public void InstrumentProcessor_Instrument_ShouldThrowErrorEvent()
		{
			var taskName = "Supertask";
			_dispatcher.SetNextTaskName(taskName);

			_instrument.RaiseErrorEvent(taskName);

			_instrument.ErrorEventWasCalled.Should().BeTrue();
			_logger.LoggedText.Should().Be("Error occurred");
		}
	}

	public class LoggerFake : ILogger
	{
		#region Properties

		public string LoggedText { get; private set; }

		#endregion

		#region Interface methods

		public void Log(string text)
		{
			LoggedText = text;
		}

		#endregion
	}

	public class InstrumentFake : IInstrument
	{
		#region Properties

		public string ExecutingTask { get; private set; }
		public bool ErrorEventWasCalled { get; private set; }

		#endregion

		#region Events

		public event EventHandler<TaskEventArgs> Finished;
		public event EventHandler<TaskEventArgs> Error;

		#endregion

		#region Interface methods

		public void Execute(string task)
		{
			if(task == null)
				throw new ArgumentNullException(nameof(task));

			ExecutingTask = task;
		}

		#endregion

		public void RaiseFinishedEvent(string taskName)
		{
			if(Finished != null)
				Finished(this, new TaskEventArgs(taskName));
		}

		public void RaiseErrorEvent(string taskName)
		{
			if(Error != null)
			{
				Error(this, new TaskEventArgs(taskName));
				ErrorEventWasCalled = true;
			}
		}
	}

	public class DispatcherFake : ITaskDispatcher
	{
		#region Fields

		private string _taskName;

		#endregion

		#region Properties

		public bool GetTaskWasCalled { get; private set; }
		public string FinishedEventTaskName { get; private set; }

		#endregion

		#region Interface methods

		public string GetTask()
		{
			GetTaskWasCalled = true;
			return _taskName;
		}

		public void FinishedTask(string task)
		{
			FinishedEventTaskName = task;
		}

		#endregion

		public void SetNextTaskName(string taskName)
		{
			_taskName = taskName;
		}
	}
}
