using System.Diagnostics;
using GLFW;
using RETCON.Core.Event;
using RETCON.Core.Graphics;
using RETCON.Core.Logger;
using Window = GLFW.Window;

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
            {
                OnUpdate();
            }
        }

        private Stopwatch _sw = new Stopwatch();
        private float _dt = 0.0f;
        private bool _canUpdate = true;
        
        protected virtual void OnUpdate()
        {
            if (!_canUpdate) return;
            _sw.Start();

            // Get Input
            // Check if Escape Key is pressed
            if (Input.IsKeyPressed(Keys.Escape, _window.glWindow))
            {
                Logger.Logger.Application.Log($"Escape key pressed, closing window", LogColors.Success);
                _canUpdate = false;
                
                // Close Window
                _window.Terminate();
                return;
            }
            
            // Get Delta Time
            _sw.Stop();
            _dt = _sw.ElapsedMilliseconds / 1000.0f;
            _sw.Reset();

            // Final call
            _window.Update(_dt);
        }

        protected RETCON.Core.Graphics.Window _window;
    }
}