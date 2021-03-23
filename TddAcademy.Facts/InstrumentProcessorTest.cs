using System;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace TddAcademy.Tests
{
    public class InstrumentProcessorTest
    {
        private readonly FakeInstrument _fakeInstrument;
        private readonly FakeConsoleLogger _fakeConsoleLogger;
        private readonly FakeTaskDispatcher _fakeTaskDispatcher;
        private readonly IInstrument _instrumentFake;
        private readonly ITaskDispatcher _taskDispatcherFake;
        private readonly IConsoleLogger _consoleLogger;

        public InstrumentProcessorTest()
        {
            _fakeInstrument = new FakeInstrument();
            _fakeConsoleLogger = new FakeConsoleLogger();
            _fakeTaskDispatcher = new FakeTaskDispatcher();

            _instrumentFake = A.Fake<IInstrument>();
            _taskDispatcherFake = A.Fake<ITaskDispatcher>();
            _consoleLogger = A.Fake<IConsoleLogger>();
        }

        [Fact]
        public void it_executes_error_event_handler()
        {
            var instrumentProcessor = new InstrumentProcessor(_fakeInstrument, _fakeTaskDispatcher, _fakeConsoleLogger);

            instrumentProcessor.Process();
            
            _fakeInstrument.TriggerErrorEvent();

            _fakeConsoleLogger.LoggedToConsole.Should().BeTrue();
        }

        [Fact]
        public void it_successfully_finishes_a_task_async()
        {
            var instrumentProcessor = new InstrumentProcessor(_fakeInstrument, _fakeTaskDispatcher, _fakeConsoleLogger);

            instrumentProcessor.Process();

            _fakeInstrument.TriggerFinishedEvent();

            _fakeTaskDispatcher.FinishedTaskExecuted.Should().BeTrue();
        }

        [Fact]
        public void it_executes_finished_event_handler()
        {
            var instrumentProcessor = new InstrumentProcessor(_instrumentFake, _taskDispatcherFake, _consoleLogger);

            A.CallTo(() => _taskDispatcherFake.GetTask()).Returns("exampleTask");

            _instrumentFake.Finished += Raise.With(new TaskEventArgs("exampleTask"));

            A.CallTo(() => _taskDispatcherFake.FinishedTask(A<string>._)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void it_executes_new_task()
        {
            var instrumentProcessor = new InstrumentProcessor(_instrumentFake, _taskDispatcherFake, _consoleLogger);

            A.CallTo(() => _taskDispatcherFake.GetTask()).Returns("exampleTask");

            instrumentProcessor.Process();

            A.CallTo(() => _instrumentFake.Execute("exampleTask")).MustHaveHappenedOnceExactly();
            A.CallTo(() => _instrumentFake.Execute(A<string>._)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void it_throws_error_on_null_argument()
        {
            var instrumentProcessor = new InstrumentProcessor(_instrumentFake, _taskDispatcherFake, _consoleLogger);

            A.CallTo(() => _taskDispatcherFake.GetTask()).Returns(null);
            A.CallTo(() => _instrumentFake.Execute(A<string>._)).Throws(new ArgumentNullException());

            Action act = () => instrumentProcessor.Process();
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void it_writes_on_console_on_error()
        {
            var instrumentProcessor = new InstrumentProcessor(_instrumentFake, _taskDispatcherFake, _consoleLogger);

            A.CallTo(() => _taskDispatcherFake.GetTask()).Returns("exampleTask");

            _instrumentFake.Error += Raise.With(new TaskEventArgs("exampleTask"));

            A.CallTo(() => _consoleLogger.LogToConsole("Error occurred")).MustHaveHappenedOnceExactly();
            A.CallTo(() => _taskDispatcherFake.FinishedTask("exampleTask")).MustNotHaveHappened();
        }
    }
}
