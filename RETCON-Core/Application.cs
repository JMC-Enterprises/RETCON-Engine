using RETCON.Core.Event;

namespace RETCON.Core
{
    public class Application
    {
        public Application()
        {
        }

        ~Application() 
        { }

        public virtual void Run()
        {
            while (true)
            { }
        }

        public void OnEvent(BaseEvent e)
        {
            
        }

        private RETCON.Core.RET_Window.Window _window;
    }
}