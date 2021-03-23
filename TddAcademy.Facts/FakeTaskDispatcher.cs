namespace TddAcademy.Tests
{
    public class FakeTaskDispatcher : ITaskDispatcher
    {
        public bool FinishedTaskExecuted { get; set; }


        public FakeTaskDispatcher()
        {
            FinishedTaskExecuted = false;
        }

        public string GetTask()
        {
            return "fake";
        }

        public void FinishedTask(string task)
        {
            FinishedTaskExecuted = true;
        }
    }
}