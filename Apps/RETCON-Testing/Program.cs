using RETCON.Core.Event;
using RETCON.Core.Graphics;
using RETCON.Core.Logger;

namespace Testing
{
    public class TestApp : RETCON.Core.Application
    {
        public override void Run()
        {
            Logger.Application.Log("RECTON Testing Application", LogColors.Trace);
            Logger.Application.Log("Starting App...", LogColors.Trace);

            // Create Window
            _window = new Window
            {
                title = "Testing App",
                width = 800,
                height = 600
            };
            
            _window.SetEventCallback((e) =>
            {
                Logger.Application.Log($"Event: {Enum.GetName(typeof(EventType), e.GetEventType())}",
                    LogColors.Trace);

                e.IsHandled = true;
            });

            // Run Application
            _window.Run();
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