using System;

namespace TddAcademy.Tests
{
    public class FakeInstrument : IInstrument
    {
        public string ExecutedFunction { get; set; }

        public void Execute(string task)
        {
            
        }

        public void TriggerFinishedEvent()
        {
            Finished?.Invoke(this, new TaskEventArgs("fake"));
        }

        public void TriggerErrorEvent()
        {
            Error?.Invoke(this, new TaskEventArgs("fake"));
        }

        public event EventHandler<TaskEventArgs> Finished;
        public event EventHandler<TaskEventArgs> Error;
    }
}