using System;
using FluentAssertions;
using Xunit;

namespace TddAcademy.Facts
{
    public class InstrumentProcessorTest
    {
		// todo: TaskDispachterFake FinishedTask(string)

        // todo: InstrumentFake Execute(string) => string ==null => ArgumentNullException
		// todo: InstrumentFake Execute(string) => finished => Eventhandler Finished
		// todo: InstrumentFake Execute(string) => error => Eventhandler Error

        // todo: implement InstrumentProcessor test first

		public const string c_task1 = "task1";

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

			Action action = ()=> processor.Process();

			action.Should().Throw<ArgumentNullException>();
		}
	}
}