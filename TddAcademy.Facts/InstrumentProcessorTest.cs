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

		[Fact]
		public void DispatcherGetTaskWasCalled()
		{
			var taskDispatcherFake = new TaskDispatcherFake();
			var instrumentFake = new InstrumentFake();
			IInstrumentProcessor processor = new InstrumentProcessor(taskDispatcherFake, instrumentFake);

			processor.Process();

			taskDispatcherFake.GetTaskWasCalled.Should().BeTrue();
		}

		[Fact]
		public void InstrumentExecuteWasCalled()
		{
			var taskDispatcherFake = new TaskDispatcherFake();
			var instrumentFake = new InstrumentFake();
			IInstrumentProcessor processor = new InstrumentProcessor(taskDispatcherFake, instrumentFake);

			processor.Process();

			instrumentFake.ExecuteWasCalled.Should().BeTrue();
		}
	}
}