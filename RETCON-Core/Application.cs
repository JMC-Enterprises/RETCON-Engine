using System.Diagnostics;
using RETCON.Core.Graphics;
using RETCON.Core.Logger;

namespace RETCON.Core
{
    public class Application
    {
        private Stopwatch _sw = new Stopwatch();
        private float _dt = 0.0f;
        private bool _canUpdate = true;
        
        public Application()
        {
        }

        ~Application() 
        { }

        public virtual void Run()
        {
            try
            {
                OpenGL.RetconGl.Init();
            }
            catch
            {
                Logger.Logger.Engine.Log("libRETCON_GLFW.dll not found!", LogColors.Critical);
                System.Console.ReadKey();
                return;
            }
            
            Logger.Logger.Engine.Log("Initalized libRETCON_GLFW.dll successfully!", LogColors.Success);

            while (true)
            {
                OnUpdate();
            }
        }

        protected virtual void OnUpdate()
        {
            if (!_canUpdate) return;
            _sw.Start();

            // Get Input

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