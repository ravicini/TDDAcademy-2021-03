using System;

namespace TddAcademy.Tests
{
    public class FakeConsoleLogger : IConsoleLogger
    {
        public bool LoggedToConsole { get; set; }

        public FakeConsoleLogger()
        {
            LoggedToConsole = false;
        }

        public void LogToConsole(string message)
        {
            LoggedToConsole = true;
        }
    }
}