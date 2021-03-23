using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace TddAcademy.Tests
{
	public class InstrumentProcessorAutomaticTest
	{
		#region Constants

		private const string c_taskName = "taskName";

		#endregion

		#region Fields

		private readonly Mock<ITaskDispatcher> _dispatcher;
		private readonly Mock<IInstrument> _instrument;
		private readonly Mock<ILogger> _logger;
		private readonly InstrumentProcessor _testee;

		#endregion

		public InstrumentProcessorAutomaticTest()
		{
			_dispatcher = new Mock<ITaskDispatcher>();
			_dispatcher.Setup(s => s.GetTask()).Returns(c_taskName);
			_instrument = new Mock<IInstrument>();
			_instrument.Setup(s => s.Execute(It.IsAny<string>())).Callback<string>(taskName =>
			{
				if(taskName == null)
					throw new ArgumentNullException(nameof(taskName));
			});
			_logger = new Mock<ILogger>();
			_testee = new InstrumentProcessor(_dispatcher.Object, _instrument.Object, _logger.Object);
		}

		[Fact]
		public void InstrumentProcessor_DispatcherGetTaskWasCalled()
		{
			_testee.Process();

			_dispatcher.Verify(s => s.GetTask(), Times.Once);
		}

		[Fact]
		public void InstrumentProcessor_InstrumentExecuteCorrectTask()
		{
			_testee.Process();

			//_instrument.Verify(s => s.Execute(It.Is<string>(mo => mo == c_taskName)), Times.Once);
			_instrument.Verify(s => s.Execute(c_taskName), Times.Once);
		}

		[Fact]
		public void InstrumentProcessor_InstrumentWithNullTaskName_ThrowsException()
		{
			_dispatcher.Setup(s => s.GetTask()).Returns<string>(null);

			Action act = () =>
			{
				_testee.Process();
			};

			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void InstrumentProcessor_Instrument_ShouldThrowFinishedEvent()
		{
			_instrument.Raise(r => r.Finished += null, new TaskEventArgs(c_taskName));
			
			//_dispatcher.Verify(s => s.FinishedTask(It.Is<string>(mo => mo == c_taskName)), Times.Once());
			_dispatcher.Verify(s => s.FinishedTask(c_taskName), Times.Once());
		}

		[Fact]
		public void InstrumentProcessor_Instrument_ShouldThrowErrorEvent()
		{
			_instrument.Raise(r => r.Error += null, new TaskEventArgs(c_taskName));

			_logger.Verify(s => s.Log("Error occurred"), Times.Once());
		}
	}
}
