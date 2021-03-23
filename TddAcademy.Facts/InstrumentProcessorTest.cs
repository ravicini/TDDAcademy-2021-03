using System;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace TddAcademy.Facts
{
	public class InstrumentProcessorTest
	{
		#region Constants

		// todo: TaskDispachterFake FinishedTask(string)

		// todo: InstrumentFake Execute(string) => finished => Eventhandler Finished
		// todo: InstrumentFake Execute(string) => error => Eventhandler Error

		// todo: implement InstrumentProcessor test first

		public const string c_task1 = "task1";

		#endregion

		#region Fields

		private readonly IInstrument _instrumentFake;
		private readonly ITaskDispatcher _taskDispatcherFake;
		private readonly InstrumentProcessor _processor;

		#endregion

		public InstrumentProcessorTest()
		{
			_taskDispatcherFake = A.Fake<ITaskDispatcher>();
			_instrumentFake = A.Fake<IInstrument>();
			_processor = new InstrumentProcessor(_taskDispatcherFake, _instrumentFake);
		}

		[Fact]
		public void DispatcherGetTaskWasCalled()
		{
			var taskDispatcherFake = new TaskDispatcherFake(c_task1);
			var instrumentFake = new InstrumentFake();
			IInstrumentProcessor processor = new InstrumentProcessor(taskDispatcherFake, instrumentFake);

			processor.Process();

			taskDispatcherFake.LastReturnedTask.Should().Be(c_task1);
		}

		[Fact]
		public void InstrumentExecuteWasCalled()
		{
			var taskDispatcherFake = new TaskDispatcherFake(c_task1);
			var instrumentFake = new InstrumentFake();
			IInstrumentProcessor processor = new InstrumentProcessor(taskDispatcherFake, instrumentFake);

			processor.Process();

			instrumentFake.LastExecutedTask.Should().Be(c_task1);
		}

		[Fact]
		public void InstrumentExecuteCalledWithNullThrowsArgumentNullException()
		{
			var taskDispatcherFake = new TaskDispatcherFake(null);
			var instrumentFake = new InstrumentFake();
			IInstrumentProcessor processor = new InstrumentProcessor(taskDispatcherFake, instrumentFake);

			Action action = () => processor.Process();

			action.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void InstrumentFinishedWasCalled()
		{
			var taskDispatcherFake = new TaskDispatcherFake(c_task1);
			var instrumentFake = new InstrumentFake();
			IInstrumentProcessor processor = new InstrumentProcessor(taskDispatcherFake, instrumentFake);

			processor.Process();

			taskDispatcherFake.LastFinishedTask.Should().Be(c_task1);
		}

		[Fact]
		public void DispatcherGetTaskWasCalledFakeItEasy()
		{
			_processor.Process();

			A.CallTo(() => _taskDispatcherFake.GetTask()).MustHaveHappened();
		}

		[Fact]
		public void InstrumentExecuteWasCalledFakeItEasy()
		{
			A.CallTo(() => _taskDispatcherFake.GetTask()).Returns(c_task1);

			_processor.Process();

			A.CallTo(() => _instrumentFake.Execute(c_task1)).MustHaveHappened();
		}

		[Fact]
		public void InstrumentExecuteCalledWithNullThrowsArgumentNullExceptionFakeItEasy()
		{
			A.CallTo(() => _taskDispatcherFake.GetTask()).Returns(null);
			A.CallTo(() => _instrumentFake.Execute(null)).Throws<ArgumentNullException>();

			Action action = () => _processor.Process();

			action.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void InstrumentFinishedWasCalledFakeItEasy()
		{
			_instrumentFake.Finished += Raise.With(new TaskEventArgs(c_task1));

			_processor.Process();

			A.CallTo(() => _taskDispatcherFake.FinishedTask(c_task1)).MustHaveHappened();
		}
	}
}
