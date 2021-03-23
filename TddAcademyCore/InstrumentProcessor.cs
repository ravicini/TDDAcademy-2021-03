using System;

namespace TddAcademy.Tests
{
    public class InstrumentProcessor : IInstrumentProcessor
    {
        private readonly IInstrument _instrument;
        private readonly ITaskDispatcher _taskDispatcher;
        private readonly IConsoleLogger _consoleLogger;

        public InstrumentProcessor(IInstrument instrument, ITaskDispatcher taskDispatcher, IConsoleLogger consoleLogger)
        {
            _instrument = instrument;
            _taskDispatcher = taskDispatcher;
            _consoleLogger = consoleLogger;

            _instrument.Finished += ((sender, arguments) => _taskDispatcher.FinishedTask(arguments.Task));
            _instrument.Error += ((sender, arguments) => { _consoleLogger.LogToConsole("Error occurred"); });
        }

        public void Process()
        {
            var currentTask = _taskDispatcher.GetTask();

            _instrument.Execute(currentTask);
        }
    }
}