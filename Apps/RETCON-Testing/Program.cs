using RETCON.Core.Event;
using RETCON.Core.Logger;

namespace Testing
{
    public class TestApp : RETCON.Core.Application
    {
        public override void Run()
        {
            Logger.Engine.Log("", LogColors.Trace, newline: false);
            Logger.Engine.Log(" - RETCON GAME ENGINE - ", LogColors.Trace, ConsoleColor.Blue, true);

            Logger.Application.Log("", LogColors.Trace, newline: false);
            Logger.Application.Log(" - TESTING APPLICATION - ", LogColors.Trace, ConsoleColor.DarkBlue, true);

            Logger.Application.Log("Application started\n\n", LogColors.Trace, newline: false);
            
            // Create Window
            RETCON.Core.RET_Window.Window test = new RETCON.Core.RET_Window.Window()
            {
                title = "RETCON Window",
                width = 800,
                height = 600
            };

            WindowOpenEvent openEvent = new WindowOpenEvent(test);

            test.SetEventCallback((e) =>
            {
                Logger.Application.Log($"EVENT: {e}", LogColors.Trace);
            });
            
            openEvent.Dispatch();

            // Run Application
            test.Run();
            base.Run();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TestApp t = new TestApp();
            t.Run();
        }
    }
}